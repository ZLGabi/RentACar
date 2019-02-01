using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public float FinalPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public int? PeriodId { get; set; }
        [ForeignKey("PeriodId")]
        public virtual Period Period { get; set; }
    }
}
