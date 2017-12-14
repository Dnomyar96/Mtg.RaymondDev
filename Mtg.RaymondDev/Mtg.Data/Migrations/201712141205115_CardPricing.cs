namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardPricing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardPricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardPricings", "Card_Id", "dbo.Cards");
            DropIndex("dbo.CardPricings", new[] { "Card_Id" });
            DropTable("dbo.CardPricings");
        }
    }
}
