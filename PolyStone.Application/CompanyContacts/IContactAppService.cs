using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CompanyContacts.Dtos;

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
// Copyright © YoYoCms@China.2018-08-02T16:45:05. All Rights Reserved.
//<生成时间>2018-08-02T16:45:05</生成时间>
	#endregion
namespace PolyStone.CompanyContacts
{
	/// <summary>
    /// 企业联系表服务接口
    /// </summary>
    public interface IContactAppService : IApplicationService
    {
        #region 企业联系表管理

        /// <summary>
        /// 根据查询条件获取企业联系表分页列表
        /// </summary>
        Task<PagedResultDto<ContactListDto>> GetPagedContactsAsync(GetContactInput input);

        /// <summary>
        /// 通过Id获取企业联系表信息进行编辑或修改 
        /// </summary>
        Task<GetContactForEditOutput> GetContactForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取企业联系表ListDto信息
        /// </summary>
		Task<ContactListDto> GetContactByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业联系表
        /// </summary>
        Task CreateOrUpdateContactAsync(CreateOrUpdateContactInput input);


        Task SetContactDefault(int companyId, int contactId);


        /// <summary>
        /// 新增企业联系表
        /// </summary>
        Task<ContactEditDto> CreateContactAsync(ContactEditDto input);

        /// <summary>
        /// 更新企业联系表
        /// </summary>
        Task UpdateContactAsync(ContactEditDto input);

        /// <summary>
        /// 删除企业联系表
        /// </summary>
        Task DeleteContactAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业联系表
        /// </summary>
        Task BatchDeleteContactAsync(List<int> input);

        #endregion




    }
}
