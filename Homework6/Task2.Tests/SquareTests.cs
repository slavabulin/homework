using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SquareInputZeroShouldThrowArgOutOfRange()
        {
            Square sq = new Square(0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SquareInputMinus5ShouldThrowArgOutOfRange()
        {
            Square sq = new Square(-5);
        }
        [TestMethod]
        public void SquareCalcSquareInput5ShouldReturn25()
        {
            //arrange
            Square sq = new Square(5);
            double retVal;
            double expectedVal = 25;
            //act
            retVal = sq.calculateSquare();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void SquareCalcPerimeterInput5ShouldReturn20()
        {
            //arrange
            Square sq = new Square(5);
            double retVal;
            double expectedVal = 20;
            //act
            retVal = sq.calculatePerimeter();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }

    }
}
