using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEBookBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyBooks()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }
        public ActionResult Notifications()
        {
            return View();
        }
    }
}