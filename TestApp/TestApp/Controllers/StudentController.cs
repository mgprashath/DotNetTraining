using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        [Route("Student/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Student/Create")]
        public ActionResult Create([ModelBinder(typeof(CustomBinder))] Student student)
        {
            return View();
        }
    }
}