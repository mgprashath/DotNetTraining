using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("Index")]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("About")]
        public ActionResult About()
        {
            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Profile")]
        public ActionResult ProfileData()
        {
            return View();
        }
    }
}