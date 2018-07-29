using RentACar_MVC.Models;
using System.Data.Entity;

namespace RentACar_MVC.DBContext
{
    public class RentingContext : DbContext
    {
        public RentingContext(): base("CarContext")
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
} 