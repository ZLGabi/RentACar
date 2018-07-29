using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar_MVC.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int FinalPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }

        public  Car Car { get; set; }
    }
}