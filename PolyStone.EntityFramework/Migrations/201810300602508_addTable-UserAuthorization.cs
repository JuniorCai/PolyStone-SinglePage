namespace PolyStone.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addTableUserAuthorization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAuthorization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenId = c.String(maxLength: 100, storeType: "nvarchar"),
                        UserId = c.Long(nullable: false),
                        ThirdName = c.String(maxLength: 100, storeType: "nvarchar"),
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
                    { "DynamicFilter_UserAuthorization_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAuthorization",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAuthorization_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
