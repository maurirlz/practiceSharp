using System;

namespace PolimorfismoEInjeccionDeDependencias
{
    public class Square : IShape
    {
        private readonly decimal _side;

        public Square(decimal side)
        {
            _side = side;
        }

        public decimal GetArea()
        {
            
            return (decimal) Math.Pow((double) _side, 2);
        }

        public decimal GetSide => _side;
    }
}