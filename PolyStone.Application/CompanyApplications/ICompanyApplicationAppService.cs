using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.CompanyApplications.Dtos;


namespace PolyStone.CompanyApplications
{
    /// <summary>
    /// 个人会员升级企业申请表服务接口
    /// </summary>
    public interface ICompanyApplicationAppService : IApplicationService
    {
        #region 个人会员升级企业申请表管理

        /// <summary>
        /// 根据查询条件获取个人会员升级企业申请表分页列表
        /// </summary>
        Task<PagedResultDto<CompanyApplicationListDto>> GetPagedCompanyApplicationsAsync(
            GetCompanyApplicationInput input);

        /// <summary>
        /// 通过Id获取个人会员升级企业申请表信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyApplicationForEditOutput> GetCompanyApplicationForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取个人会员升级企业申请表ListDto信息
        /// </summary>
        Task<CompanyApplicationListDto> GetCompanyApplicationByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改个人会员升级企业申请表
        /// </summary>
        Task CreateOrUpdateCompanyApplicationAsync(CreateOrUpdateCompanyApplicationInput input);





        /// <summary>
        /// 新增个人会员升级企业申请表
        /// </summary>
        Task<CompanyApplicationEditDto> CreateCompanyApplicationAsync(CompanyApplicationEditDto input);

        /// <summary>
        /// 更新个人会员升级企业申请表
        /// </summary>
        Task UpdateCompanyApplicationAsync(CompanyApplicationEditDto input);

        /// <summary>
        /// 删除个人会员升级企业申请表
        /// </summary>
        Task DeleteCompanyApplicationAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除个人会员升级企业申请表
        /// </summary>
        Task BatchDeleteCompanyApplicationAsync(List<int> input);

        #endregion


    }
}
