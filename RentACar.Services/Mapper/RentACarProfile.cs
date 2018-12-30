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
            CreateMap<CarPhoto, CarPhotoDTO>();
            CreateMap<CarGallery, CarGalleryDTO>();
            CreateMap<PortfolioPhoto, PortfolioPhotoDTO>();
            CreateMap<UserPhoto, UserPhotoDTO>();
            CreateMap<Period, PeriodDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<Review, ReviewDTO>()
                .ForMember(dest => dest.Reviewer, opt =>
                {
                    opt.MapFrom(src => src.User.UserName);
                });
            CreateMap<User, UserDTO>();
        }
    }
}
