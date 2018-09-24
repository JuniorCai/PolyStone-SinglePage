using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.CompanyIndustries;

namespace PolyStone.EntityMapper.Industries
{

    /// <summary>
    /// 企业行业表的数据配置文件
    /// </summary>
    public class IndustryCfg : EntityTypeConfiguration<Industry>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public IndustryCfg()
        {
            ToTable("Industry", PolyStoneConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到CustomDomainDbContext中





            // 行业名称
            Property(a => a.IndustryName).HasMaxLength(50);
            // 编号
            Property(a => a.IndustryCode).HasMaxLength(10);
        }
    }
}