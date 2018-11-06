using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.UserVerifies;
using PolyStone.EntityFramework;

namespace PolyStone.EntityMapper.UserVerifies
{

    /// <summary>
    /// 用户验证码的数据配置文件
    /// </summary>
    public class UserVerifyCfg : EntityTypeConfiguration<UserVerify>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public UserVerifyCfg()
        {
            ToTable("UserVerify", PolyStoneConsts.SchemaName.Basic);



            // 手机号
            Property(a => a.PhoneNumber).HasMaxLength(20);
            // 验证码
            Property(a => a.Code).HasMaxLength(10);
            // IP地址
            Property(a => a.Ip).HasMaxLength(4000);
        }
    }
}