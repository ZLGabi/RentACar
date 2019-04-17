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
            CreateMap<CarPhotoDTO, CarPhoto>()
                .ForMember(dest => dest.CarMainPhoto, opt =>
                {
                    opt.Ignore();
                });
            CreateMap<CarGallery, CarGalleryDTO>();
            CreateMap<PortfolioPhoto, PortfolioPhotoDTO>();
            CreateMap<UserPhoto, UserPhotoDTO>();
            CreateMap<Period, PeriodDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<ReservationCreationDTO, Reservation>()
                .ForMember(dest => dest.Car, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.User, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.Car, opt =>
                 {
                     opt.Ignore();
                 });
            CreateMap<Reservation, ReservationDTO>()
                .ForMember(dest => dest.Username, opt =>
                {
                    opt.MapFrom(src => src.User.Username);
                });
            CreateMap<ReservationDTO, Reservation>()
                .ForMember(dest => dest.CarId, opt =>
                {
                    opt.MapFrom(src => src.Car.CarId);
                })
                .ForMember(dest => dest.PeriodId, opt =>
                {
                    opt.MapFrom(src => src.Period.PeriodId);
                });
            CreateMap<Review, ReviewDTO>()
                .ForMember(dest => dest.Reviewer, opt =>
                {
                    opt.MapFrom(src => src.User.Username);
                });
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.PasswordSalt, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.Reservations, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.Reviews, opt =>
                {
                    opt.Ignore();
                })
                .ForMember(dest => dest.Roles, opt =>
                {
                    opt.Ignore();
                });
            CreateMap<User, UserLoginDTO>();
            CreateMap<Car, CarReservationDTO>();
            CreateMap<CarReservationDTO, Car>()
            .ForMember(dest => dest.CarId, opt =>
            {
                opt.MapFrom(src => src.CarId);
            })
            .ForMember(dest => dest.CreatedDate, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.ModifiedDate, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Description, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Fuel, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Gallery, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.NoDoors, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Transmision, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Type, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Portfolio, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.PortfolioId, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Reservations, opt =>
            {
                opt.Ignore();
            })
            .ForMember(dest => dest.Reviews, opt =>
            {
                opt.Ignore();
            });
        }
    }
}
