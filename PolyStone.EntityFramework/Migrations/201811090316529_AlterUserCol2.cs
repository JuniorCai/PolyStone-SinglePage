namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserCol2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AbpUsers", "Surname");
            DropColumn("dbo.AbpUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "Name", c => c.String(maxLength: 64, storeType: "nvarchar"));
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(maxLength: 64, storeType: "nvarchar"));
        }
    }
}
