namespace RentACar.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Cars", new[] { "Portfolio_PortfolioId" });
            RenameColumn(table: "dbo.Cars", name: "Portfolio_PortfolioId", newName: "PortfolioId");
            AlterColumn("dbo.Cars", "PortfolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "PortfolioId");
            AddForeignKey("dbo.Cars", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Cars", new[] { "PortfolioId" });
            AlterColumn("dbo.Cars", "PortfolioId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "PortfolioId", newName: "Portfolio_PortfolioId");
            CreateIndex("dbo.Cars", "Portfolio_PortfolioId");
            AddForeignKey("dbo.Cars", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
    }
}
