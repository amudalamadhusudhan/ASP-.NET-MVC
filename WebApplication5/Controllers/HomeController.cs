using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public FileContentResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application madhusudhan page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page madhusudhan.";

            return View();
        }
    }
}