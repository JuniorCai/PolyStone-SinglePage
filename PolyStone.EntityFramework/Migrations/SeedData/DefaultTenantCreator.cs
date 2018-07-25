using System.Linq;
using PolyStone.EntityFramework;
using PolyStone.MultiTenancy;

namespace PolyStone.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PolyStoneDbContext _context;

        public DefaultTenantCreator(PolyStoneDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
