using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using System.Data.Entity;

namespace RentACar.Services
{
    public class ReservationService :  IReservationService
    {
        private readonly Repository<Reservation> _reservationRepository;
        public ReservationService(DbContext context)
        {
            _reservationRepository = new Repository<Reservation>(context);
        }

        public void CalculateRentFinalPrice(int id)
        {
            var reservation = _reservationRepository.Get(id);
            reservation.FinalPrice = reservation.Car.Price * reservation.NumberOfDays;
        }
    }
}
