namespace RentACar.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarGallery",
                c => new
                    {
                        CarGalleryId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarGalleryId)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
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
                        PortfolioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.CarPhoto",
                c => new
                    {
                        CarPhotoId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.CarPhotoId)
                .ForeignKey("dbo.Car", t => t.CarPhotoId)
                .Index(t => t.CarPhotoId);
            
            CreateTable(
                "dbo.Portfolio",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioId);
            
            CreateTable(
                "dbo.PortfolioPhoto",
                c => new
                    {
                        PortfolioPhotoId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioPhotoId)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioPhotoId)
                .Index(t => t.PortfolioPhotoId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        FinalPrice = c.Single(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        PeriodId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Period", t => t.PeriodId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.PeriodId);
            
            CreateTable(
                "dbo.Period",
                c => new
                    {
                        PeriodId = c.Int(nullable: false, identity: true),
                        Days = c.Int(nullable: false),
                        PriceModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserPhoto",
                c => new
                    {
                        UserPhotoId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.UserPhotoId)
                .ForeignKey("dbo.User", t => t.UserPhotoId)
                .Index(t => t.UserPhotoId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.Int(nullable: false),
                        CarId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Car", t => t.CarId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Review", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "CarId", "dbo.Car");
            DropForeignKey("dbo.Reservation", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPhoto", "UserPhotoId", "dbo.User");
            DropForeignKey("dbo.Reservation", "PeriodId", "dbo.Period");
            DropForeignKey("dbo.Reservation", "CarId", "dbo.Car");
            DropForeignKey("dbo.PortfolioPhoto", "PortfolioPhotoId", "dbo.Portfolio");
            DropForeignKey("dbo.Car", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.CarPhoto", "CarPhotoId", "dbo.Car");
            DropForeignKey("dbo.CarGallery", "CarId", "dbo.Car");
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.Review", new[] { "CarId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.UserPhoto", new[] { "UserPhotoId" });
            DropIndex("dbo.Reservation", new[] { "PeriodId" });
            DropIndex("dbo.Reservation", new[] { "CarId" });
            DropIndex("dbo.Reservation", new[] { "UserId" });
            DropIndex("dbo.PortfolioPhoto", new[] { "PortfolioPhotoId" });
            DropIndex("dbo.CarPhoto", new[] { "CarPhotoId" });
            DropIndex("dbo.Car", new[] { "PortfolioId" });
            DropIndex("dbo.CarGallery", new[] { "CarId" });
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.Review");
            DropTable("dbo.UserPhoto");
            DropTable("dbo.User");
            DropTable("dbo.Period");
            DropTable("dbo.Reservation");
            DropTable("dbo.PortfolioPhoto");
            DropTable("dbo.Portfolio");
            DropTable("dbo.CarPhoto");
            DropTable("dbo.Car");
            DropTable("dbo.CarGallery");
        }
    }
}
