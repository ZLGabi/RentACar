using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DataContext.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        [Required]
        public virtual Photo Photo { get; set; }
    }
}
