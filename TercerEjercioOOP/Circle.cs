using System;

namespace TercerEjercioOOP
{
    public class Circle : Shape
    {

        private double radius;
        
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetPerimeter()
        {
            return Math.PI * 2 * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}