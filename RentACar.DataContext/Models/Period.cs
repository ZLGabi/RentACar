using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataContext.Models
{
    public class Period
    {
        public int PeriodId { get; set; }
        public int Days { get; set; }
        public int PriceModifier { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
