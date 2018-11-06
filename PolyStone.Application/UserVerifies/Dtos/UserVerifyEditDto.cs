using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.UserVerifies;

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
// Copyright © YoYoCms@China.2018-11-06T10:28:19. All Rights Reserved.
//<生成时间>2018-11-06T10:28:19</生成时间>
	#endregion
namespace PolyStone.UserVerifies.Dtos
{
    /// <summary>
    /// 用户验证码编辑用Dto
    /// </summary>
    [AutoMap(typeof(UserVerify))]
    public class UserVerifyEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName("手机号")]
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [DisplayName("验证码")]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        [DisplayName("验证码类型")]
        [Required]
        public CodeType CodeType { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [DisplayName("IP地址")]
        public string Ip { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [DisplayName("失效时间")]
        [Required]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 验证状态
        /// </summary>
        [DisplayName("验证状态")]
        [Required]
        public CodeVerifyStatus VerifyStatus { get; set; }

    }
}
