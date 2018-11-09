namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserCol4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(maxLength: 64, storeType: "nvarchar"));
            AddColumn("dbo.AbpUsers", "Name", c => c.String(maxLength: 64, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "Name");
            DropColumn("dbo.AbpUsers", "Surname");
        }
    }
}
