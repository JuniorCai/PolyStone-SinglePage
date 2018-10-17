using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolyStone.CompanyApplications;

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
        public ActionResult Save()
        {
            return View();
        }
    }
}