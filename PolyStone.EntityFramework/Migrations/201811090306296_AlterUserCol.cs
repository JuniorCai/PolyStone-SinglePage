namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserCol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(maxLength: 64, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(maxLength: 64, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 64, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 64, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(nullable: false, maxLength: 256, storeType: "nvarchar"));
        }
    }
}
