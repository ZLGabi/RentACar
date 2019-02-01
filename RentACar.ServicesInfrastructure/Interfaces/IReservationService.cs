using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface IReservationService
    {
        ReservationDTO GetReservation(string username, int id);
        List<ReservationDTO> GetReservations(string username);
        CarReservationDTO GetCarForReservation(int carId);
        List<PeriodDTO> GetPeriods();
        float CalculateRentFinalPrice(int carPrice, int numberOfDays, int priceModifier);

        void AddReservation(ReservationCreationDTO reservationDTO);
        void DeleteReservation(ReservationDTO reservationDTO);
        void CancelReservation(ReservationDTO reservationDTO);
    }
}
