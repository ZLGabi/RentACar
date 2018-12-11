using RentACar.DataContext.Models;
using System.Data.Entity;

namespace RentACar.DataContext
{
    public class RentACarDataContext : DbContext
    {
        public RentACarDataContext(): base("RentACarDataContext")
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
