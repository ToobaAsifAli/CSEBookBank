using CSEBookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEBookBank.Controllers
{
    public class HomeController : Controller
    {
        private CSEBookBankDbEntities db = new CSEBookBankDbEntities();
        public ActionResult Index()
        {
            var books = db.Books;
            return View(books.ToList());
        }

        public ActionResult IssueBook()
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