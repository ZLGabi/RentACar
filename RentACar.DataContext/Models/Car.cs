using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Car
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

        public virtual CarPhoto MainPhoto { get; set; }
        
        public virtual ICollection<CarGallery> Gallery { get; set; }

        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
