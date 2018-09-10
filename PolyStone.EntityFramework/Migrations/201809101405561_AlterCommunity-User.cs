namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCommunityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Community", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.Community", "UserId");
            AddForeignKey("dbo.Community", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            //DropColumn("dbo.Community", "MemberId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Community", "MemberId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Community", "UserId", "dbo.AbpUsers");
            DropIndex("dbo.Community", new[] { "UserId" });
            DropColumn("dbo.Community", "UserId");
        }
    }
}
