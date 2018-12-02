using CSEBookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CSEBookBank.Controllers
{
    public class LibrarianController : Controller
    {
        private CSEBookBankDbEntities db = new CSEBookBankDbEntities();
        // GET: Librarian
        [Authorize]
        public ActionResult Index()
        {
            var stds = db.students;
            return View(stds.ToList());
        }
        [Authorize]
        public ActionResult ViewBooks()
        {
            var books = db.Books;
            return View(books.ToList());
        }
        [Authorize]
        public ActionResult AddBook()
        {
            return View();
        }
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [HttpPost, ActionName("RemoveBook")]
        [ValidateAntiForgeryToken]
        public ActionResult BookRemoved(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ViewBooks");
        }
    }
}