                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CustomDomain.BusinessCard.Dtos;
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
// Copyright © YoYoCms@China.2018-11-28T10:34:56. All Rights Reserved.
//<生成时间>2018-11-28T10:34:56</生成时间>
	#endregion
namespace PolyStone.CustomDomain.BusinessCard
{
	/// <summary>
    /// 名片服务接口
    /// </summary>
    public interface IBusinessCardAppService : IApplicationService
    {
        #region 名片管理

        /// <summary>
        /// 根据查询条件获取名片分页列表
        /// </summary>
        Task<PagedResultDto<BusinessCardListDto>> GetPagedBusinessCardsAsync(GetBusinessCardInput input);

        /// <summary>
        /// 通过Id获取名片信息进行编辑或修改 
        /// </summary>
        Task<GetBusinessCardForEditOutput> GetBusinessCardForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取名片ListDto信息
        /// </summary>
		Task<BusinessCardListDto> GetBusinessCardByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改名片
        /// </summary>
        Task CreateOrUpdateBusinessCardAsync(CreateOrUpdateBusinessCardInput input);





        /// <summary>
        /// 新增名片
        /// </summary>
        Task<BusinessCardEditDto> CreateBusinessCardAsync(BusinessCardEditDto input);

        /// <summary>
        /// 更新名片
        /// </summary>
        Task UpdateBusinessCardAsync(BusinessCardEditDto input);

        /// <summary>
        /// 删除名片
        /// </summary>
        Task DeleteBusinessCardAsync(EntityDto<int> input);

        #endregion




    }
}
