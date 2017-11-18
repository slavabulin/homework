using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TriangleCalculateSquareOf3_4_5ShouldReturn6()
        {
            //arrange
            Triangle triangle = new Triangle(3, 4, 5);
            double expectedVal = 6;
            //act
            double triSquare = triangle.calculateSquare();
            //assert
            Assert.AreEqual(expectedVal, triSquare);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TriangleInput0_4_5ShouldReturnThrowArgOutOfRange()
        {
            //arrange
            Triangle triangle = new Triangle(0, 4, 5);
            //act
            double triSquare = triangle.calculateSquare();
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TriangleInputMinus3_4_5ShouldThrowArgOutOfRange()
        {
            //arrange
            Triangle triangle = new Triangle(-3, 4, 5);
            //act
            double triSquare = triangle.calculateSquare();
            //assert
        }
        [TestMethod]
        public void TriangleCalculatePerimeterOf3_4_5ShouldReturn12()
        {
            //arrange
            Triangle triangle = new Triangle(3, 4, 5);
            double expectedVal = 12;
            //act
            double triSquare = triangle.calculatePerimeter();
            //assert
            Assert.AreEqual(expectedVal, triSquare);
        }
    }
}
