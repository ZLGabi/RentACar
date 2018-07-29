namespace RentACar_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCarsDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Reservation_ReservationId", "dbo.Reservations");
            DropIndex("dbo.Cars", new[] { "Reservation_ReservationId" });
            AddColumn("dbo.Portfolios", "Name", c => c.String());
            CreateIndex("dbo.Reservations", "CarId");
            AddForeignKey("dbo.Reservations", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
            DropColumn("dbo.Cars", "Reservation_ReservationId");
            DropColumn("dbo.Portfolios", "CarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolios", "CarId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Reservation_ReservationId", c => c.Int());
            DropForeignKey("dbo.Reservations", "CarId", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "CarId" });
            DropColumn("dbo.Portfolios", "Name");
            CreateIndex("dbo.Cars", "Reservation_ReservationId");
            AddForeignKey("dbo.Cars", "Reservation_ReservationId", "dbo.Reservations", "ReservationId");
        }
    }
}
