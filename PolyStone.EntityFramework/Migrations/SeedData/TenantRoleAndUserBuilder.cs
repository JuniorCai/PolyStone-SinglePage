using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using PolyStone.Authorization;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.CustomDomain.Categories.Authorization;
using PolyStone.CustomDomain.Collections.Authorization;
using PolyStone.CustomDomain.Communities.Authorization;
using PolyStone.CustomDomain.CommunityCategories.Authorization;
using PolyStone.CustomDomain.Companies.Authorization;
using PolyStone.CustomDomain.CompanyApplications.Authorization;
using PolyStone.CustomDomain.CompanyAuths.Authorization;
using PolyStone.CustomDomain.CompanyContacts.Authorization;
using PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries.Authorization;
using PolyStone.CustomDomain.CompanyIndustries.Industries.Authorization;
using PolyStone.CustomDomain.Products.Authorization;
using PolyStone.CustomDomain.Regions.Authorization;
using PolyStone.EntityFramework;

namespace PolyStone.Migrations.SeedData
{
    public class TenantRoleAndUserBuilder
    {
        private readonly PolyStoneDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(PolyStoneDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Admin role

            var adminRole = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true });
                _context.SaveChanges();

                //Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new PolyStoneAuthorizationProvider(), new CategoryAppAuthorizationProvider(),
                        new CollectionAppAuthorizationProvider(), new CommunityAppAuthorizationProvider(),
                        new CommunityCategoryAppAuthorizationProvider(), new CompanyAppAuthorizationProvider(),
                        new CompanyApplicationAppAuthorizationProvider(),new CompanyAuthAppAuthorizationProvider(),
                        new ContactAppAuthorizationProvider(),new ProductAppAuthorizationProvider(),
                        new RegionAppAuthorizationProvider(), new IndustryAppAuthorizationProvider(),
                        new CompanyIndustryAppAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRole.Id
                        });
                }

                _context.SaveChanges();
            }

            //admin user

            var adminUser = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com", User.DefaultPassword);
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                //Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }
    }
}