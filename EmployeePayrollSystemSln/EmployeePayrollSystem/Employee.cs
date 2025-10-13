using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public enum Designation
    {
        Manager=1,
        Develpoer=2,
        Intern=3
    }
    internal abstract class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Designation Designation { get; set; }
        public decimal BaseSalary { get; set; }
        protected Employee(string name, decimal baseSalary, Designation designation)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            BaseSalary = baseSalary;
            Designation = designation;
        }

        public abstract decimal CalculateSalary();
    }
}
