using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Members;
using PolyStone.EntityFramework;


namespace PolyStone.EntityMapper.Members
{

    /// <summary>
    /// 个人会员信息表的数据配置文件
    /// </summary>
    public class MemberCfg : EntityTypeConfiguration<Member>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public MemberCfg()
        {
            ToTable("Member", PolyStoneConsts.SchemaName.Basic);



            // 用户名
            Property(a => a.AccountName).HasMaxLength(50);
            // 姓名
            Property(a => a.FullName).HasMaxLength(50);
            // 昵称
            Property(a => a.NickName).HasMaxLength(50);
            // 手机号
            Property(a => a.Phone).HasMaxLength(50);
            // 密码
            Property(a => a.Password).HasMaxLength(50);
        }
    }
}