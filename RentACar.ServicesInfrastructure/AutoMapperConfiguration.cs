using RentACar.DataContext.Models;
using RentACar.ServicesInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ServicesInfrastructure
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Car, CarDTO>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Portfolio, PortfolioDTO>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Reservation, ReservationDTO>());
        }
    }
}
