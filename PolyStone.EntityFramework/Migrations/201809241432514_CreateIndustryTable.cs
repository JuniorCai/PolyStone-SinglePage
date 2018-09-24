namespace PolyStone.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIndustryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyIndustry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        IndustryId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                        Company_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyIndustry_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Industry", t => t.IndustryId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.IndustryId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(maxLength: 50, storeType: "nvarchar"),
                        IndustryCode = c.String(maxLength: 10, storeType: "nvarchar"),
                        ParentCode = c.Int(nullable: false),
                        Sort = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
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
                    { "DynamicFilter_Industry_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "ShortName", c => c.String(unicode: false));
            CreateIndex("dbo.Company", "RegionId");
            AddForeignKey("dbo.Company", "RegionId", "dbo.Region", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Company", "RegionId", "dbo.Region");
            DropForeignKey("dbo.CompanyIndustry", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.CompanyIndustry", "IndustryId", "dbo.Industry");
            DropForeignKey("dbo.CompanyIndustry", "CompanyId", "dbo.Company");
            DropIndex("dbo.CompanyIndustry", new[] { "Company_Id" });
            DropIndex("dbo.CompanyIndustry", new[] { "IndustryId" });
            DropIndex("dbo.CompanyIndustry", new[] { "CompanyId" });
            DropIndex("dbo.Company", new[] { "RegionId" });
            DropColumn("dbo.Company", "ShortName");
            DropTable("dbo.Industry",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Industry_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyIndustry",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyIndustry_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
