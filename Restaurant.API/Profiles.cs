using AutoMapper;
using Restaurant.Data;
using Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Reservation, ReservationDTO>();
        }
    }
}
