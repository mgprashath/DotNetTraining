using EntityFrameworkDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDBFirst.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            List<Brand> brands = eFDBFirstDatabaseEntities.Brands.ToList();

            return View(brands);
        }
    }
}