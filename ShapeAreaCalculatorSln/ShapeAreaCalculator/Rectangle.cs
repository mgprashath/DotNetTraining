using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace ShapeAreaCalculator
{
    internal class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int width, int height) : base(ShapeType.Rectangle)
        {
            Width = width;
            Height = height;
            CalculateArea();
        }
        protected override void CalculateArea()
        {
            Area = Width*Height;
        }
    }
}
