using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Industries.Dtos;

namespace PolyStone.Industries
{
	/// <summary>
    /// 企业行业表服务接口
    /// </summary>
    public interface IIndustryAppService : IApplicationService
    {
        #region 企业行业表管理

        /// <summary>
        /// 根据查询条件获取企业行业表分页列表
        /// </summary>
        Task<PagedResultDto<IndustryListDto>> GetPagedIndustrysAsync(GetIndustryInput input);

        /// <summary>
        /// 通过Id获取企业行业表信息进行编辑或修改 
        /// </summary>
        Task<GetIndustryForEditOutput> GetIndustryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取企业行业表ListDto信息
        /// </summary>
		Task<IndustryListDto> GetIndustryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业行业表
        /// </summary>
        Task CreateOrUpdateIndustryAsync(CreateOrUpdateIndustryInput input);





        /// <summary>
        /// 新增企业行业表
        /// </summary>
        Task<IndustryEditDto> CreateIndustryAsync(IndustryEditDto input);

        /// <summary>
        /// 更新企业行业表
        /// </summary>
        Task UpdateIndustryAsync(IndustryEditDto input);

        /// <summary>
        /// 删除企业行业表
        /// </summary>
        Task DeleteIndustryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业行业表
        /// </summary>
        Task BatchDeleteIndustryAsync(List<int> input);

        #endregion




    }
}
