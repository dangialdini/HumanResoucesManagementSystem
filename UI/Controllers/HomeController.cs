using Services.Repositories;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAddressService _serviceTest;
        private readonly IPositionService _servicePosition; 
        //private readonly IEnhancementRequestService _serviceTest;

        public HomeController(IAddressService serviceTest, IPositionService servicePosition)
        {
            _serviceTest = serviceTest;
             _servicePosition = servicePosition;
        }

        public ActionResult Index()
        {
            var x = _serviceTest; 

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}