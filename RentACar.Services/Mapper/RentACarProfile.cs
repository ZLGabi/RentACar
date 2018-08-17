using AutoMapper;
using RentACar.DataContext.Models;
using RentACar.ServicesInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Services.Mapper
{
    internal class RentACarProfile : Profile
    {
        public RentACarProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<Reservation, ReservationDTO>();
        }
    }
}
