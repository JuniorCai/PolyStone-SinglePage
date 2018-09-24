using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyIndustries;

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
// Copyright © YoYoCms@China.2018-09-24T17:06:36. All Rights Reserved.
//<生成时间>2018-09-24T17:06:36</生成时间>
	#endregion

namespace PolyStone.CompanyIndustries.Dtos
{
    /// <summary>
    /// 企业行业关系表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CompanyIndustry))]
    public class CompanyIndustryListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        public int CompanyId { get; set; }

        /// <summary>
        /// 企业信息
        /// </summary>
        [DisplayName("企业信息")]
        public Company Company { get; set; }

        /// <summary>
        /// 行业ID
        /// </summary>
        [DisplayName("行业ID")]
        public int IndustryId { get; set; }

        /// <summary>
        /// 行业信息
        /// </summary>
        [DisplayName("行业信息")]
        public Industry Industry { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
