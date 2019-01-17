using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class PortfolioListDTO
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PortfolioPhotoDTO Photo { get; set; }
    }
}
