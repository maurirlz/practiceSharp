using PolimorfismoEInjeccionDeDependencias;

namespace Polymorphism
{
    public class Square : IShape
    {
        private decimal _side;

        public Square(decimal side)
        {
            _side = side;
        }

        public decimal GetArea()
        {

            return _side * _side;
        }
    }
}