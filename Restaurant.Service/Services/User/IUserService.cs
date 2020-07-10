using Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public interface IUserService
    {
        Task<bool> GetUserByCredentials(string email, string password);
        Task<UserDTO> AddUser(UserDTO userDTO);
        Task<AuthenticateResponse> Authenticate(UserDTO userDTO);
        Task<List<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserById(int userId);
    }
}
