using System.Collections.Generic;

namespace RentACar.DataContext.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
