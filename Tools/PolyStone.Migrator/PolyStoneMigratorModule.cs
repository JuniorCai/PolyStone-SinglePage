using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using PolyStone.EntityFramework;

namespace PolyStone.Migrator
{
    [DependsOn(typeof(PolyStoneDataModule))]
    public class PolyStoneMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<PolyStoneDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}