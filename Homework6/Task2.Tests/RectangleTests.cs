using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RectangleInputZeroShouldThrowArgOutOfRange()
        {
            Rectangle sq = new Rectangle(0, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RectangleInputMinus5ShouldThrowArgOutOfRange()
        {
            Rectangle sq = new Rectangle(-5, 2);
        }
        [TestMethod]
        public void RectangleCalcSquareInput5ShouldReturn25()
        {
            //arrange
            Rectangle sq = new Rectangle(5, 10);
            double retVal;
            double expectedVal = 50;
            //act
            retVal = sq.calculateSquare();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void RectangleCalcPerimeterInput5ShouldReturn20()
        {
            //arrange
            Rectangle sq = new Rectangle(5, 12);
            double retVal;
            double expectedVal = 34;
            //act
            retVal = sq.calculatePerimeter();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
