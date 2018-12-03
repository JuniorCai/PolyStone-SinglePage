namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Collection", "RelativeId");
            AddForeignKey("dbo.Collection", "RelativeId", "dbo.Community", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Collection", "RelativeId", "dbo.Company", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Collection", "RelativeId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collection", "RelativeId", "dbo.Product");
            DropForeignKey("dbo.Collection", "RelativeId", "dbo.Company");
            DropForeignKey("dbo.Collection", "RelativeId", "dbo.Community");
            DropIndex("dbo.Collection", new[] { "RelativeId" });
        }
    }
}
