using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManager
{
    internal abstract class Person
    {
        public string Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public Person(string name) {
            Id= Guid.NewGuid().ToString(); 
            Name= name;       
        }

        public abstract void DisplayInfo();
    }
}
