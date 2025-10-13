using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace ShapeAreaCalculator
{
    internal class Circle : Shape
    {
        private static readonly double PI = 3.14;
        private double Radious = 0;

        public Circle(double radious) : base(ShapeType.Circle){ 
            Radious = radious;
            CalculateArea();
        }
        protected override void CalculateArea()
        {
            Area = PI * Radious * Radious;
        }
    }
}
