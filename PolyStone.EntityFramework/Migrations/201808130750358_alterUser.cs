namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "NickName", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AddColumn("dbo.AbpUsers", "UserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "UserType");
            DropColumn("dbo.AbpUsers", "NickName");
        }
    }
}
