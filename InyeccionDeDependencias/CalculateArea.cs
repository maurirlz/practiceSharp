namespace PolimorfismoEInjeccionDeDependencias
{
    public class CalculateArea
    {
        private IShape _areaCalculation;
        
        public decimal Calculate(IShape areaCalculation)
        {
            _areaCalculation = areaCalculation;
            return _areaCalculation.GetArea();
        }
    }
}