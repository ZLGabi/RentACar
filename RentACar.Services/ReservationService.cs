using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Linq;

namespace RentACar.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Period> _periodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = _unitOfWork.GetRepository<Reservation>();
            _periodRepository = _unitOfWork.GetRepository<Period>();
        }

        public ReservationDTO GetReservationbyId(int id)
        {
            var reservation = _reservationRepository.Get(id);
            var reservationDTO = AutoMapper.Mapper.Map<ReservationDTO>(reservation);
            return reservationDTO;
        }

        public float CalculateRentFinalPrice(int carPrice, int numberOfDays, int priceModifier)
        {
            var price = carPrice * numberOfDays;

           return price - price*priceModifier/100;
        }

        public void AddReservation(ReservationDTO reservationDTO)
        {
            var period = _periodRepository.GetAll().Where( p => (p.Days <= reservationDTO.NumberOfDays)).OrderByDescending(o => o.Days).FirstOrDefault();
            reservationDTO.Period = AutoMapper.Mapper.Map<PeriodDTO>(period);
            reservationDTO.FinalPrice = CalculateRentFinalPrice(reservationDTO.Car.Price, reservationDTO.NumberOfDays, period.PriceModifier);
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            _reservationRepository.Add(reservation);
            _unitOfWork.Commit();
        }

        public void DeleteReservation(ReservationDTO reservationDTO)
        {
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            _reservationRepository.Delete(reservation);
            _unitOfWork.Commit();
        }
    }
}
