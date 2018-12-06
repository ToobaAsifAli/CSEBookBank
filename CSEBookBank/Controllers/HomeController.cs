using CSEBookBank.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult IssueBook(int? BookID)
        {
            if (BookID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(BookID);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IssueBook(int BookID)
        {
            string UsrName = User.Identity.GetUserName();
            Book b = new Book();
            b = db.Books.Find(BookID);
            String title = b.Title;
            Request Rqst = new Request();
            Rqst.RqstMessage = UsrName + " Wants to issue " + title +" " +BookID;
            Rqst.BookId = b.BookID;
            Rqst.UserName = UsrName;
            db.Requests.Add(Rqst);
            db.SaveChanges();
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