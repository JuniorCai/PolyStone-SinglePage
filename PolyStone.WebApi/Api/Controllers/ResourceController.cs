using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Abp.Web.Models;
using Abp.WebApi.Authorization;
using PolyStone.Helpers;

namespace PolyStone.Api.Controllers
{
    [AbpApiAuthorize()]
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

            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            HttpRequestBase request = context.Request;
            var files = request.Files;


            string rootPath = HttpContext.Current.Server.MapPath("/");
//            var provider = new MultipartFormDataStreamProvider(rootPath);
//            await Request.Content.ReadAsMultipartAsync(provider);
//            var file = provider.FileData[0];
//            var fileInfo = new FileInfo(file.LocalFileName);
//            var image = Image.FromStream(fileInfo.OpenRead());

            ImgUploadHelper uploadHelper = new ImgUploadHelper(request.Files, rootPath);
            var result = uploadHelper.UploadImg();
            
            string msg = result.Item1 == ImageUploadStatus.Success ? (uploadHelper.FileServer + result.Item2) : result.Item2;


            return new AjaxResponse(new {success = result.Item1 == ImageUploadStatus.Success, msg = msg});
            //return Json(new { success = result.Item1 == ImageUploadStatus.Success, msg = msg });
        }
    }
}