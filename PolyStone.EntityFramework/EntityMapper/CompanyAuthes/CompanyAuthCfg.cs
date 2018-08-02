using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.CompanyAuths;
using PolyStone.EntityFramework;


namespace PolyStone.EntityMapper.CompanyAuthes
{

    /// <summary>
    /// 企业资质表的数据配置文件
    /// </summary>
    public class CompanyAuthCfg : EntityTypeConfiguration<CompanyAuth>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CompanyAuthCfg()
        {
            ToTable("CompanyAuth", PolyStoneConsts.SchemaName.Basic);



            // 法人姓名
            Property(a => a.LegalPerson).HasMaxLength(50);
            // 法人身份证正面
            Property(a => a.FrontImg).HasMaxLength(50);
            // 法人身份证反面
            Property(a => a.BackImg).HasMaxLength(50);
            // 营业执照
            Property(a => a.License).HasMaxLength(50);
        }
    }
}