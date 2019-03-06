namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCompanyColbannersviewTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "ViewTimes", c => c.Int(nullable: false));
            AddColumn("dbo.Company", "Banners", c => c.String(maxLength: 1000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Banners");
            DropColumn("dbo.Company", "ViewTimes");
        }
    }
}
