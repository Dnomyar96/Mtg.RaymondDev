namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Collection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CollectionCards",
                c => new
                    {
                        Collection_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Collection_Id, t.Card_Id })
                .ForeignKey("dbo.Collections", t => t.Collection_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.Collection_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CollectionCards", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.CollectionCards", "Collection_Id", "dbo.Collections");
            DropIndex("dbo.CollectionCards", new[] { "Card_Id" });
            DropIndex("dbo.CollectionCards", new[] { "Collection_Id" });
            DropIndex("dbo.Collections", new[] { "User_Id" });
            DropTable("dbo.CollectionCards");
            DropTable("dbo.Collections");
        }
    }
}
