using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using PolyStone.Collections.Dtos;
using PolyStone.CustomDomain.Collections;
using PolyStone.CustomDomain.Collections.Authorization;
using PolyStone.CustomDomain.Modules;
using PolyStone.Modules.Dtos;

namespace PolyStone.Collections
{
    /// <summary>
    /// 用户收藏服务实现
    /// </summary>
    [AbpAuthorize(CollectionAppPermissions.Collection)]


    public class CollectionAppService : PolyStoneAppServiceBase, ICollectionAppService
    {
        private readonly IRepository<Collection, int> _collectionRepository;
        private readonly IRepository<Module, int> _moduleRepository;

        private readonly CollectionManage _collectionManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CollectionAppService(IRepository<Collection, int> collectionRepository, IRepository<Module, int> moduleRepository,
            CollectionManage collectionManage

        )
        {
            _collectionRepository = collectionRepository;
            _collectionManage = collectionManage;
            _moduleRepository = moduleRepository;

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
            var moduleDto = new Module();
            if (input.ModuleId > 0)
            {
                moduleDto = _moduleRepository.GetAsync(input.ModuleId).Result;
                if (moduleDto == null)
                {
                    return new PagedResultDto<CollectionListDto>(
                        0,
                        new List<CollectionListDto>()
                    );
                }
            }
            var query = _collectionRepositoryAsNoTrack;
            query = query.WhereIf(input.UserId > 0, c => c.UserId == input.UserId)
                .WhereIf(input.ModuleId > 0, c => c.ModuleId == input.ModuleId);

            switch (moduleDto.Name)
            {
                case "产品":
                    query = query.Include(c => c.Product);
                    break;
                case "企业":
                    query = query.Include(c => c.Company);
                    break;
                case "供应":
                case "求购":
                    query = query.Include(c => c.Community);
                    break;
                default:
                    break;
            }

            
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
        public virtual async Task<bool> UpdateCollectionAsync(CollectionEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            try
            {
                var entity = await _collectionRepository.GetAsync(input.Id.Value);
                input.MapTo(entity);

                await _collectionRepository.UpdateAsync(entity);
                return true;
            }
            catch (AbpException ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 删除用户收藏
        /// </summary>
        [AbpAuthorize(CollectionAppPermissions.Collection_DeleteCollection)]
        public async Task<bool> DeleteCollectionAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            try
            {
                await _collectionRepository.DeleteAsync(input.Id);
                return true;
            }
            catch (AbpException ex)
            {
                return false;
            }

        }

        #endregion
        
    }
}
