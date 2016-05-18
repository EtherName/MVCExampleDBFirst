using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExampleDBFirst.EntityDataModel;
using MVCExampleDBFirst.Utilities;

namespace MVCExampleDBFirst.Controllers
{
    public class BooksController : Controller
    {
        BooksStorageEntities context = new BooksStorageEntities();
        // GET: Books
        public ActionResult Index()
        {
            return View(context.BookStorage);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            BookVisits bookVis = context.BookVisits.First(x => x.BookId == id);
            context.BookVisits.First(x => x.BookId == id).Visit++;
            context.SaveChanges();
            return View(bookVis);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(BookStorage bookStor)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();
                context.BookStorage.Add(bookStor.Name, bookStor.Author);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();
            BookStorage bookStor = context.BookStorage.First(x => x.BookId == id);
            return View(bookStor);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookStorage bookStor)
        {
            try
            {
                // TODO: Add update logic here
                context.BookStorage.First(x => x.BookId == id).Name= bookStor.Name;
                context.BookStorage.First(x => x.BookId == id).Author = bookStor.Author;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            BookStorage bookStor = context.BookStorage.First(x => x.BookId == id);
            return View(bookStor);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BookStorage bookStor = context.BookStorage.First(x => x.BookId == id);
                BookVisits bookVis = context.BookVisits.First(x => x.BookId == bookStor.BookId);
                context.BookStorage.Remove(bookStor);
                context.BookVisits.Remove(bookVis);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
