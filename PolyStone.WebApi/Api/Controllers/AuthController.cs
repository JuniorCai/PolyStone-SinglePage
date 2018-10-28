using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Models;
using Abp.WebApi.Controllers;

namespace PolyStone.Api.Controllers
{
    public class AuthController : AbpApiController
    {
        // GET
        public async Task<AjaxResponse> CheckUserValid(string loginCode)
        {
            return
            View();
        }
    }
}