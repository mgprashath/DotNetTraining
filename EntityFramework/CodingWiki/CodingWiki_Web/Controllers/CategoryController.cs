using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> Category = _db.Categories.OrderBy(u=>u.DisplayOrder).ToList();
            return View(Category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Category category = _db.Categories.SingleOrDefault(u=>u.CategoryId == id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();

            return View(category);
        }

        public IActionResult Details(int? id)
        {
            Category category = _db.Categories.SingleOrDefault(u=>u.CategoryId == id);
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            Category category = _db.Categories.SingleOrDefault(u=>u.CategoryId==id);

            _db.Categories.Remove(category);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();  

            return RedirectToAction("Index");
        }

        public IActionResult CreateFive()
        {
            int maxOrder = _db.Categories.Max(u=>u.DisplayOrder);
            for (int i=1; i<6; i++)
            {
                _db.Categories.Add(new Category(){ CategoryName= Guid.NewGuid().ToString() , DisplayOrder= maxOrder + i });
            }
           
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteLastFive()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(u=>u.DisplayOrder).Take(5);

            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
