using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CommunityCategories.Dtos;

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
// Copyright © YoYoCms@China.2018-08-01T18:08:20. All Rights Reserved.
//<生成时间>2018-08-01T18:08:20</生成时间>
	#endregion
namespace PolyStone.CommunityCategories
{
	/// <summary>
    /// 圈子类别表服务接口
    /// </summary>
    public interface ICommunityCategoryAppService : IApplicationService
    {
        #region 圈子类别表管理

        /// <summary>
        /// 根据查询条件获取圈子类别表分页列表
        /// </summary>
        Task<PagedResultDto<CommunityCategoryListDto>> GetPagedCommunityCategorysAsync(GetCommunityCategoryInput input);

        /// <summary>
        /// 通过Id获取圈子类别表信息进行编辑或修改 
        /// </summary>
        Task<GetCommunityCategoryForEditOutput> GetCommunityCategoryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取圈子类别表ListDto信息
        /// </summary>
		Task<CommunityCategoryListDto> GetCommunityCategoryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改圈子类别表
        /// </summary>
        Task CreateOrUpdateCommunityCategoryAsync(CreateOrUpdateCommunityCategoryInput input);





        /// <summary>
        /// 新增圈子类别表
        /// </summary>
        Task<CommunityCategoryEditDto> CreateCommunityCategoryAsync(CommunityCategoryEditDto input);

        /// <summary>
        /// 更新圈子类别表
        /// </summary>
        Task UpdateCommunityCategoryAsync(CommunityCategoryEditDto input);

        /// <summary>
        /// 删除圈子类别表
        /// </summary>
        Task DeleteCommunityCategoryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除圈子类别表
        /// </summary>
        Task BatchDeleteCommunityCategoryAsync(List<int> input);

        #endregion




    }
}
