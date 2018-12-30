using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        
        public virtual PortfolioPhoto Photo { get; set; }
    }
}
