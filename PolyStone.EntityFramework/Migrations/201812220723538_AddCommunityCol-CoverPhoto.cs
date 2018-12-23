namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommunityColCoverPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Community", "CoverPhoto", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Community", "CoverPhoto");
        }
    }
}
