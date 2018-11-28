                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
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
// Copyright © YoYoCms@China.2018-11-28T10:35:00. All Rights Reserved.
//<生成时间>2018-11-28T10:35:00</生成时间>
	#endregion
namespace PolyStone.CustomDomain.BusinessCard
{
    /// <summary>
    /// 名片业务管理
    /// </summary>
    public class BusinessCardManage : IDomainService
    {
        private readonly IRepository<BusinessCard,int> _businessCardRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public BusinessCardManage(IRepository<BusinessCard,int> businessCardRepository  )
        {
            _businessCardRepository = businessCardRepository;
        }

		//TODO:编写领域业务代码


		/// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {


 

        }


		}

    
	
}
