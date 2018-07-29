using RentACar.DataContext.Models;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class PortfolioDTO
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
