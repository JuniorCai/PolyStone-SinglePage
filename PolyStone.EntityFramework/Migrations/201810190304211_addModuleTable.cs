namespace PolyStone.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addModuleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleCode = c.String(maxLength: 10, storeType: "nvarchar"),
                        Name = c.String(maxLength: 20, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Collection", "ModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Collection", "ModuleId");
            AddForeignKey("dbo.Collection", "ModuleId", "dbo.Module", "Id", cascadeDelete: true);
            DropColumn("dbo.Collection", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collection", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Collection", "ModuleId", "dbo.Module");
            DropIndex("dbo.Collection", new[] { "ModuleId" });
            DropColumn("dbo.Collection", "ModuleId");
            DropTable("dbo.Module",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
