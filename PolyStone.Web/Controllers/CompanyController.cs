using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization;
using PolyStone.Companies;
using PolyStone.Companies.Dtos;
using PolyStone.CompanyAuthes;

namespace PolyStone.Web.Controllers
{
    public class CompanyController : PolyStoneControllerBase
    {
        private readonly ICompanyAppService _companyService;
        private readonly ICompanyAuthAppService _companyAuthAppService;
//        private readonly ICompany

        public CompanyController(ICompanyAppService companyAppService, ICompanyAuthAppService companyAuthAppService)
        {
            _companyService = companyAppService;
            _companyAuthAppService = companyAuthAppService;
        }


        // GET: Company
        [HttpPost]
        public async Task<JsonResult> CreateCompany(CreateOrUpdateCompanyInput model)
        {
            if (PermissionChecker.IsGranted("Pages.Company.CreateCompany"))
            {
                
                try
                {
                    var oldCompany = await _companyService.GetCompanyByUserId(model.CompanyEditDto.MemberId);
                    if (oldCompany != null)
                    {
                        return Json(new { success = false, msg = "存在该用户已关联的企业" });
                    }

                    CheckModelState();

                    var newModel = await _companyService.CreateCompanyAsync(model.CompanyEditDto);

                    if (model.CompanyAuthEditDto != null && newModel.Id > 0)
                    {
                        model.CompanyAuthEditDto.CompanyId = newModel.Id.Value;
                        var newAuthModel =
                            await _companyAuthAppService.CreateCompanyAuthAsync(model.CompanyAuthEditDto);
                    }
                    return Json(new { success = true, msg = "" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, msg = "保存失败" });
                }
            }
            return Json(new { success = false, msg = "无操作权限" });
        }


//        public async Task<JsonResult> DeleteCompany(int companyId)
//        {
//            //var companyDto = 
//        }
    }
}