using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWeb.Models;
using CRUDWeb.DAL;

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
    }
}