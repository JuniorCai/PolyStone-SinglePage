namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCompanyApplicationCol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyApplication", "License", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyApplication", "FrontImg", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyApplication", "BackImg", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyApplication", "BackImg", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyApplication", "FrontImg", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyApplication", "License", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
