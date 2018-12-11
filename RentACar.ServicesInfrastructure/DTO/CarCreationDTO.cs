using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class CarCreationDTO
    {
        public int CarId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Fuel { get; set; }
        public string Transmision { get; set; }
        public int NoDoors { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public PhotoDTO MainPhoto { get; set; }
        public List<PhotoDTO> Photos { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
        public int PortfolioId { get; set; }
    }
}
