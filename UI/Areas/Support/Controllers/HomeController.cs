using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Support.Controllers
{
    public class HomeController : Controller
    {
        // GET: Support/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}