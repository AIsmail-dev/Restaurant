using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Shared;

namespace Restaurant.Web
{
    public class UserController : Controller
    {
        private readonly IApiClient _ApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IApiClient apiClient, IHttpContextAccessor httpContextAccessor)
        {
            _ApiClient = apiClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var authenticateResponse = await _ApiClient.PostAsync<AuthenticateResponse>("/User/AuthenticateAsync?email=", new { Email = email, Password = password });
            if (authenticateResponse.IsAuthenticated)
            {
                _httpContextAccessor.HttpContext.Session.SetString("token", authenticateResponse.Token);
                return RedirectToAction("GetAllReservations", "Reservation");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Username or Password!!!";
                return View();
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserDTO userDTO)
        {
            await _ApiClient.PostAsync<UserDTO>("/User/AddUser/", userDTO);
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> UserDetailsAsync(int userId)
        {
            var userDTO = await _ApiClient.GetAsync<UserDTO>("/User/GetUserById/" + userId);
            return View(userDTO);
        }

        public async Task<IActionResult> GetAllUsersAsync()
        {
            List<UserDTO> userDTOs = await _ApiClient.GetListAsync<UserDTO>("/User/GetAllUsers/");
            return View(userDTOs);
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Remove("token");
            return RedirectToAction("Login");
        }
    }
}