using System.Data.Entity.ModelConfiguration;
using PolyStone.CustomDomain.Communities;

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
// Copyright © YoYoCms@China.2018-08-01T14:47:46. All Rights Reserved.
//<生成时间>2018-08-01T14:47:46</生成时间>
	#endregion
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
            Property(a => a.PictureUrls).HasMaxLength(1000);
            // 描述
            Property(a => a.Detail).HasMaxLength(1000);
        }
    }
}