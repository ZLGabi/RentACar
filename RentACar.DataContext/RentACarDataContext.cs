using RentACar.DataContext.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RentACar.DataContext
{
    public class RentACarDataContext : DbContext
    {
        public RentACarDataContext() : base("RentACarDataContext")
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }
        public DbSet<PortfolioPhoto> PortfolioPhotos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<CarGallery> CarGalleries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

