using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This App has OCDCS Internal Application Systems.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = " Oregon Child Development Coalition - Cultivating our Children’s Future";

            return View();
        }
    }
}