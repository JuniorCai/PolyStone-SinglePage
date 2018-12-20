namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommunityColRegionCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Community", "RegionCode", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.Community", "RegionCode");
            AddForeignKey("dbo.Community", "RegionCode", "dbo.Region", "RegionCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Community", "RegionCode", "dbo.Region");
            DropIndex("dbo.Community", new[] { "RegionCode" });
            DropColumn("dbo.Community", "RegionCode");
        }
    }
}
