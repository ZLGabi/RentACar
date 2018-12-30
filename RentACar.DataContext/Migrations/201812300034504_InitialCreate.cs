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
                .ForeignKey("dbo.Car", t => t.CarId)
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
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId)
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
                        ReservationId = c.Int(nullable: false),
                        FinalPrice = c.Single(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        PeriodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Car", t => t.ReservationId)
                .ForeignKey("dbo.Period", t => t.PeriodId)
                .Index(t => t.ReservationId)
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
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.Int(),
                        CarId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Car", t => t.CarId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.CarId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 500),
                        SecurityStamp = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 50),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPhoto",
                c => new
                    {
                        UserPhotoId = c.String(nullable: false, maxLength: 128),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.UserPhotoId)
                .ForeignKey("dbo.User", t => t.UserPhotoId)
                .Index(t => t.UserPhotoId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserPhoto", "UserPhotoId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "CarId", "dbo.Car");
            DropForeignKey("dbo.Reservation", "PeriodId", "dbo.Period");
            DropForeignKey("dbo.Reservation", "ReservationId", "dbo.Car");
            DropForeignKey("dbo.PortfolioPhoto", "PortfolioPhotoId", "dbo.Portfolio");
            DropForeignKey("dbo.Car", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.CarPhoto", "CarPhotoId", "dbo.Car");
            DropForeignKey("dbo.CarGallery", "CarId", "dbo.Car");
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserPhoto", new[] { "UserPhotoId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Review", new[] { "User_Id" });
            DropIndex("dbo.Review", new[] { "CarId" });
            DropIndex("dbo.Reservation", new[] { "PeriodId" });
            DropIndex("dbo.Reservation", new[] { "ReservationId" });
            DropIndex("dbo.PortfolioPhoto", new[] { "PortfolioPhotoId" });
            DropIndex("dbo.CarPhoto", new[] { "CarPhotoId" });
            DropIndex("dbo.Car", new[] { "PortfolioId" });
            DropIndex("dbo.CarGallery", new[] { "CarId" });
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserPhoto");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Review");
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
