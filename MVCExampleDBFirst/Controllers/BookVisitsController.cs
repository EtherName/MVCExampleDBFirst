using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCExampleDBFirst.EntityDataModel;

namespace MVCExampleDBFirst.Controllers
{
    public class BookVisitsController : Controller
    {
        private BooksStorageEntities db = new BooksStorageEntities();

        // GET: BookVisits
        public ActionResult Index()
        {
            var bookVisits = db.BookVisits.Include(b => b.BookStorage);
            return View(bookVisits.ToList());
        }

        // GET: BookVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVisits bookVisits = db.BookVisits.Find(id);
            if (bookVisits == null)
            {
                return HttpNotFound();
            }
            return View(bookVisits);
        }

        // GET: BookVisits/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.BookStorage, "BookId", "Name");
            return View();
        }

        // POST: BookVisits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Visit")] BookVisits bookVisits)
        {
            if (ModelState.IsValid)
            {
                db.BookVisits.Add(bookVisits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.BookStorage, "BookId", "Name", bookVisits.BookId);
            return View(bookVisits);
        }

        // GET: BookVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVisits bookVisits = db.BookVisits.Find(id);
            if (bookVisits == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.BookStorage, "BookId", "Name", bookVisits.BookId);
            return View(bookVisits);
        }

        // POST: BookVisits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Visit")] BookVisits bookVisits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookVisits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.BookStorage, "BookId", "Name", bookVisits.BookId);
            return View(bookVisits);
        }

        // GET: BookVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVisits bookVisits = db.BookVisits.Find(id);
            if (bookVisits == null)
            {
                return HttpNotFound();
            }
            return View(bookVisits);
        }

        // POST: BookVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookVisits bookVisits = db.BookVisits.Find(id);
            db.BookVisits.Remove(bookVisits);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
