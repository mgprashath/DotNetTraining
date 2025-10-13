using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class Triangle : Shape
    {
        public int Base { get; set; }
        public int Height { get; set; }

        public Triangle(int @base, int height): base(ShapeType.Triangle)
        {
            Base = @base;
            Height = height;
            CalculateArea();
        }
        protected override void CalculateArea()
        {
            Area = 0.5 * Base * Height;
        }
    }
}
