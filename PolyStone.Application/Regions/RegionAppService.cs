using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using PolyStone.CustomDomain.Regions;
using PolyStone.CustomDomain.Regions.Authorization;
using PolyStone.Regions.Dtos;

namespace PolyStone.Regions
{
    /// <summary>
    /// 地区表服务实现
    /// </summary>
    [AbpAuthorize(RegionAppPermissions.Region)]


    public class RegionAppService : PolyStoneAppServiceBase, IRegionAppService
    {
        private readonly IRepository<Region, int> _regionRepository;


        private readonly RegionManage _regionManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public RegionAppService(IRepository<Region, int> regionRepository,
            RegionManage regionManage

        )
        {
            _regionRepository = regionRepository;
            _regionManage = regionManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Region> _regionRepositoryAsNoTrack => _regionRepository.GetAll().AsNoTracking();


        #endregion


        #region 地区表管理

        /// <summary>
        /// 根据查询条件获取地区表分页列表
        /// </summary>
        public async Task<PagedResultDto<RegionListDto>> GetPagedRegionsAsync(GetRegionInput input)
        {

            var query = _regionRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            if (string.IsNullOrEmpty(input.RegionCode))
            {
                query = query.Where(r => r.ParentCode == "1" && r.RegionCode != "100000");
            }
            else
            {
                string parentCode = input.RegionCode;
                query = query.Where(r => r.ParentCode == parentCode);
            }

            var regionCount = await query.CountAsync();

            var regions = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var regionListDtos = regions.MapTo<List<RegionListDto>>();
            return new PagedResultDto<RegionListDto>(
                regionCount,
                regionListDtos
            );
        }

        /// <summary>
        /// 通过Id获取地区表信息进行编辑或修改 
        /// </summary>
        public async Task<PagedResultDto<RegionListDto>> GetPagedRegionsByRegionIdAsync(int regionId)
        {
            var region = await _regionRepository.GetAsync(regionId);
            if (region != null)
            {
                return await GetPagedRegionsAsync(new GetRegionInput() {RegionCode = region.RegionCode, MaxResultCount = 100,Sorting = "Id"});
            }

            return new PagedResultDto<RegionListDto>(
                0,
                new List<RegionListDto>()
            );
        }

        /// <summary>
        /// 通过Id获取地区表信息进行编辑或修改 
        /// </summary>
        public async Task<GetRegionForEditOutput> GetRegionForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetRegionForEditOutput();

            RegionEditDto regionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _regionRepository.GetAsync(input.Id.Value);
                regionEditDto = entity.MapTo<RegionEditDto>();
            }
            else
            {
                regionEditDto = new RegionEditDto();
            }

            output.Region = regionEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取地区表ListDto信息
        /// </summary>
        public async Task<RegionListDto> GetRegionByIdAsync(EntityDto<int> input)
        {
            var entity = await _regionRepository.GetAsync(input.Id);

            return entity.MapTo<RegionListDto>();
        }

        public async Task<RegionListDto> GetRegionByCodeAsync(string regionCode)
        {
            var entity = await _regionRepository.FirstOrDefaultAsync(r => r.RegionCode == regionCode);
            return entity.MapTo<RegionListDto>();
        }


        /// <summary>
        /// 新增或更改地区表
        /// </summary>
        public async Task CreateOrUpdateRegionAsync(CreateOrUpdateRegionInput input)
        {
            if (input.RegionEditDto.Id.HasValue)
            {
                await UpdateRegionAsync(input.RegionEditDto);
            }
            else
            {
                await CreateRegionAsync(input.RegionEditDto);
            }
        }

        /// <summary>
        /// 新增地区表
        /// </summary>
        [AbpAuthorize(RegionAppPermissions.Region_CreateRegion)]
        public virtual async Task<RegionEditDto> CreateRegionAsync(RegionEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Region>();

            entity = await _regionRepository.InsertAsync(entity);
            return entity.MapTo<RegionEditDto>();
        }

        /// <summary>
        /// 编辑地区表
        /// </summary>
        [AbpAuthorize(RegionAppPermissions.Region_EditRegion)]
        public virtual async Task UpdateRegionAsync(RegionEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _regionRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _regionRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除地区表
        /// </summary>
        [AbpAuthorize(RegionAppPermissions.Region_DeleteRegion)]
        public async Task DeleteRegionAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _regionRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除地区表
        /// </summary>
        [AbpAuthorize(RegionAppPermissions.Region_DeleteRegion)]
        public async Task BatchDeleteRegionAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _regionRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        
    }
}