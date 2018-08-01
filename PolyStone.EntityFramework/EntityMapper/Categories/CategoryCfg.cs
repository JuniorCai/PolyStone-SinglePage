using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Categories;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.Categories
{

    /// <summary>
    /// 产品类目的数据配置文件
    /// </summary>
    public class CategoryCfg : EntityTypeConfiguration<Category>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CategoryCfg()
        {
            ToTable("Category", PolyStoneConsts.SchemaName.Basic);

            // 类目名称
            Property(a => a.CategoryName).HasMaxLength(50);
            // 类目简称
            Property(a => a.ShortName).HasMaxLength(50);
        }
    }
}