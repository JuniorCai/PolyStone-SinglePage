namespace PolyStone.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addBusinessCardTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        WxNumber = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CompanyName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Position = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Introduction = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
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
                    { "DynamicFilter_BusinessCard_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessCard",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BusinessCard_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
