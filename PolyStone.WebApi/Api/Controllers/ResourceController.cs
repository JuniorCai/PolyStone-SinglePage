using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Abp.Web.Models;
using PolyStone.Web.Helpers;

namespace PolyStone.Api.Controllers
{
    public class ResourceController : PolyStoneApiControllerBase
    {
        // GET
        [HttpPost]
        public async Task<AjaxResponse> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return new AjaxResponse(new ErrorInfo("无效请求"));
            }

            string saveTempPath = 
                        ImgUploadHelper uploadHelper = new ImgUploadHelper(Request.Files, Server.MapPath("/"));
            //            var result = uploadHelper.UploadImg();
            //
            //            string msg = result.Item1 == ImageUploadStatus.Success ? (uploadHelper.FileServer + result.Item2) : result.Item2;


            return new AjaxResponse();
            //return Json(new { success = result.Item1 == ImageUploadStatus.Success, msg = msg });
        }
    }
}