using System.Collections.Generic;
using RentACar_MVC.DBContext;
using RentACar_MVC.Models;

namespace RentACar_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentACar_MVC.DBContext.RentingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RentACar_MVC.DBContext.RentingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            RentingContext dbContext = new RentingContext();
            List<Car> cars = new List<Car>()
            {
                new Car{Brand = "Dacia",
                    Model = "Logan",
                    Type = "Berlina",
                    Description = "desc Dacia",
                    Price = 50},
                new Car{
                    Brand = "Volkswagen",
                    Model = "Golf 5",
                    Type = "Hatchback",
                    Description = "desc Volkswagen",
                    Price = 100
                },
                new Car{
                    Brand = "Audi",
                    Model = "A4",
                    Type = "Coupe",
                    Description = "desc Audi",
                    Price = 150
                },
                new Car{
                    Brand = "Toyota",
                    Model = "RAV-4",
                    Type = "SUV",
                    Description = "desc Toyota",
                    Price = 200
                }
            };
            cars.ForEach(c => dbContext.Cars.Add(c));
            dbContext.Portfolios.Add(new Portfolio { Name = "MyPotofolio1", Cars = new List<Car> { cars[0], cars[1] } });
            dbContext.Portfolios.Add(new Portfolio { Name = "MyPotofolio2", Cars = new List<Car> { cars[2], cars[3] } });
            dbContext.SaveChanges();
        }
    }
}
