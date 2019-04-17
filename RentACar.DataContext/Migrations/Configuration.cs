namespace RentACar.DataContext.Migrations
{
    using RentACar.DataContext.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RentACar.DataContext.RentACarDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentACar.DataContext.RentACarDataContext context)
        {
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
                            Brand = "Volkswagen",
                            Model = "Polo",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
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
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            CreatedDate = System.DateTime.Now.Date,
                            ModifiedDate = System.DateTime.Now.Date,
                            Price = 19,
                            Type = "Hatchback",
                            Fuel = "Petrol",
                            Transmision = "Manual",
                            NoDoors = 5,
                            IsAvailable = true,
                            MainPhoto = new CarPhoto { Url = "/images/cars/main/small.jpg" }
                        },
                        new Car
                        {
                            Brand = "Opel",
                            Model = "Astra H",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            CreatedDate = System.DateTime.Now.Date,
                            ModifiedDate = System.DateTime.Now.Date,
                            Price = 18,
                            Type = "Hatchback",
                            Fuel = "Petrol",
                            Transmision = "Manual",
                            NoDoors = 5,
                            IsAvailable = true,
                            MainPhoto = new CarPhoto { Url = "/images/cars/main/small.jpg" }
                        },
                        new Car
                        {
                            Brand = "Dacia",
                            Model = "Sandero",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            CreatedDate = System.DateTime.Now.Date,
                            ModifiedDate = System.DateTime.Now.Date,
                            Price = 15,
                            Type = "Hatchback",
                            Fuel = "Diesel",
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


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("Password1", out passwordHash, out passwordSalt);
            context.Users.AddOrUpdate(u => u.Username,
                new User()
                {
                    Username = "Admin",
                    Email = "admin@domain.com",
                    PhoneNumber = "1234567890",
                    Photo = new UserPhoto { Url = "/images/users/Icon-user.png" },
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Roles = new List<Role>()
                    {
                         new Role
                         {
                             Name = "Admin",
                             Description = "Manages the accounts."
                         }
                    }
                }
                );
            context.Roles.AddOrUpdate(r => r.Name,
            new Role
            {
                Name = "Manager",
                Description = "Manages the app products."
            },
            new Role
            {
                Name = "Customer",
                Description = "The client user."
            }
            );
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
