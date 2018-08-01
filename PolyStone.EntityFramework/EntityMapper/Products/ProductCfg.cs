using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Products;

namespace PolyStone.EntityMapper.Products
{

    /// <summary>
    /// 产品表的数据配置文件
    /// </summary>
    public class ProductCfg : EntityTypeConfiguration<Product>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
        public ProductCfg()
        {
            ToTable("Product", PolyStoneConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到CustomDomainDbContext中





            // 标题
            Property(a => a.Title).HasMaxLength(200);
            // ImgUrls
            Property(a => a.ImgUrls).HasMaxLength(1000);
            // Detail
            Property(a => a.Detail).HasMaxLength(1000);
        }
    }
}