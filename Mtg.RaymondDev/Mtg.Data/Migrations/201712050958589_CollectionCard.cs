namespace Mtg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionCard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("CollectionCards", "Collection_Id", "Collections");
            DropForeignKey("CollectionCards", "Card_Id", "Cards");
            DropIndex("CollectionCards", new[] { "Collection_Id" });
            DropIndex("CollectionCards", new[] { "Card_Id" });
            DropPrimaryKey("CollectionCards");
            AddColumn("Collections", "Name", c => c.String(unicode: false));
            AddColumn("Collections", "Type", c => c.Int(nullable: false));
            AddColumn("CollectionCards", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("CollectionCards", "Amount", c => c.Int(nullable: false));
            AlterColumn("CollectionCards", "Collection_Id", c => c.Int());
            AlterColumn("CollectionCards", "Card_Id", c => c.Int());
            AddPrimaryKey("CollectionCards", "Id");
            CreateIndex("CollectionCards", "Card_Id");
            CreateIndex("CollectionCards", "Collection_Id");
            AddForeignKey("CollectionCards", "Collection_Id", "Collections", "Id");
            AddForeignKey("CollectionCards", "Card_Id", "Cards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("CollectionCards", "Card_Id", "Cards");
            DropForeignKey("CollectionCards", "Collection_Id", "Collections");
            DropIndex("CollectionCards", new[] { "Collection_Id" });
            DropIndex("CollectionCards", new[] { "Card_Id" });
            DropPrimaryKey("CollectionCards");
            AlterColumn("CollectionCards", "Card_Id", c => c.Int(nullable: false));
            AlterColumn("CollectionCards", "Collection_Id", c => c.Int(nullable: false));
            DropColumn("CollectionCards", "Amount");
            DropColumn("CollectionCards", "Id");
            DropColumn("Collections", "Type");
            DropColumn("Collections", "Name");
            AddPrimaryKey("CollectionCards", new[] { "Collection_Id", "Card_Id" });
            CreateIndex("CollectionCards", "Card_Id");
            CreateIndex("CollectionCards", "Collection_Id");
            AddForeignKey("CollectionCards", "Card_Id", "Cards", "Id", cascadeDelete: true);
            AddForeignKey("CollectionCards", "Collection_Id", "Collections", "Id", cascadeDelete: true);
        }
    }
}
