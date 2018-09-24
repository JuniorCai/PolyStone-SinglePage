using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.CompanyIndustries;

namespace PolyStone.EntityMapper.CompanyIndustries
{

    /// <summary>
    /// 企业行业关系表的数据配置文件
    /// </summary>
    public class CompanyIndustryCfg : EntityTypeConfiguration<CompanyIndustry>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CompanyIndustryCfg()
        {
            ToTable("CompanyIndustry", PolyStoneConsts.SchemaName.Basic);


            // 企业信息 - 关系映射
            HasRequired(a => a.Company).WithMany().HasForeignKey(c => c.CompanyId);
            // 行业信息 - 关系映射
            HasRequired(a => a.Industry).WithMany().HasForeignKey(c => c.IndustryId);
        }
    }
}