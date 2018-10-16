namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeApplicationColNameAuthStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyApplication", "AuthStatus", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyApplication", "AuthStauts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyApplication", "AuthStauts", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyApplication", "AuthStatus");
        }
    }
}
