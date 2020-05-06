namespace TercerEjercioOOP
{
    public class Square : Shape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public double GetPerimeter()
        {

            return side * 4;
        }

        public double GetArea()
        {

            return side * side;
        }
    }
}