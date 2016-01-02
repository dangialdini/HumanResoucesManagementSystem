using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Development.Controllers
{
    [RoutePrefix("api/EnhancementRequestController/GetEnhancementRequest/{requestId:int}/Index")]
    public class EnhancementRequestController : Controller
    {
        // GET: Development/EnhancementRequest
        public ActionResult Index()
        {
            return View();
        }
    }
}