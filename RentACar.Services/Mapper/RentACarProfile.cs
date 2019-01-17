using AutoMapper;
using RentACar.DataContext.Models;
using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.Services.Mapper
{
    internal class RentACarProfile : Profile
    {
        public RentACarProfile()
        {
            CreateMap<Car, CarListDTO>()
                .ForMember(dest => dest.PortfolioName, opt =>
                {
                    opt.MapFrom(src => src.Portfolio.Name);
                });
            CreateMap<Car, CarDetailsDTO>()
                .ForMember(dest => dest.PortfolioName, opt =>
            {
                opt.MapFrom(src => src.Portfolio.Name);
            });
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
            CreateMap<User, UserLoginDTO>();
        }
    }
}
