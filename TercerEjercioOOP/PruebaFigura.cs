using System;
using System.Collections.Generic;
using System.Numerics;

namespace TercerEjercioOOP
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Shape> shapes = new List<Shape>();
           
           shapes.Add(new Circle(10));
           shapes.Add(new Triangle(10));
           shapes.Add(new Square(10));
           
           shapes.ForEach(shape => Console.WriteLine($"Area de la figura: {shape.GetArea()}"));
        }
    }
}