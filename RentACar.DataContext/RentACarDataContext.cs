using RentACar.DataContext.Models;
using System.Data.Entity;

namespace RentACar.DataContext
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(): base("RentACarDbContext")
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
