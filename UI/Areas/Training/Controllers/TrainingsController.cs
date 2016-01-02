using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Training.Controllers
{
    public class TrainingsController : Controller
    {
        // GET: Training/Trainings
        public ActionResult Index()
        {
            return View();
        }
    }
}