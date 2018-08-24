namespace RentACar.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Portfolio_PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioId)
                .Index(t => t.Portfolio_PortfolioId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        FinalPrice = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        Car_CarId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Cars", t => t.Car_CarId)
                .Index(t => t.Car_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Reservations", new[] { "Car_CarId" });
            DropIndex("dbo.Cars", new[] { "Portfolio_PortfolioId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Cars");
        }
    }
}
