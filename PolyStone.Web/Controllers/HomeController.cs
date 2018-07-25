using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace PolyStone.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PolyStoneControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}