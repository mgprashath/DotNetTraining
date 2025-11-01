using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Person
    {
        public string Name { get; set; }
        public int Height  { get; set; }
        public int Weight { get; set; }

        public Gender Gender { get; set; }

        public Person(string name, int height, int weight, Gender gender)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Gender = gender ;
        }
    }
}
