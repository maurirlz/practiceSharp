using System;

namespace PolimorfismoEInjeccionDeDependencias
{
    public class App
    {
        static void Main(string[] args)
        {

            CalculateArea calculation = new CalculateArea();
            
            Square square = new Square(3);
            decimal areaOfSquare = calculation.Calculate(square);
            Console.WriteLine($"Area of the square: {areaOfSquare}");
            
            Triangle triangle = new Triangle(9, 10);
            decimal areaOfTriangle = calculation.Calculate(triangle);
            Console.WriteLine($"Area of the triangle: {areaOfTriangle}");
            
            Rectangle rectangle = new Rectangle(10, 5);
            decimal areaOfRectangle = calculation.Calculate(rectangle);
            Console.WriteLine($"Area of the rectangle: {areaOfRectangle}");
            
            Rhombus rhombus = new Rhombus(5, 3);
            decimal areaOfRhombus = calculation.Calculate(rhombus);
            Console.WriteLine($"Area of the rhombus: {areaOfRhombus}");
            
            Paralelogram paralelogram = new Paralelogram(3, 8);
            decimal areaOfParalelogram = calculation.Calculate(paralelogram);
            Console.WriteLine($"Area of the paralelogram: {areaOfParalelogram}");
        }
    }
}