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
 

		    // CompanyName
			Property(a => a.CompanyName).HasMaxLength(4000);
		    // Bussiness
			Property(a => a.Bussiness).HasMaxLength(500);
		    // Introduction
			Property(a => a.Introduction).HasMaxLength(2000);
		}
    }
}