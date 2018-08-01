using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Collections.Dtos;

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
// Copyright © YoYoCms@China.2018-08-01T14:03:13. All Rights Reserved.
//<生成时间>2018-08-01T14:03:13</生成时间>
	#endregion

namespace PolyStone.Collections
{
    /// <summary>
    /// 用户收藏服务接口
    /// </summary>
    public interface ICollectionAppService : IApplicationService
    {
        #region 用户收藏管理

        /// <summary>
        /// 根据查询条件获取用户收藏分页列表
        /// </summary>
        Task<PagedResultDto<CollectionListDto>> GetPagedCollectionsAsync(GetCollectionInput input);

        /// <summary>
        /// 通过Id获取用户收藏信息进行编辑或修改 
        /// </summary>
        Task<GetCollectionForEditOutput> GetCollectionForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取用户收藏ListDto信息
        /// </summary>
        Task<CollectionListDto> GetCollectionByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改用户收藏
        /// </summary>
        Task CreateOrUpdateCollectionAsync(CreateOrUpdateCollectionInput input);





        /// <summary>
        /// 新增用户收藏
        /// </summary>
        Task<CollectionEditDto> CreateCollectionAsync(CollectionEditDto input);

        /// <summary>
        /// 更新用户收藏
        /// </summary>
        Task UpdateCollectionAsync(CollectionEditDto input);

        /// <summary>
        /// 删除用户收藏
        /// </summary>
        Task DeleteCollectionAsync(EntityDto<int> input);

        #endregion

    }
}
