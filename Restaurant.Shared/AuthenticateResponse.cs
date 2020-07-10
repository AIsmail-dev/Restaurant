using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Shared
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }

        public AuthenticateResponse(UserDTO user, string token, bool isAuthenticated)
        {
            if (user != null)
            {
                Id = user.UserId;
                FullName = user.FullName;
            }
            Token = token;
            IsAuthenticated = isAuthenticated;
        }
    }
}
