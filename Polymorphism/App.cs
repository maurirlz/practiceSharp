using System;
using PolimorfismoEInjeccionDeDependencias;

namespace Polymorphism
{
    class App
    {
        static void Main(string[] args)
        {
            Square square = new Square(10);
            Triangle triangle = new Triangle(5, 3);
            Paralelogram paralelogram = new Paralelogram(50, 70);
            Rectangle rectangle = new Rectangle(3, 8);
            Rhombus rhombus = new Rhombus(15, 18);
            
            CalculateArea areaCalculation = new CalculateArea();

            Console.WriteLine($"Square area: {areaCalculation.CalculateGivenShapesArea(square)}");
            Console.WriteLine($"Triangle area: {areaCalculation.CalculateGivenShapesArea(triangle)}");
            Console.WriteLine($"Paralelogram area: {areaCalculation.CalculateGivenShapesArea(paralelogram)}");
            Console.WriteLine($"Rectangle area: {areaCalculation.CalculateGivenShapesArea(rectangle)}");
            Console.WriteLine($"Rhombus area: {areaCalculation.CalculateGivenShapesArea(rhombus)}");
        }
    }
}