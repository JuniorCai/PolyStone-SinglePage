using System;
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
using PolyStone.Companies.Dtos;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.Companies.Authorization;




namespace PolyStone.Companies
{
    /// <summary>
    /// 企业表服务实现
    /// </summary>
    //[AbpAuthorize(CompanyAppPermissions.Company)]


    public class CompanyAppService : PolyStoneAppServiceBase, ICompanyAppService
    {
        private readonly IRepository<Company, int> _companyRepository;


        private readonly CompanyManage _companyManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyAppService(IRepository<Company, int> companyRepository,
            CompanyManage companyManage

        )
        {
            _companyRepository = companyRepository;
            _companyManage = companyManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Company> _companyRepositoryAsNoTrack => _companyRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业表管理

        /// <summary>
        /// 根据查询条件获取企业表分页列表
        /// </summary>
        public async Task<PagedResultDto<CompanyListDto>> GetPagedCompanysAsync(GetCompanyInput input)
        {
            var query = _companyRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            //            var companyCount = await query.CountAsync();
            //
            //            var companys =  query
            //                .OrderBy(input.Sorting)
            //                .PageBy(input)
            //                .ToListAsync().Result;
            var tupleResult = GetPagedCompanyList(input);

            var companyListDtos = tupleResult.Result.Item2.MapTo<List<CompanyListDto>>();

            return new PagedResultDto<CompanyListDto>(
                tupleResult.Result.Item1,
                companyListDtos
            );
        }

        protected async Task<Tuple<int, List<Company>>> GetPagedCompanyList(GetCompanyInput input)
        {
            var query = _companyRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(!string.IsNullOrEmpty(input.CompanyName),
                    c => c.CompanyName.Contains(input.CompanyName))
                .WhereIf(input.IsAuthed != null, c => c.IsAuthed == input.IsAuthed)
                .WhereIf(input.IsActive != null, c => c.IsActive == input.IsActive);

            var companyCount = await query.CountAsync();
            var companys = query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync().Result;


            return new Tuple<int, List<Company>>(companyCount, companys);
        }

        public async Task<PagedResultDto<CompanyListWithProductsDto>> GetPagedCompanysWithProductsAsync(GetCompanyInput input)
        {

            var tupleResult = GetPagedCompanyList(input);

            var companyListDtos = tupleResult.Result.Item2.MapTo<List<CompanyListWithProductsDto>>();

            return new PagedResultDto<CompanyListWithProductsDto>(
                tupleResult.Result.Item1,
                companyListDtos
            );
        }


        /// <summary>
        /// 通过Id获取企业表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCompanyForEditOutput();

            CompanyEditDto companyEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyRepository.GetAsync(input.Id.Value);
                companyEditDto = entity.MapTo<CompanyEditDto>();
            }
            else
            {
                companyEditDto = new CompanyEditDto();
            }

            output.Company = companyEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业表ListDto信息
        /// </summary>
        public async Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyListDto>();
        }

        /// <summary>
        /// 通过指定UserId获取企业ListDto信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyListDto> GetCompanyByUserId(int userId)
        {
            var entity = await _companyRepository.FirstOrDefaultAsync(c => c.UserId == userId);

            return entity.MapTo<CompanyListDto>();
        }


        /// <summary>
        /// 新增或更改企业表
        /// </summary>
        public async Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input)
        {
            if (input.CompanyEditDto.Id.HasValue)
            {
                await UpdateCompanyAsync(input.CompanyEditDto);
            }
            else
            {
                await CreateCompanyAsync(input.CompanyEditDto);
            }
        }

        /// <summary>
        /// 新增企业表
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_CreateCompany)]
        public virtual async Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Company>();

            input.Id = await _companyRepository.InsertAndGetIdAsync(entity);
            return input;
        }

        /// <summary>
        /// 编辑企业表
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_EditCompany)]
        public virtual async Task UpdateCompanyAsync(CompanyEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业表
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task DeleteCompanyAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业表
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task BatchDeleteCompanyAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

    }
}