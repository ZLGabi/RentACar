using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = _unitOfWork.GetRepository<Reservation>();
        }

        public ReservationDTO GetReservationbyId(int id)
        {
            var reservation = _reservationRepository.Get(id);
            var reservationDTO = AutoMapper.Mapper.Map<ReservationDTO>(reservation);
            return reservationDTO;
        }

        public void CalculateRentFinalPrice(int id)
        {
            var reservation = _reservationRepository.Get(id);
            reservation.FinalPrice = reservation.Car.Price * reservation.NumberOfDays;
        }

        public void AddReservation(ReservationDTO reservationDTO)
        {
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            _reservationRepository.Add(reservation);
            _unitOfWork.Commit();
        }

        public void UpdateReservation(ReservationDTO reservationDTO)
        {
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDTO);
            _reservationRepository.Update(reservation);
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
