using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Reservation
    {
        [ForeignKey("Car")]
        public int ReservationId { get; set; }
        public float FinalPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        
        public virtual Car Car { get; set; }
        
        public virtual Period Period { get; set; }
    }
}
