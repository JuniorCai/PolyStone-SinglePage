using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Abp.Zero.EntityFramework;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.CustomDomain.BusinessCard;
using PolyStone.CustomDomain.Categories;
using PolyStone.CustomDomain.Collections;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.CommunityCategories;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyApplications;
using PolyStone.CustomDomain.CompanyAuths;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.Members;
using PolyStone.CustomDomain.Modules;
using PolyStone.CustomDomain.Products;
using PolyStone.CustomDomain.Regions;
using PolyStone.CustomDomain.UserAuthorizations;
using PolyStone.CustomDomain.UserVerifies;
using PolyStone.EntityMapper.BusinessCards;
using PolyStone.EntityMapper.Categories;
using PolyStone.EntityMapper.Collections;
using PolyStone.EntityMapper.Communities;
using PolyStone.EntityMapper.CommunityCategories;
using PolyStone.EntityMapper.Companies;
using PolyStone.EntityMapper.CompanyApplications;
using PolyStone.EntityMapper.CompanyAuthes;
using PolyStone.EntityMapper.CompanyContacts;
using PolyStone.EntityMapper.CompanyIndustries;
using PolyStone.EntityMapper.Industries;
using PolyStone.EntityMapper.Members;
using PolyStone.EntityMapper.Modules;
using PolyStone.EntityMapper.Products;
using PolyStone.EntityMapper.Regions;
using PolyStone.EntityMapper.UserAuthorizations;
using PolyStone.EntityMapper.UserVerifies;
using PolyStone.MultiTenancy;

namespace PolyStone.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PolyStoneDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Collection> Collections { get; set; }
        public IDbSet<Community> Communitys { get; set; }

        public IDbSet<Member> Members { get; set; }

        public IDbSet<Category> Categorys { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Company> Companys { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<CommunityCategory> CommunityCategorys { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<CompanyAuth> CompanyAuths { get; set; }
        public IDbSet<CompanyApplication> CompanyApplications { get; set; }
        public IDbSet<Industry> Industrys { get; set; }

        public IDbSet<CompanyIndustry> CompanyIndustrys { get; set; }
        public IDbSet<Module> Modules { get; set; }
        public IDbSet<UserVerify> UserVerifys { get; set; }

        public IDbSet<UserAuthorization> UserAuthorizations { get; set; }
        public IDbSet<BusinessCard> BusinessCards { get; set; }



        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public PolyStoneDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in PolyStoneDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of PolyStoneDbContext since ABP automatically handles it.
         */
        public PolyStoneDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public PolyStoneDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public PolyStoneDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CollectionCfg());
            modelBuilder.Configurations.Add(new CommunityCfg());
            modelBuilder.Configurations.Add(new MemberCfg());
            modelBuilder.Configurations.Add(new CategoryCfg());
            modelBuilder.Configurations.Add(new ProductCfg());
            modelBuilder.Configurations.Add(new CompanyCfg());
            modelBuilder.Configurations.Add(new RegionCfg());
            modelBuilder.Configurations.Add(new CommunityCategoryCfg());
            modelBuilder.Configurations.Add(new ContactCfg());
            modelBuilder.Configurations.Add(new CompanyAuthCfg());
            modelBuilder.Configurations.Add(new CompanyApplicationCfg());
            modelBuilder.Configurations.Add(new CompanyIndustryCfg());
            modelBuilder.Configurations.Add(new IndustryCfg());
            modelBuilder.Configurations.Add(new ModuleCfg());
            modelBuilder.Configurations.Add(new UserAuthorizationCfg());
            modelBuilder.Configurations.Add(new UserVerifyCfg());
            modelBuilder.Configurations.Add(new BusinessCardCfg());

            modelBuilder.Entity<User>().Property(a=>a.EmailAddress).IsOptional();
            modelBuilder.Entity<User>().Ignore(a => a.Surname);
            modelBuilder.Entity<User>().Property(a => a.Name).IsOptional();


            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var errorMessages =
                    exception.EntityValidationErrors
                        .SelectMany(validationResult => validationResult.ValidationErrors)
                        .Select(m => m.ErrorMessage);

                var fullErrorMessage = string.Join(", ", errorMessages);
                //记录日志
                //Log.Error(fullErrorMessage);
                var exceptionMessage = string.Concat(exception.Message, " 验证异常消息是：", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, exception.EntityValidationErrors);
            }

            //其他异常throw到上层
        }
    }
}
