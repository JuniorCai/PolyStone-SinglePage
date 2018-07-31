                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using PolyStone.CustomDomain.Members;
 #region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2018-07-31T21:32:08. All Rights Reserved.
//<生成时间>2018-07-31T21:32:08</生成时间>
	#endregion
namespace PolyStone.CustomDomain.Members.EntityMapper.Members
{

	/// <summary>
    /// 个人会员信息表的数据配置文件
    /// </summary>
    public class MemberCfg : EntityTypeConfiguration<Member>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
		public MemberCfg ()
		{
		            ToTable("Member", PolyStoneConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到CustomDomainDbContext中

  //		public IDbSet<Member> Members { get; set; }
   //		 modelBuilder.Configurations.Add(new MemberCfg());




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