using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManager
{
    internal class Student : Person
    {
        public string Course { get; set; } = String.Empty;
        public Grade Grade { get; set; }
        public Student(string name, string course, Grade grade) : base(name)
        {
            Course = course;
            Grade = grade;
        }        

        public override void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name} got a grade: {Grade} in {Course}");
        }
       
    }
}
