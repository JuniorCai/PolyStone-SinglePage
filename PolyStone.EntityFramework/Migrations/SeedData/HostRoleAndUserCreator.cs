using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using PolyStone.Authorization;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.EntityFramework;
using Microsoft.AspNet.Identity;
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

namespace PolyStone.Migrations.SeedData
{
    public class HostRoleAndUserCreator
    {
        private readonly PolyStoneDbContext _context;

        public HostRoleAndUserCreator(PolyStoneDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            //Admin role for host

            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new PolyStoneAuthorizationProvider(), new CategoryAppAuthorizationProvider(),
                        new CollectionAppAuthorizationProvider(), new CommunityAppAuthorizationProvider(),
                        new CommunityCategoryAppAuthorizationProvider(), new CompanyAppAuthorizationProvider(),
                        new CompanyApplicationAppAuthorizationProvider(), new CompanyAuthAppAuthorizationProvider(),
                        new ContactAppAuthorizationProvider(), new ProductAppAuthorizationProvider(),
                        new RegionAppAuthorizationProvider(),new IndustryAppAuthorizationProvider(),
                        new CompanyIndustryAppAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin user for tenancy host

            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(
                    new User
                    {
                        UserName = User.AdminUserName,
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                _context.SaveChanges();
            }
        }
    }
}