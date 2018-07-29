namespace RentACar_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateReservationModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "CarId", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "CarId" });
            RenameColumn(table: "dbo.Reservations", name: "CarId", newName: "Car_CarId");
            AlterColumn("dbo.Reservations", "Car_CarId", c => c.Int());
            CreateIndex("dbo.Reservations", "Car_CarId");
            AddForeignKey("dbo.Reservations", "Car_CarId", "dbo.Cars", "CarId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Car_CarId", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "Car_CarId" });
            AlterColumn("dbo.Reservations", "Car_CarId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reservations", name: "Car_CarId", newName: "CarId");
            CreateIndex("dbo.Reservations", "CarId");
            AddForeignKey("dbo.Reservations", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
    }
}
