using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using PolyStone.Authorization;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.Configuration;
using PolyStone.CustomDomain.Categories.Authorization;
using PolyStone.CustomDomain.Collections.Authorization;
using PolyStone.CustomDomain.Communities.Authorization;
using PolyStone.CustomDomain.Companies.Authorization;
using PolyStone.CustomDomain.Members.Authorization;
using PolyStone.CustomDomain.Products.Authorization;
using PolyStone.MultiTenancy;

namespace PolyStone
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class PolyStoneCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = PolyStoneConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    PolyStoneConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "PolyStone.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<PolyStoneAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<MemberAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CommunityAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CollectionAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CategoryAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ProductAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CompanyAppAuthorizationProvider>();
            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
