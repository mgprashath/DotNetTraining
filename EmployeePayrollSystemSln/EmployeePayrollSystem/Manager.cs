using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    internal class Manager : Employee
    {
        public Manager(string name, decimal baseSalary): base(name,baseSalary, Designation.Manager){ 
        
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + BaseSalary * 0.2m;
        }
    }
}
