namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterRegionColSort : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Region", "Sort");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Region", "Sort", c => c.Int(nullable: false));
        }
    }
}
