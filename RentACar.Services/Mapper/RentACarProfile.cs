using AutoMapper;
using RentACar.DataContext.Models;
using RentACar.ServicesInfrastructure.DTO;
using System.Linq;

namespace RentACar.Services.Mapper
{
    internal class RentACarProfile : Profile
    {
        public RentACarProfile()
        {
            CreateMap<Car, CarListDTO>();
            CreateMap<Car, CarDetailsDTO>();
            CreateMap<Car, CarReservationDTO>();
            CreateMap<Photo, PhotoDTO>();
            CreateMap<Period, PeriodDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<Review, ReviewDTO>()
                .ForMember(dest => dest.Reviewer, opt =>
                {
                    opt.MapFrom(src => src.User.Username);
                });
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
