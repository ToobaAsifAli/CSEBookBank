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
    [Authorize(Roles = "Librarian")]
    public class LibrarianController : Controller
    {
        private CSEBookBankDbEntities db = new CSEBookBankDbEntities();
        // GET: Librarian
        public ActionResult Index()
        {
            var stds = db.students;
            return View(stds.ToList());
        }
        //public ActionResult Index()
        //{
        //    using (CSEBookBankDbEntities db = new CSEBookBankDbEntities())
        //    {
        //        return View(db.AspNetUsers.ToList());
        //    }
        //    //    var stds = db.students;
        //    //return View(stds.ToList());
        //}


        public ActionResult ViewBooks()
        {
            var books = db.Books;
            return View(books.ToList());
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook([Bind(Include = "Title,Author,Edition,BookID,ImagePath,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("ViewBooks");
            }
            return View();
        }

        public ActionResult RemoveBook(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("RemoveBook")]
        [ValidateAntiForgeryToken]
        public ActionResult BookRemoved(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ViewBooks");
        }

        public ActionResult Requests()
        {
            var rqst = db.Requests;
            return View(rqst.ToList());
        }
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            Request rqst = db.Requests.Find(id);
            if (book == null || Request == null)
            {
                return HttpNotFound();
            }
            book.IssuedTo = rqst.UserName;
            DateTime currentTime = DateTime.Now;
            book.IssuedDate = currentTime;
            book.DueDate = currentTime.AddDays(1);
            db.Requests.Remove(rqst);
            db.SaveChanges();
            return View();
        }
        public ActionResult Deny(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            Request rqst = db.Requests.Find(id);
            if (book == null || Request == null)
            {
                return HttpNotFound();
            }
            db.Requests.Remove(rqst);
            db.SaveChanges();
            return RedirectToAction("Requests");
        }

        public ActionResult IssuedBooks()
        {
            List<Book> list = new List<Book>();
            foreach (Book book in db.Books)
            {
                if (book.IssuedTo != null)
                {
                    list.Add(book);
                }
            }
            return View(list);
        }

        public ActionResult Reminder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            Notification not = new Notification();
            not.BookId = book.BookID;
            not.UserName = book.IssuedTo;
            not.NotMessage = "Dear Student, You have issued the " + book.Title + " book on " + book.IssuedDate + ". And the date of returning this book is approaching. Kindly return this book before the due date. The due date is " + book.DueDate;
            db.Notifications.Add(not);
            db.SaveChanges();
            
            return RedirectToAction("IssuedBooks");
            
        }
        [ValidateInput(false)]
        public async ActionResult Search(string text)
        {
            var book = from b in db.Books select b;
            
            if (!String.IsNullOrEmpty(text))
            {
                book = book.Where(s => s.Title.Contains(text));
            }

            return View(book);
        }
        [ValidateInput(false)]
        public async ActionResult Search(string text)
        {
            var std = from s in db.students select s;

            if (!String.IsNullOrEmpty(text))
            {
                std = std.Where(s => s.Title.Contains(text));
            }

            return View(std);
        }

    }
        }
    }
}
