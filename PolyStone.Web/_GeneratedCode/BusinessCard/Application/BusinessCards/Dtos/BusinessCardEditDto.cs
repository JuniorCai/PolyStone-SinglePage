                          
  
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using PolyStone.CustomDomain.BusinessCard;
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
// Copyright © YoYoCms@China.2018-11-28T10:34:52. All Rights Reserved.
//<生成时间>2018-11-28T10:34:52</生成时间>
	#endregion
namespace PolyStone.CustomDomain.BusinessCard.Dtos
{
    /// <summary>
    /// 名片编辑用Dto
    /// </summary>
    [AutoMap(typeof(BusinessCard))]
    public class BusinessCardEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        [Required]
        public   long  UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public   string  WxNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public   string  CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public   string  Position { get; set; }

        [Required]
        [MaxLength(1000)]
        public   string  Introduction { get; set; }

    }
}
