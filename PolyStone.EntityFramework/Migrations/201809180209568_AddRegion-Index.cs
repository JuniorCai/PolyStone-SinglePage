namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegionIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "RegionCode", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "RegionCode");
        }
    }
}
