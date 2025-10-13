using EmployeePayrollSystem;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> lstEmp = new List<Employee>() {
            new Manager("Jhon", 50050.50m),
            new Developer("Jane", 39000.50m),
            new Intern("Jean", 10000.50m),
            new Developer("Brew", 35000.00m),
            new Intern("Clutchcher", 10000.50m)
        };

        foreach (Employee emp in lstEmp) { 
            Console.WriteLine($"Employee {emp.Name} has a base salary {emp.BaseSalary} and a net salary of {emp.CalculateSalary()} who is a {emp.Designation}");
            WriteToPayroll(emp);
        }

        Console.ReadLine();
    }

    public static void WriteToPayroll(Employee emp)
    {
        string curDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(curDir, "Files\\Payroll.txt");

        FileInfo fi = new FileInfo(path);

        if (!fi.Exists)
        {
            fi.Create().Close();
        }

        using (StreamWriter writer = fi.AppendText())
        {
            writer.WriteLine($"Name: {emp.Name}");
            writer.WriteLine($"Base salary: {emp.BaseSalary}");
            writer.WriteLine($"Net salary: {emp.CalculateSalary()}");
            writer.WriteLine($"Designation: {emp.Designation}");
            writer.WriteLine();
        }
    }
}
