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
using PolyStone.CompanyApplications.Dtos;
using PolyStone.CustomDomain.CompanyApplications;
using PolyStone.CustomDomain.CompanyApplications.Authorization;


namespace PolyStone.CompanyApplications
{
    /// <summary>
    /// 个人会员升级企业申请表服务实现
    /// </summary>
    [AbpAuthorize(CompanyApplicationAppPermissions.CompanyApplication)]


    public class CompanyApplicationAppService : PolyStoneAppServiceBase, ICompanyApplicationAppService
    {
        private readonly IRepository<CompanyApplication, int> _companyApplicationRepository;


        private readonly CompanyApplicationManage _companyApplicationManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyApplicationAppService(IRepository<CompanyApplication, int> companyApplicationRepository,
            CompanyApplicationManage companyApplicationManage

        )
        {
            _companyApplicationRepository = companyApplicationRepository;
            _companyApplicationManage = companyApplicationManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<CompanyApplication> _companyApplicationRepositoryAsNoTrack =>
            _companyApplicationRepository.GetAll().AsNoTracking();


        #endregion


        #region 个人会员升级企业申请表管理

        /// <summary>
        /// 根据查询条件获取个人会员升级企业申请表分页列表
        /// </summary>
        public async Task<PagedResultDto<CompanyApplicationListDto>> GetPagedCompanyApplicationsAsync(
            GetCompanyApplicationInput input)
        {

            var query = _companyApplicationRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var companyApplicationCount = await query.CountAsync();

            var companyApplications = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var companyApplicationListDtos = companyApplications.MapTo<List<CompanyApplicationListDto>>();
            return new PagedResultDto<CompanyApplicationListDto>(
                companyApplicationCount,
                companyApplicationListDtos
            );
        }

        /// <summary>
        /// 通过Id获取个人会员升级企业申请表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyApplicationForEditOutput> GetCompanyApplicationForEditAsync(
            NullableIdDto<int> input)
        {
            var output = new GetCompanyApplicationForEditOutput();

            CompanyApplicationEditDto companyApplicationEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyApplicationRepository.GetAsync(input.Id.Value);
                companyApplicationEditDto = entity.MapTo<CompanyApplicationEditDto>();
            }
            else
            {
                companyApplicationEditDto = new CompanyApplicationEditDto();
            }

            output.CompanyApplication = companyApplicationEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取个人会员升级企业申请表ListDto信息
        /// </summary>
        public async Task<CompanyApplicationListDto> GetCompanyApplicationByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyApplicationRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyApplicationListDto>();
        }







        /// <summary>
        /// 新增或更改个人会员升级企业申请表
        /// </summary>
        public async Task CreateOrUpdateCompanyApplicationAsync(CreateOrUpdateCompanyApplicationInput input)
        {
            if (input.CompanyApplicationEditDto.Id.HasValue)
            {
                await UpdateCompanyApplicationAsync(input.CompanyApplicationEditDto);
            }
            else
            {
                await CreateCompanyApplicationAsync(input.CompanyApplicationEditDto);
            }
        }

        /// <summary>
        /// 新增个人会员升级企业申请表
        /// </summary>
        [AbpAuthorize(CompanyApplicationAppPermissions.CompanyApplication_CreateCompanyApplication)]
        public virtual async Task<CompanyApplicationEditDto> CreateCompanyApplicationAsync(
            CompanyApplicationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<CompanyApplication>();

            entity = await _companyApplicationRepository.InsertAsync(entity);
            return entity.MapTo<CompanyApplicationEditDto>();
        }

        /// <summary>
        /// 编辑个人会员升级企业申请表
        /// </summary>
        [AbpAuthorize(CompanyApplicationAppPermissions.CompanyApplication_EditCompanyApplication)]
        public virtual async Task UpdateCompanyApplicationAsync(CompanyApplicationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyApplicationRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyApplicationRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除个人会员升级企业申请表
        /// </summary>
        [AbpAuthorize(CompanyApplicationAppPermissions.CompanyApplication_DeleteCompanyApplication)]
        public async Task DeleteCompanyApplicationAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyApplicationRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除个人会员升级企业申请表
        /// </summary>
        [AbpAuthorize(CompanyApplicationAppPermissions.CompanyApplication_DeleteCompanyApplication)]
        public async Task BatchDeleteCompanyApplicationAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyApplicationRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}
