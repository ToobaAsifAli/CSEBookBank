using CSEBookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Librarian/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Librarian/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Librarian/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Librarian/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Librarian/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Librarian/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Librarian/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
