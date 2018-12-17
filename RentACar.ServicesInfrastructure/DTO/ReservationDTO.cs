using RentACar.DataContext.Models;
using System;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public float FinalPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public CarReservationDTO Car { get; set; }
        public PeriodDTO Period { get; set; }
    }
}
