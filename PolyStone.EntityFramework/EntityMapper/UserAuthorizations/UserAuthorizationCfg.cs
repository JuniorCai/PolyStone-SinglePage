using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.UserAuthorizations;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.UserAuthorizations
{

    /// <summary>
    /// 用户第三方绑定的数据配置文件
    /// </summary>
    public class UserAuthorizationCfg : EntityTypeConfiguration<UserAuthorization>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public UserAuthorizationCfg()
        {
            ToTable("UserAuthorization", PolyStoneConsts.SchemaName.Basic);






            // 第三方唯一标识
            Property(a => a.OpenId).HasMaxLength(100);
            // 第三方名称
            Property(a => a.ThirdName).HasMaxLength(100);
        }
    }
}
