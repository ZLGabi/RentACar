namespace RentACar.DataContext.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentACar.DataContext.RentACarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentACar.DataContext.RentACarDbContext context)
        {
            RentACarDbContext dbContext = new RentACarDbContext();
            dbContext.Portfolios.AddOrUpdate(p => p.PortfolioId,
                new Portfolio
                {
                    PortfolioId = 1,
                    Name = "MyPortfolio1",
                    Cars = new List<Car> {
                        new Car{Brand = "Dacia",
                            Model = "Logan",
                            Type = "Sedan",
                            Description = "desc Dacia",
                            Price = 50},
                        new Car{
                            Brand = "Volkswagen",
                            Model = "Golf 5",
                            Type = "Hatchback",
                            Description = "desc Volkswagen",
                            Price = 100},
                        new Car{
                            Brand = "Skoda",
                            Model = "Fabia",
                            Type = "Hatchback",
                            Description = "desc Skoda",
                            Price = 80}
                    }
                },
                new Portfolio
                {
                    PortfolioId=2,
                    Name = "MyPortfolio2",
                    Cars = new List<Car> {
                        new Car{
                            Brand = "Audi",
                            Model = "A4",
                            Type = "Coupe",
                            Description = "desc Audi",
                            Price = 150},
                        new Car{
                            Brand = "Toyota",
                            Model = "RAV-4",
                            Type = "SUV",
                            Description = "desc Toyota",
                            Price = 200}
                    }
                });

            dbContext.SaveChanges();
        }
    }
}
