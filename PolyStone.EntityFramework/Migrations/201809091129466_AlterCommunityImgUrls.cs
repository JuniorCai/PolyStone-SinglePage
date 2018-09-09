namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCommunityImgUrls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Community", "ImgUrls", c => c.String(maxLength: 1000, storeType: "nvarchar"));
            DropColumn("dbo.Community", "PictureUrls");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Community", "PictureUrls", c => c.String(maxLength: 1000, storeType: "nvarchar"));
            DropColumn("dbo.Community", "ImgUrls");
        }
    }
}
