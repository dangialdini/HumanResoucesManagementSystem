using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Management.Controllers
{
    public class HomeController : Controller
    {
        // GET: Management/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}