using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization;
using PolyStone.Communities.Dtos;
using PolyStone.CustomDomain.Products;
using PolyStone.Products;
using PolyStone.Products.Dtos;

namespace PolyStone.Web.Controllers
{
    public class ProductController : PolyStoneControllerBase
    {
        private readonly IProductAppService _productService;

        public ProductController(IProductAppService productAppService)
        {
            _productService = productAppService;
        }


        [System.Web.Http.HttpPost]
        public async Task<JsonResult> CreateProduct(ProductEditDto model)
        {
            if (PermissionChecker.IsGranted("Pages.Product.CreateProduct"))
            {

                try
                {
                    var edit = await _productService.CreateProductAsync(model);
                    return Json(new { success = true, msg = "" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, msg = "保存失败" });
                }
            }
            return Json(new { success = false, msg = "无操作权限" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateProduct(ProductEditDto model)
        {
            if (PermissionChecker.IsGranted("Pages.Product.EditProduct"))
            {

                CheckModelState();


                try
                {
                    await _productService.UpdateProductAsync(model);
                    return Json(new { success = true, msg = "" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, msg = "保存失败" });
                }
            }
            return Json(new { success = false, msg = "保存失败" });
        }
    }
}