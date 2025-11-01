using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Route("Index")]
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, Name = "Alice", Position = "Developer", DOB = new DateTime(1990,01,25) },
                new Employee { EmployeeId = 2, Name = "Bob", Position = "Designer", DOB = new DateTime(1985,02,01) },
                new Employee { EmployeeId = 3, Name = "Charlie", Position = "Manager", DOB = new DateTime(1989,03,12) },
                new Employee { EmployeeId = 4, Name = "Jhon", Position = "Programmer", DOB = new DateTime(1995,08,30) },
                new Employee { EmployeeId = 5, Name = "Ann", Position = "Web Developer", DOB = new DateTime(1999,12,12) }
            };
            return View(employees);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update([Bind(Exclude ="DOB")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}

// [Bind(include="Name, EmployeeId, Position")]