using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data;
using Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public UserService(IAppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        #endregion

        #region Queries

        public async Task<bool> GetUserByCredentials(string email, string password)
        {
            return await _context.Users.AnyAsync(a => a.Email == email && a.Password == password);
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(a => a.Email == email);
        }

        public async Task<AuthenticateResponse> Authenticate(UserDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == userDTO.Email && a.Password == userDTO.Password);
            userDTO = _mapper.Map<UserDTO>(user);
            if (user == null) return new AuthenticateResponse(null, "", false);
            var token = GenerateJwtToken(userDTO);

            return new AuthenticateResponse(userDTO, token, true);
        }

        private string GenerateJwtToken(UserDTO userDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var str = _configuration.GetSection("AppSettings:Secret").Value;
            var key = Encoding.ASCII.GetBytes(str);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDTO.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == userId);
            return _mapper.Map<UserDTO>(user);
        }

        #endregion

        #region Commands

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            if (await EmailExists(userDTO.Email))
                throw new BusinessRuleException("Email Exists!!");
            User user = new User(userDTO.FullName, userDTO.Email, userDTO.Password, userDTO.Mobile);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        #endregion
    }
}
