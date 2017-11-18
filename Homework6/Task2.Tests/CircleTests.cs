using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CircleInput0ShouldThrowArgOutOfRange()
        {
            //arrange
            double radius = 0;
            //act
            new Circle(radius);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CircleInputMinus5ShouldThrowArgOutOfRange()
        {
            //arrange
            double radius = -5;
            //act
            new Circle(radius);
            //assert
        }
        [TestMethod]
        public void CircleCalcSquareInput5ShouldReturn78()
        {
            //arrange
            double radius = 5;
            double expectedVal = 78.539816339744831;
            double square;
            Circle circle;
            //act
            circle = new Circle(radius);
            square = circle.calculateSquare();
            //assert
            Assert.AreEqual(expectedVal, square);
        }
        [TestMethod]
        public void CircleCalcPerimeterInput5ShouldReturn31()
        {
            //arrange
            double radius = 5;
            double expectedVal = 31.415926535897931;
            double perimeter;
            Circle circle;
            //act
            circle = new Circle(radius);
            perimeter = circle.calculatePerimeter();
            //assert
            Assert.AreEqual(expectedVal, perimeter);
        }
    }
}
