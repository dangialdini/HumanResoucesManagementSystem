using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Support.Controllers
{
    public class TicketController : Controller
    {
        // GET: Support/Ticket
        public ActionResult Index()
        {
            return View();
        }
    }
}