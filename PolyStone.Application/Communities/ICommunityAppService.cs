using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Communities.Dtos;

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
// Copyright © YoYoCms@China.2018-08-01T14:47:43. All Rights Reserved.
//<生成时间>2018-08-01T14:47:43</生成时间>
	#endregion

namespace PolyStone.Communities
{
    /// <summary>
    /// 圈子信息表服务接口
    /// </summary>
    public interface ICommunityAppService : IApplicationService
    {
        #region 圈子信息表管理

        /// <summary>
        /// 根据查询条件获取圈子信息表分页列表
        /// </summary>
        Task<PagedResultDto<CommunityListDto>> GetPagedCommunitysAsync(GetCommunityInput input);

        /// <summary>
        /// 通过Id获取圈子信息表信息进行编辑或修改 
        /// </summary>
        Task<GetCommunityForEditOutput> GetCommunityForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取圈子信息表ListDto信息
        /// </summary>
        Task<CommunityListDto> GetCommunityByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改圈子信息表
        /// </summary>
        Task CreateOrUpdateCommunityAsync(CreateOrUpdateCommunityInput input);





        /// <summary>
        /// 新增圈子信息表
        /// </summary>
        Task<CommunityEditDto> CreateCommunityAsync(CommunityEditDto input);

        /// <summary>
        /// 更新圈子信息表
        /// </summary>
        Task UpdateCommunityAsync(CommunityEditDto input);

        /// <summary>
        /// 删除圈子信息表
        /// </summary>
        Task DeleteCommunityAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除圈子信息表
        /// </summary>
        Task BatchDeleteCommunityAsync(List<int> input);

        #endregion




    }
}
