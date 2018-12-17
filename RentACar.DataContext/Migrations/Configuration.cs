using RentACar.DataContext.Models;
using System.Data.Entity.Migrations;

namespace RentACar.DataContext.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<RentACar.DataContext.RentACarDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentACar.DataContext.RentACarDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Portfolios.AddOrUpdate(p => p.Name,
                new Portfolio
                {
                    Name = "Small Cars",
                    Description = "Best cars if you plan to drive inside the city.",
                    Photo = new Photo { Url = "//images//small.jpg" },

                },
                new Portfolio
                {
                    Name = "Medium Cars",
                    Description = "Best cars if you plan longer trips.",
                    Photo = new Photo { Url = "/images/medium.jpg" },

                },
                new Portfolio
                {
                    Name = "Big Cars",
                    Description = "Best cars for an offroad adventure.",
                    Photo = new Photo { Url = @"/images/big.jpg" },

                }
                );
        }
    }
}
