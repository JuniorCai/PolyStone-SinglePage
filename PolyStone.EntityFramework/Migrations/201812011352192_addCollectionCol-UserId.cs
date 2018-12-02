namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCollectionColUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collection", "UserId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Collection", "UserId");
        }
    }
}
