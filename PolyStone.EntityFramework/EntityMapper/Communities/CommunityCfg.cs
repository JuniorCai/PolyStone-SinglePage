using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Communities;


namespace PolyStone.EntityMapper.Communities
{

    /// <summary>
    /// 圈子信息表的数据配置文件
    /// </summary>
    public class CommunityCfg : EntityTypeConfiguration<Community>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
        public CommunityCfg()
        {
            ToTable("Community", PolyStoneConsts.SchemaName.Basic);


            // 标题
            Property(a => a.Title).HasMaxLength(200);
            // 图片URL集合
            Property(a => a.ImgUrls).HasMaxLength(1000);
            // 描述
            Property(a => a.Detail).HasMaxLength(1000);

            HasRequired(c => c.CommunityCategory).WithMany(c => c.Communities)
                .HasForeignKey(c => c.CommunityCategoryId);
        }
    }
}