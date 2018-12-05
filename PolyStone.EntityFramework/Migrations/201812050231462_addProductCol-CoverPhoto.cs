namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductColCoverPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CoverPhoto", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CoverPhoto");
        }
    }
}
