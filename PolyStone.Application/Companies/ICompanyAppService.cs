using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Companies.Dtos;


namespace PolyStone.Companies
{
    /// <summary>
    /// 企业表服务接口
    /// </summary>
    public interface ICompanyAppService : IApplicationService
    {
        #region 企业表管理

        /// <summary>
        /// 根据查询条件获取企业表分页列表
        /// </summary>
        Task<PagedResultDto<CompanyListDto>> GetPagedCompanysAsync(GetCompanyInput input);


        Task<PagedResultDto<CompanyListWithProductsDto>> GetPagedCompanysWithProductsAsync(GetCompanyInput input);

        /// <summary>
        /// 通过Id获取企业表信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取企业表ListDto信息
        /// </summary>
        Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input);


        Task<CompanyListDto> GetCompanyByUserId(int userId);


        /// <summary>
        /// 新增或更改企业表
        /// </summary>
        Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input);





        /// <summary>
        /// 新增企业表
        /// </summary>
        Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 更新企业表
        /// </summary>
        Task UpdateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 删除企业表
        /// </summary>
        Task DeleteCompanyAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业表
        /// </summary>
        Task BatchDeleteCompanyAsync(List<int> input);

        #endregion




    }
}