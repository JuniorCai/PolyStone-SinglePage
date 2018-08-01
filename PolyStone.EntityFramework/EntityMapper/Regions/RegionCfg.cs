using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Regions;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.Regions
{

    /// <summary>
    /// 地区表的数据配置文件
    /// </summary>
    public class RegionCfg : EntityTypeConfiguration<Region>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public RegionCfg()
        {
            ToTable("Region", PolyStoneConsts.SchemaName.Basic);

            // 地区名称
            Property(a => a.RegionName).HasMaxLength(50);
        }
    }
}