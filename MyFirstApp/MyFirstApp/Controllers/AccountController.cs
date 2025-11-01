using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string UserName, string Password)
        {
            if (UserName == "admin" && Password == "password")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid credentials. Please try again.";
            }
            return View();
        }
    }
}