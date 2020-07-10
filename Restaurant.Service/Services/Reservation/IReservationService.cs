using Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public interface IReservationService
    {
        Task<ReservationDTO> AddReservation(ReservationDTO reservationDTO);
        Task<List<ReservationDTO>> GetAllReservations();
        Task<ReservationDTO> GetReservationById(int reservationId);
    }
}
