using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using PolyStone.Authorization.Users;
using PolyStone.CompanyApplications;
using PolyStone.CompanyApplications.Dtos;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CompanyIndustries.Dtos;
using PolyStone.CustomDomain.CompanyApplications;

namespace PolyStone.Web.Controllers
{
    public class CompanyApplicationController : PolyStoneControllerBase
    {
        private readonly ICompanyApplicationAppService _companyApplicationAppService;

        public CompanyApplicationController(ICompanyApplicationAppService companyApplicationAppService)
        {
            _companyApplicationAppService = companyApplicationAppService;
        }

        // GET: CompanyApplication
        public async Task<JsonResult> Save(CompanyApplicationEditDto model)
        {
            if (PermissionChecker.IsGranted("Pages.Company.EditCompany"))
            {

                try
                {
                    if (model.Id != null)
                    {
                        var oldCompany =
                            await _companyApplicationAppService.GetCompanyApplicationByIdAsync(
                                new EntityDto<int> {Id = model.Id.Value});
                        if (oldCompany == null || oldCompany.Id != model.Id.Value)
                        {
                            return Json(new {success = false, msg = "不存在操作对象"});
                        }

                    }
                    else
                    {
                        return Json(new { success = false, msg = "不存在操作对象" });
                    }
                    CheckModelState();
                    
                    using (var unitWork = UnitOfWorkManager.Begin())
                    {

                        if (model.AuthStatus == AuthStatus.Pass)
                        {

                        }
                        else
                        {
                            await _companyApplicationAppService.UpdateCompanyApplicationAsync(model);
                        }

                        


                        unitWork.Complete();
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
    }
}