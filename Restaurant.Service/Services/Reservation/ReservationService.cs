using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class ReservationService : IReservationService
    {

        #region Fields

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public ReservationService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Queries

        public async Task<List<ReservationDTO>> GetAllReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return _mapper.Map<List<ReservationDTO>>(reservations);
        }

        public async Task<ReservationDTO> GetReservationById(int reservationId)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(a => a.ReservationId == reservationId);
            return _mapper.Map<ReservationDTO>(reservation);
        }

        #endregion

        #region Commands

        public async Task<ReservationDTO> AddReservation(ReservationDTO reservationDTO)
        {
            Reservation reservation = new Reservation(reservationDTO.GuestNumber, reservationDTO.ReservationDate, reservationDTO.MenuTypeId, reservationDTO.Notes);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReservationDTO>(reservation);
        }

        #endregion
    }
}
