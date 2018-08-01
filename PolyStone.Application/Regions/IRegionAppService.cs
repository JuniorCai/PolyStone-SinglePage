using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Regions.Dtos;


namespace PolyStone.Regions
{
    /// <summary>
    /// 地区表服务接口
    /// </summary>
    public interface IRegionAppService : IApplicationService
    {
        #region 地区表管理

        /// <summary>
        /// 根据查询条件获取地区表分页列表
        /// </summary>
        Task<PagedResultDto<RegionListDto>> GetPagedRegionsAsync(GetRegionInput input);

        /// <summary>
        /// 通过Id获取地区表信息进行编辑或修改 
        /// </summary>
        Task<GetRegionForEditOutput> GetRegionForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取地区表ListDto信息
        /// </summary>
        Task<RegionListDto> GetRegionByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改地区表
        /// </summary>
        Task CreateOrUpdateRegionAsync(CreateOrUpdateRegionInput input);





        /// <summary>
        /// 新增地区表
        /// </summary>
        Task<RegionEditDto> CreateRegionAsync(RegionEditDto input);

        /// <summary>
        /// 更新地区表
        /// </summary>
        Task UpdateRegionAsync(RegionEditDto input);

        /// <summary>
        /// 删除地区表
        /// </summary>
        Task DeleteRegionAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除地区表
        /// </summary>
        Task BatchDeleteRegionAsync(List<int> input);

        #endregion

    }
}
