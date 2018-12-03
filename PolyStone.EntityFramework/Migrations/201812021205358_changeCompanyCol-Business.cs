namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCompanyColBusiness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Business", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Company", "Bussiness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "Bussiness", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Company", "Business");
        }
    }
}
