using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework4;

namespace Task1.Tests
{
    [TestClass]
    public class MyExtensionsTests
    {
        [TestMethod]
        public void ToIEEE754PassZeroShouldWork()
        {
            //arrange
            double inputNumber = Double.MaxValue;
            string expectedVal = "0111111111101111111111111111111111111111111111111111111111111111";
            string retVal;
            //act
            retVal = inputNumber.ToIEEE754();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void ToIEEE754PassPositiveInfinityShouldWork()
        {
            //arrange
            double inputNumber = Double.PositiveInfinity;
            string expectedVal = "0111111111110000000000000000000000000000000000000000000000000000";
            string retVal;
            //act
            retVal = inputNumber.ToIEEE754();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void ToIEEE754PassNegativeInfinityShouldWork()
        {
            //arrange
            double inputNumber = Double.NegativeInfinity;
            string expectedVal = "1111111111110000000000000000000000000000000000000000000000000000";
            string retVal;
            //act
            retVal = inputNumber.ToIEEE754();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void ToIEEE754PassNaNShouldWork()
        {
            //arrange
            double inputNumber = Double.NaN;
            string expectedVal = "1111111111111000000000000000000000000000000000000000000000000000";
            string retVal;
            //act
            retVal = inputNumber.ToIEEE754();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
