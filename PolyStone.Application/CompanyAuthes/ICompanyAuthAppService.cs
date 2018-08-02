using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CompanyAuthes.Dtos;

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
// Copyright © YoYoCms@China.2018-08-02T17:18:34. All Rights Reserved.
//<生成时间>2018-08-02T17:18:34</生成时间>
	#endregion

namespace PolyStone.CompanyAuthes
{
    /// <summary>
    /// 企业资质表服务接口
    /// </summary>
    public interface ICompanyAuthAppService : IApplicationService
    {
        #region 企业资质表管理

        /// <summary>
        /// 根据查询条件获取企业资质表分页列表
        /// </summary>
        Task<PagedResultDto<CompanyAuthListDto>> GetPagedCompanyAuthsAsync(GetCompanyAuthInput input);

        /// <summary>
        /// 通过Id获取企业资质表信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyAuthForEditOutput> GetCompanyAuthForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取企业资质表ListDto信息
        /// </summary>
        Task<CompanyAuthListDto> GetCompanyAuthByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业资质表
        /// </summary>
        Task CreateOrUpdateCompanyAuthAsync(CreateOrUpdateCompanyAuthInput input);





        /// <summary>
        /// 新增企业资质表
        /// </summary>
        Task<CompanyAuthEditDto> CreateCompanyAuthAsync(CompanyAuthEditDto input);

        /// <summary>
        /// 更新企业资质表
        /// </summary>
        Task UpdateCompanyAuthAsync(CompanyAuthEditDto input);

        /// <summary>
        /// 删除企业资质表
        /// </summary>
        Task DeleteCompanyAuthAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业资质表
        /// </summary>
        Task BatchDeleteCompanyAuthAsync(List<int> input);

        #endregion




    }
}
