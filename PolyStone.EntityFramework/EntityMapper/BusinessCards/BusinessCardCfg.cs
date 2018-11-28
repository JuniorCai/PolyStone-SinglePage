using System.Data.Entity.ModelConfiguration;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.BusinessCards
{

	/// <summary>
    /// 名片的数据配置文件
    /// </summary>
    public class BusinessCardCfg : EntityTypeConfiguration<CustomDomain.BusinessCard.BusinessCard>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public BusinessCardCfg ()
		{
		            ToTable("BusinessCard", PolyStoneConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到CustomDomainDbContext中





		    // WxNumber
			Property(a => a.WxNumber).HasMaxLength(50);
		    // CompanyName
			Property(a => a.CompanyName).HasMaxLength(100);
		    // Position
			Property(a => a.Position).HasMaxLength(50);
		    // Introduction
			Property(a => a.Introduction).HasMaxLength(1000);
		}
    }
}