namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCollectionName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "IndustryCode", c => c.Int(nullable: false));
            AddColumn("dbo.Collection", "Title", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Collection", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collection", "Name", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Collection", "Title");
            DropColumn("dbo.Category", "IndustryCode");
        }
    }
}
