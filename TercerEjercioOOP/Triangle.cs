using System;

namespace TercerEjercioOOP
{
    public class Triangle : Shape
    {
        private double _leftSide;
        private double _rightSide;
        private double _base;
        private double _height;

        public Triangle(double leftSide, double rightSide, double @base, double height)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _base = @base;
            _height = height;
        }

        public Triangle(double rightSide, double @base)
        {
            _rightSide = rightSide;
            _base = @base;
        }

        public Triangle(double @base)
        {
            _base = @base;
            _height = Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(_base / 2, 2));
        }

        public double GetPerimeter()
        {
            return _leftSide + _rightSide + _base;
        }

        public double GetArea()
        {
            return _base * _height;
        }
    }
}