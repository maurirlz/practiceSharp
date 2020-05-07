using PolimorfismoEInjeccionDeDependencias;

namespace Polymorphism
{
    public class CalculateArea
    {
        private IShape _shape;

        public decimal CalculateGivenShapesArea(Square square)
        {
            _shape = square;

            return _shape.GetArea();
        }

        public decimal CalculateGivenShapesArea(Triangle triangle)
        {

            _shape = triangle;

            return _shape.GetArea();
        }

        public decimal CalculateGivenShapesArea(Rhombus rhombus)
        {

            _shape = rhombus;

            return _shape.GetArea();
        }

        public decimal CalculateGivenShapesArea(Rectangle rectangle)
        {

            _shape = rectangle;

            return _shape.GetArea();
        }

        public decimal CalculateGivenShapesArea(Paralelogram paralelogram)
        {

            _shape = paralelogram;

            return _shape.GetArea();
        }
    }
}