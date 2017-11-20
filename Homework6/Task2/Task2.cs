using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Develop a geometric shapes class hierarchy - Circle, Triangle, Square, Rectangle. 
    /// Classes should describe the properties of a shape and have methods for calculating
    /// the area and perimeter of the shape. (A task with an emphasis on building an inheritance
    /// hierarchy, without unduly detailed implementation).    
    /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Shape
    {
        public abstract double calculateSquare();
        public abstract double calculatePerimeter();
    }

    public class Circle:Shape
    {
        public double radius;
        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException("radius", "should be more than zero");
            this.radius = radius;
        }

        public override double calculateSquare()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        public override double calculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
    public class Rectangle:Shape
    {
        double height;
        double width;
        public Rectangle(double height, double width)
        {
            if (height <= 0)throw new ArgumentOutOfRangeException("height", "should be more than zero");
            if (width <= 0) throw new ArgumentOutOfRangeException("width", "should be more than zero");
            this.height = height;
            this.width = width;
        }

        public override double calculateSquare()
        {
            return height * width;
        }
        public override double calculatePerimeter()
        {
            return 2 * height + 2 * width;
        }
    }
    public class Square:Rectangle
    {
        public readonly double sideSize;  
        public Square(double sideSize):base(sideSize, sideSize)
        {
        }        
    }

    public class Triangle:Shape
    {
        public readonly double sideA, sideB, sideC;
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)throw new ArgumentOutOfRangeException("sideA","argument should be more than zero");
            if (sideB <= 0)throw new ArgumentOutOfRangeException("sideB","argument should be more than zero");
            if (sideC <= 0) throw new ArgumentOutOfRangeException("sideC", "argument should be more than zero");

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override double calculateSquare()
        {
            double perimeter = calculatePerimeter();
            double tmpVar = perimeter / 2 * (perimeter / 2 - sideA) * (perimeter / 2 - sideB) * (perimeter / 2 - sideC);
            double square = Math.Pow(tmpVar, 0.5);
            return square;
        }
        public override double calculatePerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
}

