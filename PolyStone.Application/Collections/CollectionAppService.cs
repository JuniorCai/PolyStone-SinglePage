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
using PolyStone.Collections.Dtos;
using PolyStone.CustomDomain.Collections;
using PolyStone.CustomDomain.Collections.Authorization;

namespace PolyStone.Collections
{
    /// <summary>
    /// 用户收藏服务实现
    /// </summary>
    [AbpAuthorize(CollectionAppPermissions.Collection)]


    public class CollectionAppService : PolyStoneAppServiceBase, ICollectionAppService
    {
        private readonly IRepository<Collection, int> _collectionRepository;


        private readonly CollectionManage _collectionManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CollectionAppService(IRepository<Collection, int> collectionRepository,
            CollectionManage collectionManage

        )
        {
            _collectionRepository = collectionRepository;
            _collectionManage = collectionManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Collection> _collectionRepositoryAsNoTrack => _collectionRepository.GetAll().AsNoTracking();


        #endregion


        #region 用户收藏管理

        /// <summary>
        /// 根据查询条件获取用户收藏分页列表
        /// </summary>
        public async Task<PagedResultDto<CollectionListDto>> GetPagedCollectionsAsync(GetCollectionInput input)
        {

            var query = _collectionRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var collectionCount = await query.CountAsync();


            var collections = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var collectionListDtos = collections.MapTo<List<CollectionListDto>>();
            return new PagedResultDto<CollectionListDto>(
                collectionCount,
                collectionListDtos
            );
        }

        /// <summary>
        /// 通过Id获取用户收藏信息进行编辑或修改 
        /// </summary>
        public async Task<GetCollectionForEditOutput> GetCollectionForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCollectionForEditOutput();

            CollectionEditDto collectionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _collectionRepository.GetAsync(input.Id.Value);
                collectionEditDto = entity.MapTo<CollectionEditDto>();
            }
            else
            {
                collectionEditDto = new CollectionEditDto();
            }

            output.Collection = collectionEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取用户收藏ListDto信息
        /// </summary>
        public async Task<CollectionListDto> GetCollectionByIdAsync(EntityDto<int> input)
        {
            var entity = await _collectionRepository.GetAsync(input.Id);

            return entity.MapTo<CollectionListDto>();
        }







        /// <summary>
        /// 新增或更改用户收藏
        /// </summary>
        public async Task CreateOrUpdateCollectionAsync(CreateOrUpdateCollectionInput input)
        {
            if (input.CollectionEditDto.Id.HasValue)
            {
                await UpdateCollectionAsync(input.CollectionEditDto);
            }
            else
            {
                await CreateCollectionAsync(input.CollectionEditDto);
            }
        }

        /// <summary>
        /// 新增用户收藏
        /// </summary>
        [AbpAuthorize(CollectionAppPermissions.Collection_CreateCollection)]
        public virtual async Task<CollectionEditDto> CreateCollectionAsync(CollectionEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Collection>();

            entity = await _collectionRepository.InsertAsync(entity);
            return entity.MapTo<CollectionEditDto>();
        }

        /// <summary>
        /// 编辑用户收藏
        /// </summary>
        [AbpAuthorize(CollectionAppPermissions.Collection_EditCollection)]
        public virtual async Task UpdateCollectionAsync(CollectionEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _collectionRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _collectionRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户收藏
        /// </summary>
        [AbpAuthorize(CollectionAppPermissions.Collection_DeleteCollection)]
        public async Task DeleteCollectionAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _collectionRepository.DeleteAsync(input.Id);
        }

        #endregion
        
    }
}
