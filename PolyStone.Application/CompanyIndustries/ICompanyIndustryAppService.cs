using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CompanyIndustries.Dtos;


namespace PolyStone.CompanyIndustries
{
	/// <summary>
    /// 企业行业关系表服务接口
    /// </summary>
    public interface ICompanyIndustryAppService : IApplicationService
    {
        #region 企业行业关系表管理

        /// <summary>
        /// 根据查询条件获取企业行业关系表分页列表
        /// </summary>
        Task<PagedResultDto<CompanyIndustryListDto>> GetPagedCompanyIndustrysAsync(GetCompanyIndustryInput input);

        /// <summary>
        /// 通过Id获取企业行业关系表信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyIndustryForEditOutput> GetCompanyIndustryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取企业行业关系表ListDto信息
        /// </summary>
		Task<CompanyIndustryListDto> GetCompanyIndustryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业行业关系表
        /// </summary>
        Task CreateOrUpdateCompanyIndustryAsync(CreateOrUpdateCompanyIndustryInput input);





        /// <summary>
        /// 新增企业行业关系表
        /// </summary>
        Task<CompanyIndustryEditDto> CreateCompanyIndustryAsync(CompanyIndustryEditDto input);

        /// <summary>
        /// 更新企业行业关系表
        /// </summary>
        Task UpdateCompanyIndustryAsync(CompanyIndustryEditDto input);

        /// <summary>
        /// 删除企业行业关系表
        /// </summary>
        Task DeleteCompanyIndustryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业行业关系表
        /// </summary>
        Task BatchDeleteCompanyIndustryAsync(List<int> input);

        #endregion




    }
}
