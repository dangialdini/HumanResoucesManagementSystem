using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Sales.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Sales/Quote
        public ActionResult Index()
        {
            return View();
        }
    }
}