using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3.Tests
{
    [TestClass]
    public class SumCheckerTests
    {
        SumChecker sch;
        public SumCheckerTests()
        {
            sch = new SumChecker();
        }
        [TestMethod]
        public void CheckArrayIndexExistShouldReturnIndex()
        {
            //arrange
            int[] inputArray = new int[] { 1, 2, 1 };
            int expectedVal = 1;
            int retVal;
            //act
            retVal = sch.Check(inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CheckArrayIndexDoesntExistShouldReturnMinusOne()
        {
            //arrange
            int[] inputArray = new int[] {11, 0, 123458, -1};
            int expectedVal = -1;
            int retVal;
            //act
            retVal = sch.Check(inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}