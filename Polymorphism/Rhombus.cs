namespace PolimorfismoEInjeccionDeDependencias
{
    public class Rhombus : IShape
    {
        private readonly decimal _firstDiagonal;
        private readonly decimal _secondDiagonal;

        public Rhombus(decimal firstDiagonal, decimal secondDiagonal)
        {
            _firstDiagonal = firstDiagonal;
            _secondDiagonal = secondDiagonal;
        }

        public decimal GetArea()
        {

            return (_firstDiagonal * _secondDiagonal) / 2;
        }
    }
}