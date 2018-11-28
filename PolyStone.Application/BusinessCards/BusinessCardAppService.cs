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
using PolyStone.BusinessCards.Dtos;
using PolyStone.CustomDomain.BusinessCard;
using PolyStone.CustomDomain.BusinessCard.Authorization;

namespace PolyStone.BusinessCards
{
    /// <summary>
    /// 名片服务实现
    /// </summary>
    [AbpAuthorize()]
    public class BusinessCardAppService : PolyStoneAppServiceBase, IBusinessCardAppService
    {
        private readonly IRepository<BusinessCard, int> _businessCardRepository;


        private readonly BusinessCardManage _businessCardManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public BusinessCardAppService(IRepository<BusinessCard, int> businessCardRepository,
            BusinessCardManage businessCardManage

        )
        {
            _businessCardRepository = businessCardRepository;
            _businessCardManage = businessCardManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<BusinessCard> _businessCardRepositoryAsNoTrack =>
            _businessCardRepository.GetAll().AsNoTracking();


        #endregion


        #region 名片管理

        /// <summary>
        /// 根据查询条件获取名片分页列表
        /// </summary>
        public async Task<PagedResultDto<BusinessCardListDto>> GetPagedBusinessCardsAsync(GetBusinessCardInput input)
        {

            var query = _businessCardRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var businessCardCount = await query.CountAsync();

            var businessCards = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var businessCardListDtos = businessCards.MapTo<List<BusinessCardListDto>>();
            return new PagedResultDto<BusinessCardListDto>(
                businessCardCount,
                businessCardListDtos
            );
        }

        /// <summary>
        /// 通过Id获取名片信息进行编辑或修改 
        /// </summary>
        public async Task<GetBusinessCardForEditOutput> GetBusinessCardForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetBusinessCardForEditOutput();

            BusinessCardEditDto businessCardEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _businessCardRepository.GetAsync(input.Id.Value);
                businessCardEditDto = entity.MapTo<BusinessCardEditDto>();
            }
            else
            {
                businessCardEditDto = new BusinessCardEditDto();
            }

            output.BusinessCard = businessCardEditDto;
            return output;
        }

        public async Task<BusinessCardEditDto> GetBusinessCardByUserIdAsync(long userId)
        {
            BusinessCardEditDto businessCardEditDto = new BusinessCardEditDto();

            ;

            if (userId>0)
            {
                var entity = await _businessCardRepository.FirstOrDefaultAsync(b => b.UserId == userId);
                businessCardEditDto = entity.MapTo<BusinessCardEditDto>();
            }
            else
            {
                businessCardEditDto = new BusinessCardEditDto();
            }

            return businessCardEditDto;
        }


        /// <summary>
        /// 通过指定id获取名片ListDto信息
        /// </summary>
        public async Task<BusinessCardListDto> GetBusinessCardByIdAsync(EntityDto<int> input)
        {
            var entity = await _businessCardRepository.GetAsync(input.Id);

            return entity.MapTo<BusinessCardListDto>();
        }
        

        /// <summary>
        /// 新增或更改名片
        /// </summary>
        public async Task CreateOrUpdateBusinessCardAsync(CreateOrUpdateBusinessCardInput input)
        {
            if (input.BusinessCardEditDto.Id.HasValue)
            {
                await UpdateBusinessCardAsync(input.BusinessCardEditDto);
            }
            else
            {
                await CreateBusinessCardAsync(input.BusinessCardEditDto);
            }
        }

        /// <summary>
        /// 新增名片
        /// </summary>
        public virtual async Task<BusinessCardEditDto> CreateBusinessCardAsync(BusinessCardEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<BusinessCard>();

            entity = await _businessCardRepository.InsertAsync(entity);
            return entity.MapTo<BusinessCardEditDto>();
        }

        /// <summary>
        /// 编辑名片
        /// </summary>
        public virtual async Task UpdateBusinessCardAsync(BusinessCardEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _businessCardRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _businessCardRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除名片
        /// </summary>
        [AbpAuthorize(BusinessCardAppPermissions.BusinessCard_DeleteBusinessCard)]
        public async Task DeleteBusinessCardAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _businessCardRepository.DeleteAsync(input.Id);
        }

        #endregion
    }
}
