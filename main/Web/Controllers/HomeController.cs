﻿using System.Web.Mvc;

namespace UIT.iDeal.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Administration()
        {
            return View();
        }
    }
}
