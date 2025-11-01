using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string  Name { get; set; }
        public DateTime DOB { get; set; }
        public string Position { get; set; }
    }
}