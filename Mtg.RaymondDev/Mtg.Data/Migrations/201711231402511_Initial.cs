namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Cards",
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
                .ForeignKey("Sets", t => t.Set_Id)
                .Index(t => t.Set_Id);
            
            CreateTable(
                "ForeignNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        MultiverseId = c.Int(nullable: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "Legalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Format = c.String(unicode: false),
                        LegalityDetail = c.String(unicode: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "Rulings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Text = c.String(unicode: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "Sets",
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
            DropForeignKey("Cards", "Set_Id", "Sets");
            DropForeignKey("Rulings", "Card_Id", "Cards");
            DropForeignKey("Legalities", "Card_Id", "Cards");
            DropForeignKey("ForeignNames", "Card_Id", "Cards");
            DropIndex("Rulings", new[] { "Card_Id" });
            DropIndex("Legalities", new[] { "Card_Id" });
            DropIndex("ForeignNames", new[] { "Card_Id" });
            DropIndex("Cards", new[] { "Set_Id" });
            DropTable("Sets");
            DropTable("Rulings");
            DropTable("Legalities");
            DropTable("ForeignNames");
            DropTable("Cards");
        }
    }
}
