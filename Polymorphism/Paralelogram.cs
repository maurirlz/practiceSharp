namespace PolimorfismoEInjeccionDeDependencias
{
    public class Paralelogram : IShape
    {
        private readonly decimal _paralelogramBase;
        private readonly decimal _paralelogramHeight;

        public Paralelogram(decimal paralelogramBase, decimal paralelogramHeight)
        {
            _paralelogramBase = paralelogramBase;
            _paralelogramHeight = paralelogramHeight;
        }

        public decimal GetArea()
        {
            return _paralelogramBase * _paralelogramHeight;
        }
    }
}