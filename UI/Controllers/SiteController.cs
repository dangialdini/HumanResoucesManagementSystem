using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class SiteController : Controller
    {
        // GET: Management/Site
        public ActionResult Index()
        {
            return View();
        }
    }
}