using EntityFrameworkDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDBFirst.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            List<Category> categories = eFDBFirstDatabaseEntities.Categories.ToList();

            return View(categories);
        }
    }
}