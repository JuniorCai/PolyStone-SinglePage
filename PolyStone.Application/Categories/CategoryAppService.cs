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
using PolyStone.Categories.Dtos;
using PolyStone.CustomDomain.Categories;
using PolyStone.CustomDomain.Categories.Authorization;




namespace PolyStone.Categories
{
    /// <summary>
    /// 产品类目服务实现
    /// </summary>
    [AbpAuthorize(CategoryAppPermissions.Category)]
    public class CategoryAppService : PolyStoneAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;


        private readonly CategoryManage _categoryManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CategoryAppService(IRepository<Category, int> categoryRepository,
            CategoryManage categoryManage

        )
        {
            _categoryRepository = categoryRepository;
            _categoryManage = categoryManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Category> _categoryRepositoryAsNoTrack => _categoryRepository.GetAll().AsNoTracking();


        #endregion


        #region 产品类目管理

        /// <summary>
        /// 根据查询条件获取产品类目分页列表
        /// </summary>
        public async Task<PagedResultDto<CategoryListDto>> GetPagedCategorysAsync(GetCategoryInput input)
        {

            var query = _categoryRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(input.GetActive, c => c.IsActive == true);

            var categoryCount = await query.CountAsync();

            var categorys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var categoryListDtos = categorys.MapTo<List<CategoryListDto>>();
            return new PagedResultDto<CategoryListDto>(
                categoryCount,
                categoryListDtos
            );
        }

        /// <summary>
        /// 通过Id获取产品类目信息进行编辑或修改 
        /// </summary>
        public async Task<GetCategoryForEditOutput> GetCategoryForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCategoryForEditOutput();

            CategoryEditDto categoryEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _categoryRepository.GetAsync(input.Id.Value);
                categoryEditDto = entity.MapTo<CategoryEditDto>();
            }
            else
            {
                categoryEditDto = new CategoryEditDto();
            }

            output.Category = categoryEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取产品类目ListDto信息
        /// </summary>
        public async Task<CategoryListDto> GetCategoryByIdAsync(EntityDto<int> input)
        {
            var entity = await _categoryRepository.GetAsync(input.Id);

            return entity.MapTo<CategoryListDto>();
        }







        /// <summary>
        /// 新增或更改产品类目
        /// </summary>
        public async Task CreateOrUpdateCategoryAsync(CreateOrUpdateCategoryInput input)
        {
            if (input.CategoryEditDto.Id.HasValue)
            {
                await UpdateCategoryAsync(input.CategoryEditDto);
            }
            else
            {
                await CreateCategoryAsync(input.CategoryEditDto);
            }
        }

        /// <summary>
        /// 新增产品类目
        /// </summary>
        [AbpAuthorize(CategoryAppPermissions.Category_CreateCategory)]
        public virtual async Task<CategoryEditDto> CreateCategoryAsync(CategoryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Category>();

            entity = await _categoryRepository.InsertAsync(entity);
            return entity.MapTo<CategoryEditDto>();
        }

        /// <summary>
        /// 编辑产品类目
        /// </summary>
        [AbpAuthorize(CategoryAppPermissions.Category_EditCategory)]
        public virtual async Task UpdateCategoryAsync(CategoryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _categoryRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _categoryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除产品类目
        /// </summary>
        [AbpAuthorize(CategoryAppPermissions.Category_DeleteCategory)]
        public async Task DeleteCategoryAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _categoryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除产品类目
        /// </summary>
        [AbpAuthorize(CategoryAppPermissions.Category_DeleteCategory)]
        public async Task BatchDeleteCategoryAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _categoryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion










    }
}
