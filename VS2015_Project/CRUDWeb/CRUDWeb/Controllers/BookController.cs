using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWeb.Models;
using CRUDWeb.DAL;
using System.Net;
using System.Data.Entity;

namespace CRUDWeb.Controllers
{
    public class BookController : Controller
    {
        private BSDBContext db = new BSDBContext();
        // GET: Book
        public ActionResult GetBooks()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        public ActionResult Detail(Guid? Id)
        {
            var book = db.Books.Where(p => p.Id == Id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            book.Id = Guid.NewGuid();
            book.Created = DateTime.Now;
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("GetBooks");
        }

        public ActionResult Edit(Guid? Id)
        {
            if(!Id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books.Where(p => p.Id == Id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("GetBooks");
        }

        public ActionResult Delete(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books.Where(p => p.Id == Id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(Guid Id)
        {
            var book = db.Books.Where(p => p.Id == Id).FirstOrDefault();
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("GetBooks");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}