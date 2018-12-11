using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DataContext.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int FinalPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }

        [Required]
        public virtual Car Car { get; set; }

        [Required]
        public virtual Period Period { get; set; }
    }
}
