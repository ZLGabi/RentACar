using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Period
    {
        
        public int PeriodId { get; set; }
        public int Days { get; set; }
        public int PriceModifier { get; set; }
        
    }
}
