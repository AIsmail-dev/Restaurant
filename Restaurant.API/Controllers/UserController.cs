using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Shared;
using Restaurant.Service;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("AuthenticateAsync")]
        public async Task<AuthenticateResponse> AuthenticateAsync([FromBody]UserDTO userDTO)
        {
            var response = await _userService.Authenticate(userDTO);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public async Task<UserDTO> AddUser([FromBody]UserDTO userDTO)
        {
            return await _userService.AddUser(userDTO);
        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await _userService.GetAllUser();
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<UserDTO> GetUserById(int userId)
        {
            return await _userService.GetUserById(userId);
        }
    }
}
