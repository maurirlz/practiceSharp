namespace PolimorfismoEInjeccionDeDependencias
{
    public class Rectangle : IShape
    {
        private readonly decimal _rectangleBase;
        private readonly decimal _height;

        public Rectangle(decimal rectangleBase, decimal height)
        {
            _rectangleBase = rectangleBase;
            _height = height;
        }

        public decimal GetArea()
        {
            
            return _rectangleBase * _height;
        }
    }
}