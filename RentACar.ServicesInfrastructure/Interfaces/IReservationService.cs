using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.ServicesInfrastructure
{
    public interface IReservationService
    {
        ReservationDTO GetReservationbyId(int id);
        float CalculateRentFinalPrice(int carPrice, int numberOfDays, int priceModifier);

        void AddReservation(ReservationDTO reservationDTO);
        void DeleteReservation(ReservationDTO reservationDTO);
    }
}
