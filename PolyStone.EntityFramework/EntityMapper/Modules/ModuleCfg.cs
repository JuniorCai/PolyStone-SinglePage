using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Modules;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.Modules
{

    /// <summary>
    /// 模块表的数据配置文件
    /// </summary>
    public class ModuleCfg : EntityTypeConfiguration<Module>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public ModuleCfg()
        {
            ToTable("Module", PolyStoneConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到CustomDomainDbContext中





            // 编码
            Property(a => a.ModuleCode).HasMaxLength(10);
            // 名称
            Property(a => a.Name).HasMaxLength(20);
        }
    }
}