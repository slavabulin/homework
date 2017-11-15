using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;
using System.Collections.Generic;

namespace Task5Tests
{
    [TestClass]
    public class FilterLuckyTests
    {
        FilterLucky fl; 
        public FilterLuckyTests()
        {
            fl = new FilterLucky();
        }
        [TestMethod]
        public void FilterNo7ShouldReturnNull()
        {
            //arrange
            List<int> inputData = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };
            List<int> retVal;
            //act
            retVal = fl.Filter(inputData);
            //assert
            Assert.IsNull(retVal);
        }
        [TestMethod]
        public void FilterAllElementsAre7ShouldReturnInputArray()
        {
            //arrange
            List<int> inputData = new List<int> { 7, 77, 73, 74, 75, 76, 78, 79 };
            List<int> retVal;
            //act
            retVal = fl.Filter(inputData);
            //assert
            for (int i = 0; i < inputData.Count; i++)
            {
                Assert.AreEqual(inputData[i], retVal[i]);
            }
        }
        [TestMethod]
        public void FilterNoElementsShouldReturnListNoElem()
        {
            //arrange
            List<int> inputData = new List<int>();
            List<int> retVal;
            //act
            retVal = fl.Filter(inputData);
            //assert
            for (int i = 0; i < inputData.Count; i++)
            {
                Assert.AreEqual(inputData[i], retVal[i]);
            }
        }
    }
}
