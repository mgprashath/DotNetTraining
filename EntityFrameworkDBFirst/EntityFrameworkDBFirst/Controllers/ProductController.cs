using EntityFrameworkDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDBFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string productName = "")
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            List<Product> products = eFDBFirstDatabaseEntities.Products.Where(u=>u.ProductName.Contains(productName)).ToList();

            ViewBag.Search = productName;

            return View(products);
        }

        public ActionResult Details(int id)
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            Product product = eFDBFirstDatabaseEntities.Products.Where(u => u.ProductID == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Category> categories = new EFDBFirstDatabaseEntities().Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");

            List<Brand> brands = new EFDBFirstDatabaseEntities().Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "BrandID", "BrandName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            eFDBFirstDatabaseEntities.Products.Add(product);
            eFDBFirstDatabaseEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            Product product = eFDBFirstDatabaseEntities.Products.Where(u => u.ProductID == id).FirstOrDefault();
            eFDBFirstDatabaseEntities.Products.Remove(product);
            eFDBFirstDatabaseEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            Product product = eFDBFirstDatabaseEntities.Products.Where(u => u.ProductID == id).FirstOrDefault();

            List<Category> categories = new EFDBFirstDatabaseEntities().Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");

            List<Brand> brands = new EFDBFirstDatabaseEntities().Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "BrandID", "BrandName");

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            EFDBFirstDatabaseEntities eFDBFirstDatabaseEntities = new EFDBFirstDatabaseEntities();
            
            Product existingProduct = eFDBFirstDatabaseEntities.Products.Where(u => u.ProductID == product.ProductID).FirstOrDefault();
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.DateOfPurchase = product.DateOfPurchase;
            existingProduct.AvailabilityStatus = product.AvailabilityStatus;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.BrandID = product.BrandID;
            existingProduct.Active = product.Active;

            eFDBFirstDatabaseEntities.SaveChanges();

            return View(existingProduct);
        }
    }
}