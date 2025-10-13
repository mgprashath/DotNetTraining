using ShapeAreaCalculator;
using System;

class Program
{
    
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape> { new Circle(5.5), new Rectangle(4,5), new Triangle(4,5) };
        foreach (Shape shape in shapes) {
            shape.WriteToFile();
            shape.DisplayShape();
        }

        Console.ReadLine();
    }
}
