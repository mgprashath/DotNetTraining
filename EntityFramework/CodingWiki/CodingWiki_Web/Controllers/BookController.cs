using CodingWiki_DataAccess.Data;
using CodingWiki_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _db;
        public BookController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var books = _db.Books;
            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            BookViewModel bookViewModel = new();

            bookViewModel.Book = _db.Books.Find(id);
            bookViewModel.PublisherList = _db.Publishers.Select(i=> new SelectListItem() {
                Text=i.Name,
                Value= i.Publisher_Id.ToString()
            });

            if(id==null || id == 0)
            {
                return View(bookViewModel);
            }

            bookViewModel.Book = _db.Books.FirstOrDefault(u=>u.BookId==id);

            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel bookViewModel)
        {
            if (bookViewModel.Book.BookId==0)
            {
                _db.Books.Add(bookViewModel.Book);
            }
            else
            {
                _db.Books.Update(bookViewModel.Book);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
