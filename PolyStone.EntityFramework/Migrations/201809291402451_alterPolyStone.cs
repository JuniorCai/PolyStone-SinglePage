namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterPolyStone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyAuth", "FrontImg", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyAuth", "BackImg", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyAuth", "License", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyAuth", "License", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyAuth", "BackImg", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.CompanyAuth", "FrontImg", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
