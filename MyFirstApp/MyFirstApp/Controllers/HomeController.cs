using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetEmpName(int EmpId)
        {
            var employee = new[] { 
                new { EmpId = 1, GetEmpName = "Jhon", Salary = 8000 },
                new { EmpId = 2, GetEmpName = "Smith", Salary = 9000 },
                new { EmpId = 3, GetEmpName = "David", Salary = 10000 },
                new { EmpId = 4, GetEmpName = "Allen", Salary = 11000 },
                new { EmpId = 5, GetEmpName = "Mark", Salary = 12000 }
            };

            return new ContentResult() { Content = employee.Where(e => e.EmpId == EmpId)
                .FirstOrDefault()?.GetEmpName, ContentType = "text/plain" };
        }

        public ActionResult GetEmpSalary(int EmpId)
        {
            string fileName = @"~/Files/"+ "PaySlip" + EmpId + ".pdf";
            return new FilePathResult(fileName, "application/pdf");
        }

        public ActionResult GetEmpFacbook(int EmpId)
        {

            var fbUrl = "https://www.facebook.com/emp" + EmpId;

            return Redirect(fbUrl);
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentID= 101;
            ViewBag.StudentName = "Jhon";
            ViewBag.StudentAge = 25;
            ViewBag.Marks = 550;
            ViewBag.Subjects = new string[] {"Maths", "Computer","Biology","Art" };

            return View();
        }
    }
}