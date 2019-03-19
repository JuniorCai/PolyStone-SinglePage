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
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.CompanyIndustries.Industries;
using PolyStone.CustomDomain.CompanyIndustries.Industries.Authorization;
using PolyStone.Industries.Dtos;

namespace PolyStone.Industries
{
    /// <summary>
    /// 企业行业表服务实现
    /// </summary>

    public class IndustryAppService : PolyStoneAppServiceBase, IIndustryAppService
    {
        private readonly IRepository<Industry, int> _industryRepository;


        private readonly IndustryManage _industryManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public IndustryAppService(IRepository<Industry, int> industryRepository,
            IndustryManage industryManage

        )
        {
            _industryRepository = industryRepository;
            _industryManage = industryManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Industry> _industryRepositoryAsNoTrack => _industryRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业行业表管理

        /// <summary>
        /// 根据查询条件获取企业行业表分页列表
        /// </summary>
        public async Task<PagedResultDto<IndustryListDto>> GetPagedIndustrysAsync(GetIndustryInput input)
        {

            var query = _industryRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(input.IsActive != null, i => i.IsActive == input.IsActive)
                .WhereIf(input.IsShow != null, i => i.IsShow == input.IsShow)
                .WhereIf(!string.IsNullOrEmpty(input.IndustryCode), i => i.IndustryCode == input.IndustryCode);


            var industryCount = await query.CountAsync();

            var industrys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var industryListDtos = industrys.MapTo<List<IndustryListDto>>();
            return new PagedResultDto<IndustryListDto>(
                industryCount,
                industryListDtos
            );
        }

        /// <summary>
        /// 通过Id获取企业行业表信息进行编辑或修改 
        /// </summary>
        public async Task<GetIndustryForEditOutput> GetIndustryForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetIndustryForEditOutput();

            IndustryEditDto industryEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _industryRepository.GetAsync(input.Id.Value);
                industryEditDto = entity.MapTo<IndustryEditDto>();
            }
            else
            {
                industryEditDto = new IndustryEditDto();
            }

            output.Industry = industryEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业行业表ListDto信息
        /// </summary>
        public async Task<IndustryListDto> GetIndustryByIdAsync(EntityDto<int> input)
        {
            var entity = await _industryRepository.GetAsync(input.Id);

            return entity.MapTo<IndustryListDto>();
        }







        /// <summary>
        /// 新增或更改企业行业表
        /// </summary>
        public async Task CreateOrUpdateIndustryAsync(CreateOrUpdateIndustryInput input)
        {
            if (input.IndustryEditDto.Id.HasValue)
            {
                await UpdateIndustryAsync(input.IndustryEditDto);
            }
            else
            {
                await CreateIndustryAsync(input.IndustryEditDto);
            }
        }

        /// <summary>
        /// 新增企业行业表
        /// </summary>
        [AbpAuthorize(IndustryAppPermissions.Industry_CreateIndustry)]
        public virtual async Task<IndustryEditDto> CreateIndustryAsync(IndustryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Industry>();

            entity = await _industryRepository.InsertAsync(entity);
            return entity.MapTo<IndustryEditDto>();
        }

        /// <summary>
        /// 编辑企业行业表
        /// </summary>
        [AbpAuthorize(IndustryAppPermissions.Industry_EditIndustry)]
        public virtual async Task UpdateIndustryAsync(IndustryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _industryRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _industryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业行业表
        /// </summary>
        [AbpAuthorize(IndustryAppPermissions.Industry_DeleteIndustry)]
        public async Task DeleteIndustryAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _industryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业行业表
        /// </summary>
        [AbpAuthorize(IndustryAppPermissions.Industry_DeleteIndustry)]
        public async Task BatchDeleteIndustryAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _industryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion










    }
}
