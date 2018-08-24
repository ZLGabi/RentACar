using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.ServicesInfrastructure
{
    public interface IReservationService
    {
        ReservationDTO GetReservationbyId(int id, params string[] includeProperties);
        void CalculateRentFinalPrice(int id);

        void AddReservation(ReservationDTO reservationDTO);
        void UpdateReservation(ReservationDTO reservationDTO);
        void DeleteReservation(ReservationDTO reservationDTO);
    }
}
