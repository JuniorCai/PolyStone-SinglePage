namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCommunityRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Community", "CommunityCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Community", "CommunityCategoryId");
            AddForeignKey("dbo.Community", "CommunityCategoryId", "dbo.CommunityCategory", "Id", cascadeDelete: true);
            DropColumn("dbo.Community", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Community", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Community", "CommunityCategoryId", "dbo.CommunityCategory");
            DropIndex("dbo.Community", new[] { "CommunityCategoryId" });
            DropColumn("dbo.Community", "CommunityCategoryId");
        }
    }
}
