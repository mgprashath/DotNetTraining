using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    internal class Developer : Employee
    {
        public Developer(string name, decimal baseSalary) : base(name, baseSalary, Designation.Develpoer)
        {

        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + BaseSalary * 0.1m;
        }
    }
}
