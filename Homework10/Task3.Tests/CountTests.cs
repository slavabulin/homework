using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;
using System.Collections.Generic;

using System.Linq;


namespace Task3.Tests
{
    [TestClass]
    public class CountTests
    {
        Fibonacci fb;
        public CountTests()
        {
            fb = new Fibonacci();
        }
        [TestMethod]
        public void CountIn6Out8()
        {
            //arrange
            List<int> retVal, expectedVal = new List<int>() { 1, 1, 2, 3, 5, 8 };
            //act
            retVal = fb.Count(6).ToList();
            //assert
            CollectionAssert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CountIn0Out0()
        {
            //arrange
            int retVal, expectedVal = 0;
            //act
            retVal = fb.Count(0).ToList().Last();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CountInMinus4OutMinus3()
        {
            //arrange
            List<int> retVal, expectedVal = new List<int>() { 1, -1, 2, -3 };
            //act
            retVal = fb.Count(-4).ToList();
            //assert
            CollectionAssert.AreEqual(expectedVal, retVal);
        }
    }
}
