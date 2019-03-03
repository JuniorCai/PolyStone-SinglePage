using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolyStone.Web.Helpers;

namespace PolyStone.Web.Controllers
{
    public class ResourceController : PolyStoneControllerBase
    {
        // GET: Resource
        [HttpPost]
        public JsonResult Upload()
        {
            ImgUploadHelper uploadHelper = new ImgUploadHelper(Request.Files, Server.MapPath("/"));
            var result = uploadHelper.UploadImg();

            //string msg = result.Item1 == ImageUploadStatus.Success ? (uploadHelper.FileServer + result.Item2) : result.Item2;

            return Json(new { success = result.Item1 == ImageUploadStatus.Success, msg = result.Item2 });
        }
    }
}