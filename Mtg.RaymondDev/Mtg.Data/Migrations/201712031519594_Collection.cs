namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Collection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "CollectionCards",
                c => new
                    {
                        Collection_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Collection_Id, t.Card_Id })
                .ForeignKey("Collections", t => t.Collection_Id, cascadeDelete: true)
                .ForeignKey("Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.Collection_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Collections", "User_Id", "Users");
            DropForeignKey("CollectionCards", "Card_Id", "Cards");
            DropForeignKey("CollectionCards", "Collection_Id", "Collections");
            DropIndex("CollectionCards", new[] { "Card_Id" });
            DropIndex("CollectionCards", new[] { "Collection_Id" });
            DropIndex("Collections", new[] { "User_Id" });
            DropTable("CollectionCards");
            DropTable("Collections");
        }
    }
}
