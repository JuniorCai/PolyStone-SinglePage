                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using PolyStone.CustomDomain.CompanyContacts;
   using PolyStone.EntityFramework;

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
// Copyright © YoYoCms@China.2018-08-02T16:45:08. All Rights Reserved.
//<生成时间>2018-08-02T16:45:08</生成时间>
	#endregion
namespace PolyStone.CustomDomain.CompanyContacts.EntityMapper.CompanyContacts
{

    /// <summary>
    /// 企业联系表的数据配置文件
    /// </summary>
    public class ContactCfg : EntityTypeConfiguration<Contact>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public ContactCfg()
        {
            ToTable("Contact", PolyStoneConsts.SchemaName.Basic);


            // 联系人姓名
            Property(a => a.LinkMan).HasMaxLength(20);
            // 手机号码
            Property(a => a.Phone).HasMaxLength(20);
            // 电话
            Property(a => a.Tel).HasMaxLength(20);
            // 传真
            Property(a => a.Fax).HasMaxLength(20);
            // 邮编
            Property(a => a.Email).HasMaxLength(50);
        }
    }
}