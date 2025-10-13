using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    internal class Intern : Employee
    {
        public Intern(string name, decimal baseSalary) : base(name, baseSalary, Designation.Intern)
        {

        }
        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
