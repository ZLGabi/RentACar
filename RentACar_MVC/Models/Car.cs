using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar_MVC.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public  Portfolio Portfolio { get; set; }
      }
}