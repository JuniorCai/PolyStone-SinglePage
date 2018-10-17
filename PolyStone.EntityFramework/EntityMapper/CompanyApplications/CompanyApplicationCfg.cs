using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.CompanyApplications;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.CompanyApplications
{

    /// <summary>
    /// 个人会员升级企业申请表的数据配置文件
    /// </summary>
    public class CompanyApplicationCfg : EntityTypeConfiguration<CompanyApplication>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CompanyApplicationCfg()
        {
            ToTable("CompanyApplication", PolyStoneConsts.SchemaName.Basic);


            // 营业执照
            Property(a => a.License).HasMaxLength(100);
            // 法人姓名
            Property(a => a.LegalPerson).HasMaxLength(50);
            // 身份证正面照
            Property(a => a.FrontImg).HasMaxLength(100);
            // 身份证背面照
            Property(a => a.BackImg).HasMaxLength(100);
            // 企业名称
            Property(a => a.CompanyName).HasMaxLength(50);
            // 主营范围
            Property(a => a.Business).HasMaxLength(200);
            // 联系人姓名
            Property(a => a.LinkMan).HasMaxLength(20);
            // 手机号
            Property(a => a.Phone).HasMaxLength(20);
            // 电话号码
            Property(a => a.Tel).HasMaxLength(20);
            // 企业地址
            Property(a => a.Address).HasMaxLength(50);
        }
    }
}