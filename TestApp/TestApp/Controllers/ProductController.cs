using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [Route("Details/{productName}")]
        public ActionResult Details(string productName)
        {
            var products = new[]
            {
               new{ ProductId=1, ProductName="ProductOne", Cost="50.55" },
               new{ ProductId=2, ProductName="ProductTwo", Cost="250.55" },
               new{ ProductId=3, ProductName="ProductThree", Cost="50.00" }
            };
            var item = products.FirstOrDefault(p => p.ProductName == productName);
            return Content(item?.ProductName);
        }

        [HttpGet]
        [Route("Edit/{Id:Range(0,5)}")]
        public ActionResult Edit(int? Id)
        {
            var products = new[]
            {
               new{ ProductId=1, ProductName="ProductOne", Cost="50.55" },
               new{ ProductId=2, ProductName="ProductTwo", Cost="250.55" },
               new{ ProductId=3, ProductName="ProductThree", Cost="50.00" }
            };
            var item = products.FirstOrDefault(p => p.ProductId == Id);
            return Content(item?.ProductName);
        }

        [HttpGet]
        [Route("Delete/{Cost:decimal}")]
        public ActionResult Delete(decimal? Cost)
        {
            var products = new[]
            {
               new{ ProductId=1, ProductName="ProductOne", Cost="50.55" },
               new{ ProductId=2, ProductName="ProductTwo", Cost="250.55" },
               new{ ProductId=3, ProductName="ProductThree", Cost="50.00" }
            };
            var item = products.FirstOrDefault(p => p.Cost == Cost?.ToString());
            return Content(item?.ProductName ?? "0");
        }
    }
}