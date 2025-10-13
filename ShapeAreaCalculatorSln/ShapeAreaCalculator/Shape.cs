using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace ShapeAreaCalculator
{
    public enum ShapeType
    {
        Circle = 1,
        Rectangle = 2,
        Triangle = 3
    }
    internal abstract class Shape
    {
        public double Area { get; protected set; }
        public ShapeType Type { get; }

        public Shape(ShapeType type) { 
            Type = type;
        }
        protected abstract void CalculateArea();

        public void WriteToFile()
        {
            string currentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(currentDir, "Files\\Areas.txt");

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists) {
                using (StreamWriter writer = fileInfo.AppendText())
                {
                    writer.WriteLine($"Area of {Type} is {Area}");
                }
            }else
                fileInfo.Create().Close();
        }

        public void DisplayShape()
        {
            Console.WriteLine($"{Type} Area is {Area}");
        }
    }
}
