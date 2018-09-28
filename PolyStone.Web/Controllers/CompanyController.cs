using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization;
using PolyStone.Companies;
using PolyStone.Companies.Dtos;

namespace PolyStone.Web.Controllers
{
    public class CompanyController : PolyStoneControllerBase
    {
        private readonly ICompanyAppService _companyService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyService = companyAppService;
        }


        // GET: Company
        [HttpPost]
        public async Task<JsonResult> CreateCompany(CreateOrUpdateCompanyInput model)
        {
            if (PermissionChecker.IsGranted("Pages.Company.CreateCompany"))
            {
                
                try
                {
                    var newModel = await _companyService.CreateCompanyAsync(model.CompanyEditDto);
                    return Json(new { success = true, msg = "" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, msg = "保存失败" });
                }
            }
            return Json(new { success = false, msg = "无操作权限" });
        }
    }
}