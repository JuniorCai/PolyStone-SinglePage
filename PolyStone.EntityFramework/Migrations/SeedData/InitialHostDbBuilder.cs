using PolyStone.EntityFramework;
using EntityFramework.DynamicFilters;

namespace PolyStone.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PolyStoneDbContext _context;

        public InitialHostDbBuilder(PolyStoneDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
