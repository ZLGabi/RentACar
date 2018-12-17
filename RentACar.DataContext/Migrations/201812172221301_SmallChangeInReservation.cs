namespace RentACar.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChangeInReservation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "FinalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "FinalPrice", c => c.Int(nullable: false));
        }
    }
}
