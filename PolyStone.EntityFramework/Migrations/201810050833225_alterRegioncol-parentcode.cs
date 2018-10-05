namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterRegioncolparentcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "ParentCode", c => c.String(unicode: false));
            DropColumn("dbo.Region", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Region", "ParentId", c => c.Int(nullable: false));
            DropColumn("dbo.Region", "ParentCode");
        }
    }
}
