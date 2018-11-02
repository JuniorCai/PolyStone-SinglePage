namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReInitialDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 64, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 64, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 256, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
        }
    }
}
