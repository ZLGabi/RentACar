namespace RentACar.DataContext.Migrations
{
    using RentACar.DataContext.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentACar.DataContext.RentACarDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentACar.DataContext.RentACarDataContext context)
        {
            this.AddUserAndRoles();
            context.Portfolios.AddOrUpdate(p => p.Name,
               new Portfolio
               {
                   Name = "Small Cars",
                   Description = "Best cars if you plan to drive inside the city.",
                   Photo = new PortfolioPhoto { Url = "/images/portfolios/small.jpg" },
                   Cars = new List<Car>()
                   {
                        new Car
                        {
                            Brand = "Volksvagen",
                            Model = "Polo",
                            Description = "desc",
                            CreatedDate = System.DateTime.Now.Date,
                            ModifiedDate = System.DateTime.Now.Date,
                            Price = 20,
                            Type = "Hatchback",
                            Fuel = "Diesel",
                            Transmision = "Manual",
                            NoDoors = 5,
                            IsAvailable = true,
                            MainPhoto = new CarPhoto { Url = "/images/cars/main/small.jpg" }
                        },
                        new Car
                        {
                            Brand = "Skoda",
                            Model = "Fabia",
                            Description = "desc",
                            CreatedDate = System.DateTime.Now.Date,
                            ModifiedDate = System.DateTime.Now.Date,
                            Price = 20,
                            Type = "Hatchback",
                            Fuel = "Petrol",
                            Transmision = "Manual",
                            NoDoors = 5,
                            IsAvailable = true,
                            MainPhoto = new CarPhoto { Url = "/images/cars/main/small.jpg" }
                        }
                   }
               },
               new Portfolio
               {
                   Name = "Medium Cars",
                   Description = "Best cars if you plan longer trips.",
                   Photo = new PortfolioPhoto { Url = "/images/portfolios/medium.png" }

               },
               new Portfolio
               {
                   Name = "Big Cars",
                   Description = "Best cars for an offroad adventure.",
                   Photo = new PortfolioPhoto { Url = "/images/portfolios/big.jpg" }

               }
           );

            context.Periods.AddOrUpdate(p => p.PriceModifier,
                new Period
                {
                    PeriodId = 1,
                    Days = 3,
                    PriceModifier = 5
                },
                new Period
                {
                    PeriodId = 2,
                    Days = 5,
                    PriceModifier = 10
                },
                new Period
                {
                    PeriodId = 3,
                    Days = 10,
                    PriceModifier = 15
                }
                );

        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("Manager");
            if (!success == true) return success;

            success = idManager.CreateRole("Customer");
            if (!success) return success;


            var newUser = new User()
            {
                UserName = "Admin",
                Email = "admin@domain.com",
                Photo = new UserPhoto { Url = "/images/users/Icon-user.png" }
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Manager");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Customer");
            if (!success) return success;

            return success;
        }
    }
}
