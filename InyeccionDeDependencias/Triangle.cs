namespace PolimorfismoEInjeccionDeDependencias
{
    public class Triangle : IShape
    {
        private readonly decimal _triangleBase;
        private readonly decimal _triangleHeight;

        public Triangle(decimal triangleBase, decimal triangleHeight)
        {
            _triangleBase = triangleBase;
            _triangleHeight = triangleHeight;
        }

        public decimal GetArea()
        {
            
            return (_triangleBase * _triangleHeight) / 2;
        }
    }
}