namespace PolyStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRegion : DbMigration
    {
        public override void Up()
        {
//            DropForeignKey("dbo.Region", "ParentId", "dbo.Region");
//            DropIndex("dbo.Region", new[] { "ParentId" });
        }
        
        public override void Down()
        {
            //CreateIndex("dbo.Region", "ParentId");
            //AddForeignKey("dbo.Region", "ParentId", "dbo.Region", "Id");
        }
    }
}
