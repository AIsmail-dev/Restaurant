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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("AddReservation")]
        public async Task<ReservationDTO> AddReservation([FromBody]ReservationDTO reservationDTO)
        {
            return await _reservationService.AddReservation(reservationDTO);
        }

        [HttpGet("GetAllReservations")]
        public async Task<List<ReservationDTO>> GetAllReservations()
        {
            return await _reservationService.GetAllReservations();
        }

        [HttpGet("GetReservationById/{reservationId}")]
        public async Task<ReservationDTO> GetReservationById(int reservationId)
        {
            return await _reservationService.GetReservationById(reservationId);
        }
    }
}
