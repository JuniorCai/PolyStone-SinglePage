using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.BusinessCards.Dtos;


namespace PolyStone.BusinessCards
{
    /// <summary>
    /// 名片服务接口
    /// </summary>
    public interface IBusinessCardAppService : IApplicationService
    {
        #region 名片管理

        /// <summary>
        /// 根据查询条件获取名片分页列表
        /// </summary>
        Task<PagedResultDto<BusinessCardListDto>> GetPagedBusinessCardsAsync(GetBusinessCardInput input);

        /// <summary>
        /// 通过Id获取名片信息进行编辑或修改 
        /// </summary>
        Task<GetBusinessCardForEditOutput> GetBusinessCardForEditAsync(NullableIdDto<int> input);

        Task<BusinessCardEditDto> GetBusinessCardByUserIdAsync(long userId);

        /// <summary>
        /// 通过指定id获取名片ListDto信息
        /// </summary>
        Task<BusinessCardListDto> GetBusinessCardByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改名片
        /// </summary>
        Task CreateOrUpdateBusinessCardAsync(CreateOrUpdateBusinessCardInput input);

        /// <summary>
        /// 新增名片
        /// </summary>
        Task<BusinessCardEditDto> CreateBusinessCardAsync(BusinessCardEditDto input);

        /// <summary>
        /// 更新名片
        /// </summary>
        Task UpdateBusinessCardAsync(BusinessCardEditDto input);

        /// <summary>
        /// 删除名片
        /// </summary>
        Task DeleteBusinessCardAsync(EntityDto<int> input);

        #endregion
    }
}
