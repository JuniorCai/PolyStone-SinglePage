namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCompanyUserIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Company", "UserId");
            AddForeignKey("dbo.Company", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Company", "UserId", "dbo.AbpUsers");
            DropIndex("dbo.Company", new[] { "UserId" });
        }
    }
}
