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
using PolyStone.CompanyIndustries.Dtos;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries;
using PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries.Authorization;

namespace PolyStone.CompanyIndustries
{
    /// <summary>
    /// 企业行业关系表服务实现
    /// </summary>
    [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry)]


    public class CompanyIndustryAppService : PolyStoneAppServiceBase, ICompanyIndustryAppService
    {
        private readonly IRepository<CompanyIndustry, int> _companyIndustryRepository;


        private readonly CompanyIndustryManage _companyIndustryManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyIndustryAppService(IRepository<CompanyIndustry, int> companyIndustryRepository,
            CompanyIndustryManage companyIndustryManage

        )
        {
            _companyIndustryRepository = companyIndustryRepository;
            _companyIndustryManage = companyIndustryManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<CompanyIndustry> _companyIndustryRepositoryAsNoTrack =>
            _companyIndustryRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业行业关系表管理

        /// <summary>
        /// 根据查询条件获取企业行业关系表分页列表
        /// </summary>
        public async Task<PagedResultDto<CompanyIndustryListDto>> GetPagedCompanyIndustrysAsync(
            GetCompanyIndustryInput input)
        {

            var query = _companyIndustryRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var companyIndustryCount = await query.CountAsync();

            var companyIndustrys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var companyIndustryListDtos = companyIndustrys.MapTo<List<CompanyIndustryListDto>>();
            return new PagedResultDto<CompanyIndustryListDto>(
                companyIndustryCount,
                companyIndustryListDtos
            );
        }

        /// <summary>
        /// 通过Id获取企业行业关系表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyIndustryForEditOutput> GetCompanyIndustryForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCompanyIndustryForEditOutput();

            CompanyIndustryEditDto companyIndustryEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyIndustryRepository.GetAsync(input.Id.Value);
                companyIndustryEditDto = entity.MapTo<CompanyIndustryEditDto>();
            }
            else
            {
                companyIndustryEditDto = new CompanyIndustryEditDto();
            }

            output.CompanyIndustry = companyIndustryEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业行业关系表ListDto信息
        /// </summary>
        public async Task<CompanyIndustryListDto> GetCompanyIndustryByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyIndustryRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyIndustryListDto>();
        }







        /// <summary>
        /// 新增或更改企业行业关系表
        /// </summary>
        public async Task CreateOrUpdateCompanyIndustryAsync(CreateOrUpdateCompanyIndustryInput input)
        {
            if (input.CompanyIndustryEditDto.Id.HasValue)
            {
                await UpdateCompanyIndustryAsync(input.CompanyIndustryEditDto);
            }
            else
            {
                await CreateCompanyIndustryAsync(input.CompanyIndustryEditDto);
            }
        }

        /// <summary>
        /// 新增企业行业关系表
        /// </summary>
        [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry_CreateCompanyIndustry)]
        public virtual async Task<CompanyIndustryEditDto> CreateCompanyIndustryAsync(CompanyIndustryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<CompanyIndustry>();

            entity = await _companyIndustryRepository.InsertAsync(entity);
            return entity.MapTo<CompanyIndustryEditDto>();
        }

        /// <summary>
        /// 编辑企业行业关系表
        /// </summary>
        [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry_EditCompanyIndustry)]
        public virtual async Task UpdateCompanyIndustryAsync(CompanyIndustryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyIndustryRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyIndustryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业行业关系表
        /// </summary>
        [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry_DeleteCompanyIndustry)]
        public async Task DeleteCompanyIndustryAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyIndustryRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry_DeleteCompanyIndustry)]
        public async Task DeleteCompanyIndustryByCompanyIdAsync(int companyId)
        {
            await _companyIndustryRepository.DeleteAsync(c => c.CompanyId == companyId);
        }


        /// <summary>
        /// 批量删除企业行业关系表
        /// </summary>
        [AbpAuthorize(CompanyIndustryAppPermissions.CompanyIndustry_DeleteCompanyIndustry)]
        public async Task BatchDeleteCompanyIndustryAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyIndustryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion



    }
}