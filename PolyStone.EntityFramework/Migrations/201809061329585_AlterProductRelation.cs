namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProductRelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "CategoryId");
            CreateIndex("dbo.Product", "CompanyId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "CompanyId", "dbo.Company", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CompanyId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
        }
    }
}
