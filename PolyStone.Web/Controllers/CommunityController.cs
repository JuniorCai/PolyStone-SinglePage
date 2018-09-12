using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Authorization;
using Abp.Web.Models;
using Abp.WebApi.Authorization;
using Abp.WebApi.Controllers;
using PolyStone.Communities;
using PolyStone.Communities.Dtos;
using PolyStone.CommunityCategories;
using PolyStone.CustomDomain.Products;
using PolyStone.Web.Models;

namespace PolyStone.Web.Controllers
{

    public class CommunityController : PolyStoneControllerBase
    {

        private readonly ICommunityAppService _communityAppService;
        private readonly ICommunityCategoryAppService _communityCategoryAppService;

        public CommunityController(ICommunityAppService communityAppService,
            ICommunityCategoryAppService communityCategoryAppService)
        {
            _communityAppService = communityAppService;
            _communityCategoryAppService = communityCategoryAppService;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CreateCommunity")]
        public async Task<JsonResult> CreateCommunity(CommunityEditDto model)
        {
            if (PermissionChecker.IsGranted("Pages.Community.CreateCommunity"))
            {
                model.ReleaseStatus = ReleaseStatus.Publish;
                model.VerifyStatus = VerifyStatus.Pass;
                model.RefreshDate = DateTime.Now;

                try
                {
                    var edit = await _communityAppService.CreateCommunityAsync(model);
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
        public async Task<JsonResult> UpdateCommunity(CommunityEditDto model)
        {
            if (PermissionChecker.IsGranted("Pages.Community.EditCommunity"))
            {
                model.RefreshDate = DateTime.Now;

                CheckModelState();

                
                try
                {
                    await _communityAppService.UpdateCommunityAsync(model);
                    return Json(new { success = true, msg = "" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, msg = "保存失败" });
                }
            }
            return Json(new { success = false, msg = "保存失败" });
        }


        public async Task<JsonResult> SearchCommunity(GetCommunityInput searchModel)
        {

        }

    }
}
