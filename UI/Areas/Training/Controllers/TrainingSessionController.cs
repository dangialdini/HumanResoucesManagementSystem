using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Training.Controllers
{
    public class TrainingSessionController : Controller
    {
        // GET: Training/TrainingSession
        public ActionResult Index()
        {
            return View();
        }
    }
}