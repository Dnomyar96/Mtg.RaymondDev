namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardId = c.String(unicode: false),
                        Layout = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        ManaCost = c.String(unicode: false),
                        Cmc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(unicode: false),
                        Rarity = c.String(unicode: false),
                        Text = c.String(unicode: false),
                        Flavor = c.String(unicode: false),
                        Artist = c.String(unicode: false),
                        Number = c.String(unicode: false),
                        Power = c.String(unicode: false),
                        Toughness = c.String(unicode: false),
                        Loyalty = c.Int(),
                        MultiverseId = c.Int(nullable: false),
                        ImageName = c.String(unicode: false),
                        WaterMark = c.String(unicode: false),
                        Border = c.Int(nullable: false),
                        TimeShifted = c.Boolean(nullable: false),
                        Hand = c.Int(nullable: false),
                        Life = c.Int(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                        ReleaseDate = c.String(unicode: false),
                        Starter = c.Boolean(nullable: false),
                        MciNumber = c.String(unicode: false),
                        OriginalText = c.String(unicode: false),
                        OriginalType = c.String(unicode: false),
                        Source = c.String(unicode: false),
                        Set_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sets", t => t.Set_Id)
                .Index(t => t.Set_Id);
            
            CreateTable(
                "dbo.ForeignNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        MultiverseId = c.Int(nullable: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Legalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Format = c.String(unicode: false),
                        LegalityDetail = c.String(unicode: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Rulings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Text = c.String(unicode: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        GathererCode = c.String(unicode: false),
                        OldCode = c.String(unicode: false),
                        MagicCardsInfoCode = c.String(unicode: false),
                        ReleaseDate = c.DateTime(nullable: false, precision: 0),
                        Border = c.Int(nullable: false),
                        Type = c.String(unicode: false),
                        Block = c.String(unicode: false),
                        OnlineOnly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Set_Id", "dbo.Sets");
            DropForeignKey("dbo.Rulings", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Legalities", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.ForeignNames", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Rulings", new[] { "Card_Id" });
            DropIndex("dbo.Legalities", new[] { "Card_Id" });
            DropIndex("dbo.ForeignNames", new[] { "Card_Id" });
            DropIndex("dbo.Cards", new[] { "Set_Id" });
            DropTable("dbo.Sets");
            DropTable("dbo.Rulings");
            DropTable("dbo.Legalities");
            DropTable("dbo.ForeignNames");
            DropTable("dbo.Cards");
        }
    }
}
