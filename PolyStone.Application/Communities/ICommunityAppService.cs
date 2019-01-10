using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Communities.Dtos;



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

        Task OffLineCommunityAsync(EntityDto<int> input);

        Task OnLineCommunityAsync(EntityDto<int> input);

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
