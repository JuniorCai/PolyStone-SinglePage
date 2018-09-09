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
                model.ReleaseStatus = ReleaseStatus.UnPublished;
                model.VerifyStatus = VerifyStatus.Pendding;
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

        //        [HttpPost]
        //        [Route("UpdateCommunity")]
        //        public async Task<AjaxResponse> UpdateCommunity(CommunityEditDto model)
        //        {
        //            if (PermissionChecker.IsGranted("Pages.Community.CreateCommunity"))
        //            {
        //                model.ReleaseStatus = ReleaseStatus.UnPublished;
        //                model.VerifyStatus = VerifyStatus.Pendding;
        //                model.RefreshDate = DateTime.Now;
        //
        //                var edit = await _communityAppService.CreateCommunityAsync(model);
        //
        //                if (edit.Id > 0)
        //                {
        //                    return new AjaxResponse();
        //                }
        //                else
        //                {
        //                    return new AjaxResponse(new ErrorInfo("保存失败"));
        //                }
        //
        //            }
        //            return new AjaxResponse(new ErrorInfo("保存失败"));
        //        }

    }
}
