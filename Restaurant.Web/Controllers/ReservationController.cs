using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Shared;

namespace Restaurant.Web
{
    public class ReservationController : Controller
    {
        private readonly IApiClient _ApiClient;

        public ReservationController(IApiClient apiClient)
        {
            _ApiClient = apiClient;
        }

        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationDTO reservationDTO)
        {
            reservationDTO = await _ApiClient.PostAsync<ReservationDTO>("/Reservation/AddReservation", reservationDTO);
            return RedirectToAction("ReservationDetails", reservationDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ReservationDetailsAsync(int reservationId)
        {
            var reservationDTO = await _ApiClient.GetAsync<ReservationDTO>("/Reservation/GetReservationById/" + reservationId);
            return View(reservationDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationsAsync()
        {
            List<ReservationDTO> reservationDTOs = await _ApiClient.GetListAsync<ReservationDTO>("/Reservation/GetAllReservations/");
            return View(reservationDTOs);
        }
    }
}