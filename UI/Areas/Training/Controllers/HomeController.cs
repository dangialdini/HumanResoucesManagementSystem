using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Training.Controllers
{
    public class HomeController : Controller
    {
        // GET: Training/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}