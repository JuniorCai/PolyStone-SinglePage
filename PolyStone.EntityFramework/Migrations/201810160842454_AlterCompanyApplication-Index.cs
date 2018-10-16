namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCompanyApplicationIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyApplication", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.CompanyApplication", "UserId");
            CreateIndex("dbo.CompanyApplication", "RegionId");
            AddForeignKey("dbo.CompanyApplication", "RegionId", "dbo.Region", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyApplication", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyApplication", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.CompanyApplication", "RegionId", "dbo.Region");
            DropIndex("dbo.CompanyApplication", new[] { "RegionId" });
            DropIndex("dbo.CompanyApplication", new[] { "UserId" });
            DropColumn("dbo.CompanyApplication", "UserId");
        }
    }
}
