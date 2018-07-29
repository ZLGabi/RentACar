using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACar_MVC.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public  ICollection<Car> Cars { get; set; }
    }
}