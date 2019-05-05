using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWeb.Models;
using CRUDWeb.DAL;
using System.Net;

namespace CRUDWeb.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult GetBooks()
        {
            Book b = new Book()
            {
                Id = Guid.NewGuid(),
                Author = "kane",
                Name = "mvc",
                Page = 10,
                Price = 100.0,
                Publisher = "abc",
                Created = DateTime.Now,
                Description = "good book"
            };

            List<Book> books = new List<Book>();
            books.Add(b);
            return View(books);
        }

        public ActionResult CreateBook()
        {
            return View();
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
            return RedirectToAction("GetBooks");
        }
    }
}