using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Management.Controllers
{
    public class PositionController : Controller
    {
        // GET: Management/Positions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterEmployeeInPosition()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ViewBag.id =id.Value;
            return View();
        }
    }
}