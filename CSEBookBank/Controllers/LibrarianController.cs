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
        public ActionResult Index()
        {
            var stds = db.students;
            return View(stds.ToList());
        }

        //public ActionResult ViewBooks()
        //{
        //    var books = db.Books;
        //    return View(books.ToList());
        //}

        //public ActionResult AddBook()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddBook([Bind(Include = "Title,Author,Edition,BookID,ImagePath,Description")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //        return RedirectToAction("ViewBooks");
        //    }
        //    return View();
        //}


        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult AddBook([Bind(Include = "Title,Author,Edition,BookID,ImagePath")] Book book)
        //{

        //        string filename = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
        //        string extension = Path.GetExtension(book.ImageFile.FileName);
        //        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        //        book.ImagePath = "~/Image/" + filename;
        //        filename = Path.Combine(Server.MapPath("~/Image/"), filename);
        //        book.ImageFile.SaveAs(filename);
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //            db.SaveChanges();
        //            return RedirectToAction("ViewBooks");

        //    }
        //    ModelState.Clear();
        //    return View();
        //}




        [HttpPost]
        public ActionResult AddBook([Bind(Include = "Title,Author,Edition,BookID,ImagePath")] Book book)
        {

            try
            {
                string filename = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string extension = Path.GetExtension(book.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                book.ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image"), filename);
                book.ImageFile.SaveAs(filename);
                using (CSEBookBankDbEntities db = new CSEBookBankDbEntities())
                {
                    if (db.Books.Any(x => x.Title == book.Title))
                    {
                        ViewBag.DuplicateMessage = "CityName already exist.";
                        return View(book);
                    }
                    db.Books.Add(book);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return View(ex);

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful";
            return RedirectToAction("ViewBooks");


        }


	[HttpGet]
        public ActionResult ViewBooks(int id)
        {
            Book book = new Book();
            using (CSEBookBankDbEntities db = new CSEBookBankDbEntities())
            {
                book = db.Books.Where(x => x.BookID == id).FirstOrDefault();

            }
            return View(book);
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
    }
}
