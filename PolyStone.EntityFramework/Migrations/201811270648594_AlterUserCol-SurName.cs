namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserColSurName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AbpUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(maxLength: 64, storeType: "nvarchar"));
        }
    }
}
