namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRegionColFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "FullName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "FullName");
        }
    }
}
