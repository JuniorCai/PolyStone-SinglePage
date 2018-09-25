using System;
using System.Collections.Generic;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.Products;

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
// Copyright © YoYoCms@China.2018-08-02T16:25:40. All Rights Reserved.
//<生成时间>2018-08-02T16:25:40</生成时间>
	#endregion
namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Company))]
    public class CompanyListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业LOGO
        /// </summary>
        [DisplayName("企业LOGO")]
        public string Logo { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        [DisplayName("企业类型")]
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// 企业类型(枚举描述)
        /// </summary>
        public string CompanyTypeName { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [DisplayName("会员ID")]
        public int MemberId { get; set; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        [DisplayName("是否已认证")]
        public bool IsAuthed { get; set; }

        /// <summary>
        /// 主营范围
        /// </summary>
        [DisplayName("主营范围")]
        public string Bussiness { get; set; }

        /// <summary>
        /// 企业简介
        /// </summary>
        [DisplayName("企业简介")]
        public string Introduction { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        [DisplayName("地区ID")]
        public int RegionId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool IsActive { get; set; }


        /// <summary>
        /// 企业地址
        /// </summary>
        [DisplayName("企业地址")]
        public string Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<CompanyIndustry> Industries { get; set; }

    }
}
