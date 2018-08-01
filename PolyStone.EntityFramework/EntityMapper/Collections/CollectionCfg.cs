using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Collections;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.Collections
{

    /// <summary>
    /// 用户收藏的数据配置文件
    /// </summary>
    public class CollectionCfg : EntityTypeConfiguration<Collection>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CollectionCfg()
        {
            ToTable("Collection", PolyStoneConsts.SchemaName.Basic);

            // Name
            Property(a => a.Name).HasMaxLength(200);
        }
    }
}