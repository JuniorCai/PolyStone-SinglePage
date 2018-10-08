using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using PolyStone.Authorization.Users;
using PolyStone.Companies;
using PolyStone.Companies.Dtos;
using PolyStone.CompanyAuthes;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CompanyContacts;
using PolyStone.CompanyIndustries;
using PolyStone.CompanyIndustries.Dtos;
using PolyStone.Users;
using PolyStone.Users.Dto;

namespace PolyStone.Web.Controllers
{
    public class CompanyController : PolyStoneControllerBase
    {
        private readonly ICompanyAppService _companyService;
        private readonly ICompanyAuthAppService _companyAuthAppService;
        private readonly IContactAppService _contactAppService;
        private readonly ICompanyIndustryAppService _companyIndustryAppService;
        private readonly IUserAppService _userAppService;

        public CompanyController(ICompanyAppService companyAppService, ICompanyAuthAppService companyAuthAppService,IContactAppService contactAppService,ICompanyIndustryAppService companyIndustryAppService,IUserAppService userAppService)
        {
            _companyService = companyAppService;
            _companyAuthAppService = companyAuthAppService;
            _contactAppService = contactAppService;
            _companyIndustryAppService = companyIndustryAppService;
            _userAppService = userAppService;
        }


        // GET: Company
        [HttpPost]
        public async Task<JsonResult> CreateCompany(CreateOrUpdateCompanyInput model)
        {
            if (PermissionChecker.IsGranted("Pages.Company.CreateCompany"))
            {
                
                try
                {
                    var oldCompany = await _companyService.GetCompanyByUserId(model.CompanyEditDto.UserId);
                    if (oldCompany != null)
                    {
                        return Json(new { success = false, msg = "存在该用户已关联的企业" });
                    }

                    CheckModelState();

                    using (var unitWork = UnitOfWorkManager.Begin())
                    {
                        var newModel = await _companyService.CreateCompanyAsync(model.CompanyEditDto);
                        if (newModel.Id > 0)
                        {
                            List<string> industryIds = newModel.Industry.Split(',').ToList();
                            foreach (string industryId in industryIds)
                            {
                                CreateOrUpdateCompanyIndustryInput industryInput = new CreateOrUpdateCompanyIndustryInput();
                                CompanyIndustryEditDto dto = new CompanyIndustryEditDto(){CompanyId = newModel.Id.Value,IndustryId = int.Parse(industryId)};
                                industryInput.CompanyIndustryEditDto = dto;
                                await _companyIndustryAppService.CreateOrUpdateCompanyIndustryAsync(industryInput);
                            }

                            var loginUser = _userAppService.Get(new EntityDto<long> {Id = AbpSession.UserId.Value}).Result;
                            loginUser.UserType = UserType.Company;

                            if (model.CompanyAuthEditDto != null)
                            {
                                loginUser.UserType = UserType.VipCompany;
                                model.CompanyAuthEditDto.CompanyId = newModel.Id.Value;
                                var newAuthModel =
                                    await _companyAuthAppService.CreateCompanyAuthAsync(model.CompanyAuthEditDto);
                            }

                            var user = _userAppService.UpdateUser(loginUser);


                            if (model.ContactEdit != null )
                            {
                                var contactEditDto = model.ContactEdit;
                                contactEditDto.CompanyId = newModel.Id.Value;
                                var newContactModel = await _contactAppService.CreateContactAsync(contactEditDto);
                                if (contactEditDto.IsDefault)
                                {
                                    await _contactAppService.SetContactDefault(newContactModel.CompanyId,
                                        newContactModel.Id.Value);
                                }
                            }
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



        [HttpPost]
        public async Task<JsonResult> SaveCompany(CreateOrUpdateCompanyInput model)
        {
            if (PermissionChecker.IsGranted("Pages.Company.EditCompany"))
            {

                try
                {
                    var oldCompany = await _companyService.GetCompanyByUserId(model.CompanyEditDto.UserId);
                    if (oldCompany == null || oldCompany.Id != model.CompanyEditDto.Id)
                    {
                        return Json(new {success = false, msg = "不存在操作对象"});
                    }

                    CheckModelState();

                    using (var unitWork = UnitOfWorkManager.Begin())
                    {

                        await _companyService.UpdateCompanyAsync(model.CompanyEditDto);

                        await _companyIndustryAppService.DeleteCompanyIndustryByCompanyIdAsync(model.CompanyEditDto.Id.Value);
                        List<string> industryIds = model.CompanyEditDto.Industry.Split(',').ToList();
                        foreach (string industryId in industryIds)
                        {
                            CreateOrUpdateCompanyIndustryInput industryInput = new CreateOrUpdateCompanyIndustryInput();
                            CompanyIndustryEditDto dto = new CompanyIndustryEditDto() { CompanyId = model.CompanyEditDto.Id.Value, IndustryId = int.Parse(industryId) };
                            industryInput.CompanyIndustryEditDto = dto;
                            await _companyIndustryAppService.CreateOrUpdateCompanyIndustryAsync(industryInput);
                        }

                        var loginUser = _userAppService.Get(new EntityDto<long> { Id = AbpSession.UserId.Value }).Result;
                        loginUser.UserType = UserType.Company;

                        if (model.CompanyAuthEditDto != null)
                        {
                            loginUser.UserType = UserType.VipCompany;
                            await _companyAuthAppService.CreateOrUpdateCompanyAuthAsync(new CreateOrUpdateCompanyAuthInput(){CompanyAuthEditDto = model.CompanyAuthEditDto });
                        }

                        var user = _userAppService.UpdateUser(loginUser);


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



//        public async Task<JsonResult> DeleteCompany(int companyId)
//        {
//            //var companyDto = 
//        }
    }
}