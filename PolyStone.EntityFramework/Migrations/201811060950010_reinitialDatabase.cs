namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinitialDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserVerify", "Purpose", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserVerify", "Purpose");
        }
    }
}
