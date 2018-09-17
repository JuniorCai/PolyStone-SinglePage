namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyColIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "IsActive");
        }
    }
}
