namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCategoryIndustryCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "IndustryCode", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "IndustryCode", c => c.Int(nullable: false));
        }
    }
}
