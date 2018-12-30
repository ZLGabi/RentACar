using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RentACar.DataContext
{
    public class RentACarDataContext : IdentityDbContext<User>
    {
        public RentACarDataContext() : base("RentACarDataContext")
        {
            Database.SetInitializer<RentACarDataContext>(null);// Remove default initializer
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
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
        //Identity and Authorization
        public DbSet<IdentityUserLogin> UserLogins { get; set; }
        public DbSet<IdentityUserClaim> UserClaims { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<CarPhoto>().ToTable("CarPhotos");
            //modelBuilder.Entity<PortfolioPhoto>().ToTable("PortfolioPhotos");
            //modelBuilder.Entity<UserPhoto>().ToTable("UserPhotos");

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(u => u.SecurityStamp).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);

            modelBuilder.Entity<Reservation>()
                .HasRequired(e => e.Period)
                .WithOptional()
                .Map(m => m.MapKey("PeriodId"));
        }
    }
}

