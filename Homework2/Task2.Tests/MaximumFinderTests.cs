using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    [TestClass]
    public class MaximumFinderTests
    {
        MaximumFinder mf;
        public MaximumFinderTests()
        {
            mf = new MaximumFinder();
        }
        [TestMethod]
        public void FindAllZeroesShouldReturnZero()
        {
            //arrange
            int[] inputArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, };
            int retVal;
            int expected = 0;
            //act
            retVal = mf.Find(inputArray);
            //assert
            Assert.AreEqual(expected, retVal);
        }
        [TestMethod]
        public void FindAllNegativeShouldReturnMax()
        {
            //arrange
            int[] inputArray = new int[] { -10,-2,-3,-4,-5,-6, -1 };
            int retVal;
            int expected = -1;
            //act
            retVal = mf.Find(inputArray);
            //assert
            Assert.AreEqual(expected, retVal);
        }
        [TestMethod]
        public void FindMaxAndMinNumbersShouldReturnMax()
        {
            //arrange
            int[] inputArray = new int[] { Int32.MinValue, 0, Int32.MaxValue};
            int retVal;
            int expected = Int32.MaxValue;
            //act
            retVal = mf.Find(inputArray);
            //assert
            Assert.AreEqual(expected, retVal);
        }
    }
}
