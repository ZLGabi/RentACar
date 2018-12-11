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
                        CarId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Type = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        Description = c.String(),
                        Fuel = c.String(),
                        Transmision = c.String(),
                        NoDoors = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId)
                .ForeignKey("dbo.Photos", t => t.CarId)
                .Index(t => t.CarId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        CarPhotosId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Cars", t => t.CarPhotosId)
                .Index(t => t.CarPhotosId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.Photos", t => t.PortfolioId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Photos", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Reviewid = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.Int(),
                        CarId = c.Int(),
                    })
                .PrimaryKey(t => t.Reviewid)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false),
                        FinalPrice = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Cars", t => t.ReservationId)
                .ForeignKey("dbo.Periods", t => t.ReservationId)
                .Index(t => t.ReservationId);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        PeriodId = c.Int(nullable: false, identity: true),
                        Days = c.Int(nullable: false),
                        PriceModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ReservationId", "dbo.Periods");
            DropForeignKey("dbo.Reservations", "ReservationId", "dbo.Cars");
            DropForeignKey("dbo.Photos", "CarPhotosId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "CarId", "dbo.Photos");
            DropForeignKey("dbo.RoleUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Users", "UserId", "dbo.Photos");
            DropForeignKey("dbo.Portfolios", "PortfolioId", "dbo.Photos");
            DropForeignKey("dbo.Cars", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.RoleUsers", new[] { "User_UserId" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleId" });
            DropIndex("dbo.Reservations", new[] { "ReservationId" });
            DropIndex("dbo.Reviews", new[] { "CarId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserId" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioId" });
            DropIndex("dbo.Photos", new[] { "CarPhotosId" });
            DropIndex("dbo.Cars", new[] { "PortfolioId" });
            DropIndex("dbo.Cars", new[] { "CarId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Periods");
            DropTable("dbo.Reservations");
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Photos");
            DropTable("dbo.Cars");
        }
    }
}
