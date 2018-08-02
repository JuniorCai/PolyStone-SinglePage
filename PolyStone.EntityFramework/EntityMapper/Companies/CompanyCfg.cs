using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Companies;


namespace PolyStone.EntityMapper.Companies
{

	/// <summary>
    /// 企业表的数据配置文件
    /// </summary>
    public class CompanyCfg : EntityTypeConfiguration<Company>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
		public CompanyCfg ()
		{
		            ToTable("Company", PolyStoneConsts.SchemaName.Basic);


		    // 企业LOGO
		    Property(a => a.Logo).HasMaxLength(50);
		    // 企业名称
		    Property(a => a.CompanyName).HasMaxLength(50);
		    // 主营范围
		    Property(a => a.Bussiness).HasMaxLength(200);
		    // 企业简介
		    Property(a => a.Introduction).HasMaxLength(2000);
		    // 企业地址
		    Property(a => a.Address).HasMaxLength(100);
        }
    }
}