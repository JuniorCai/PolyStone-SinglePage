using System;
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
using PolyStone.CustomDomain.Products;
using PolyStone.CustomDomain.Products.Authorization;
using PolyStone.Products.Dtos;


namespace PolyStone.Products
{
    /// <summary>
    /// 产品表服务实现
    /// </summary>

    public class ProductAppService : PolyStoneAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, int> _productRepository;


        private readonly ProductManage _productManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ProductAppService(IRepository<Product, int> productRepository,
            ProductManage productManage

        )
        {
            _productRepository = productRepository;
            _productManage = productManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Product> _productRepositoryAsNoTrack => _productRepository.GetAll().AsNoTracking();


        #endregion


        #region 产品表管理

        /// <summary>
        /// 根据查询条件获取产品表分页列表
        /// </summary>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(GetProductInput input)
        {
            try
            {
                var query = _productRepositoryAsNoTrack;
                //TODO:根据传入的参数添加过滤条件
                query = query.WhereIf(input.CompanyId > 0, c => c.CompanyId == input.CompanyId)
                    .WhereIf(input.Id > 0, c => c.Id == input.Id)
                    .WhereIf(!string.IsNullOrEmpty(input.Title), c => c.Detail.Contains(input.Title))
                    .WhereIf(input.CategoryId > 0, c => c.CategoryId == input.CategoryId)
                    .WhereIf(input.VerifyStatus != VerifyStatus.Invalid, c => c.VerifyStatus == input.VerifyStatus)
                    .WhereIf(input.ReleaseStatus != ReleaseStatus.Invalid, c => c.ReleaseStatus == input.ReleaseStatus)
                    .WhereIf(input.FromTime != null, c => c.CreationTime >= input.FromTime)
                    .WhereIf(input.EndTime != null, c => c.CreationTime <= input.EndTime);

                var productCount = await query.CountAsync();

                var products = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var productListDtos = products.MapTo<List<ProductListDto>>();
                return new PagedResultDto<ProductListDto>(
                    productCount,
                    productListDtos
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 通过Id获取产品表信息进行编辑或修改 
        /// </summary>
        public async Task<GetProductForEditOutput> GetProductForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetProductForEditOutput();

            ProductEditDto productEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _productRepository.GetAsync(input.Id.Value);
                productEditDto = entity.MapTo<ProductEditDto>();
            }
            else
            {
                productEditDto = new ProductEditDto();
            }

            output.Product = productEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取产品表ListDto信息
        /// </summary>
        public async Task<ProductListDto> GetProductByIdAsync(EntityDto<int> input)
        {
            var entity = await _productRepository.GetAsync(input.Id);

            return entity.MapTo<ProductListDto>();
        }


        public async Task<List<ProductListDto>> GetProductByCompanyIdAsync(EntityDto<int> input)
        {
            var products = await _productRepository.GetAllListAsync(p => p.CompanyId == input.Id);
            return products.MapTo<List<ProductListDto>>();
        }





        /// <summary>
        /// 新增或更改产品表
        /// </summary>
        public async Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input)
        {
            if (input.ProductEditDto.Id.HasValue)
            {
                await UpdateProductAsync(input.ProductEditDto);
            }
            else
            {
                await CreateProductAsync(input.ProductEditDto);
            }
        }

        /// <summary>
        /// 新增产品表
        /// </summary>
        [AbpAuthorize(ProductAppPermissions.Product_CreateProduct)]
        public virtual async Task<ProductEditDto> CreateProductAsync(ProductEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            
            var entity = input.MapTo<Product>();
//            entity.VerifyStatus = VerifyStatus.Pending;
//            entity.ReleaseStatus = ReleaseStatus.UnPublished;

            entity = await _productRepository.InsertAsync(entity);
            return entity.MapTo<ProductEditDto>();
        }

        /// <summary>
        /// 编辑产品表
        /// </summary>
        [AbpAuthorize(ProductAppPermissions.Product_EditProduct)]
        public virtual async Task UpdateProductAsync(ProductEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _productRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _productRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除产品表
        /// </summary>
        [AbpAuthorize(ProductAppPermissions.Product_DeleteProduct)]
        public async Task DeleteProductAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _productRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除产品表
        /// </summary>
        [AbpAuthorize(ProductAppPermissions.Product_DeleteProduct)]
        public async Task BatchDeleteProductAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _productRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}