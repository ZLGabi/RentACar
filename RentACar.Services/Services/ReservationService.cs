using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentACar.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Period> _periodRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = _unitOfWork.GetRepository<Reservation>();
            _periodRepository = _unitOfWork.GetRepository<Period>();
            _carRepository = _unitOfWork.GetRepository<Car>();
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public ReservationDTO GetReservation(string username, int id)
        {
            var reservation = _reservationRepository.GetAll().AsNoTracking().Include(c => c.Car).Include(p => p.Period)
                .FirstOrDefault(r => r.ReservationId == id && r.User.Username == username);
            var reservationDTO = AutoMapper.Mapper.Map<ReservationDTO>(reservation);
            return reservationDTO;
        }

        public List<ReservationDTO> GetReservations(string username)
        {
            var reservations = _reservationRepository.GetAll().Include(c => c.Car).Include(p => p.Period)
                .Where(r => r.User.Username == username).ToList();
            var reservationsDTO = AutoMapper.Mapper.Map<List<ReservationDTO>>(reservations);
            return reservationsDTO;
        }

        public CarReservationDTO GetCarForReservation(int carId)
        {
            var car = _carRepository.GetAll().Include(p => p.MainPhoto).FirstOrDefault(c => c.CarId == carId);
            var carDTO = AutoMapper.Mapper.Map<CarReservationDTO>(car);
            return carDTO;
        }
        public List<PeriodDTO> GetPeriods()
        {
            var periods = _periodRepository.GetAll().OrderBy(p => p.Days).ToList();
            var periodsDTO = AutoMapper.Mapper.Map<List<PeriodDTO>>(periods);
            return periodsDTO;
        }
        public float CalculateRentFinalPrice(int carPrice, int numberOfDays, int priceModifier)
        {
            var price = carPrice * numberOfDays;

            return price - price * priceModifier / 100;
        }
        public void AddReservation(ReservationCreationDTO reservationCreationDTO)
        {
            reservationCreationDTO.NumberOfDays = reservationCreationDTO.EndDate.Subtract(reservationCreationDTO.BeginDate).Days + 1;
            var period = _periodRepository.GetAll().Where(p => (p.Days <= reservationCreationDTO.NumberOfDays)).OrderByDescending(o => o.Days).FirstOrDefault();
            int priceModifier = 0;
            if (period != null)
            {
                reservationCreationDTO.PeriodId = period.PeriodId;
                priceModifier = period.PriceModifier;
            }
            var car = _carRepository.Get(reservationCreationDTO.CarId);
            reservationCreationDTO.Car = AutoMapper.Mapper.Map<CarReservationDTO>(car);
            reservationCreationDTO.Car.IsAvailable = false;
            ChangeCarAvailability(reservationCreationDTO.Car.CarId, reservationCreationDTO.Car.IsAvailable);
            reservationCreationDTO.FinalPrice = CalculateRentFinalPrice(car.Price, reservationCreationDTO.NumberOfDays, priceModifier);
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username==HttpContext.Current.User.Identity.Name);
            reservationCreationDTO.UserId = user.UserId;
            reservationCreationDTO.User = AutoMapper.Mapper.Map<UserDTO>(user);
            reservationCreationDTO.Status = "Active";
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationCreationDTO);
            _reservationRepository.Add(reservation);
            _unitOfWork.Commit();
        }

        public void DeleteReservation(ReservationDTO reservationDTO)
        {
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            _reservationRepository.Delete(reservation);
            _unitOfWork.Commit();
        }

        public void CancelReservation(ReservationDTO reservationDTO)
        {
            ChangeCarAvailability(reservationDTO.Car.CarId, true);
            reservationDTO.Status = "Canceled";
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == HttpContext.Current.User.Identity.Name);
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            reservation.User = user;
            reservation.UserId = user.UserId;
            reservation.Car = null;
            _reservationRepository.Update(reservation);
            _unitOfWork.Commit();
        }

        private void ChangeCarAvailability(int carId, bool state)
        {
            var car = _carRepository.Get(carId);
            car.IsAvailable = state;
            _carRepository.Update(car);
        }
    }
}
