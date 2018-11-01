namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserColAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "Avatar", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "Avatar");
        }
    }
}
