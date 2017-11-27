using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void SearchInInt1_3_5_7_and_5Out2()
        {
            //arrange
            var bs = new BinarySearch<int>();
            int[] intArr = new int[] { 1, 3, 5, 7, 9 };
            int? retVal, expectedVal = 2;

            //act
            retVal = bs.Search(intArr, 5);
            //assert
            Assert.AreEqual<int?>(expectedVal, retVal);
        }
        [TestMethod]
        public void SearchInDouble1_3_5_7_and_5Out2()
        {
            //arrange
            var bs = new BinarySearch<double>();
            double[] intArr = new double[] { 1, 3, 5, 7, 9 };
            double? retVal, expectedVal = 2;

            //act
            retVal = bs.Search(intArr, 5);
            //assert
            Assert.AreEqual<double?>(expectedVal, retVal);
        }
        [TestMethod]
        public void SearchInString1_3_5_7_and_5Out2()
        {
            //arrange
            var bs = new BinarySearch<string>();
            string[] intArr = new string[] { "1", "3", "5", "7", "9" };
            int? retVal;
            int? expectedVal = 2;
            //act
            retVal = bs.Search(intArr, "5");
            //assert
            Assert.AreEqual<int?>(expectedVal, retVal);
        }
        [TestMethod]
        public void SearchInNullOutNull()
        {
            //arrange
            var bs = new BinarySearch<string>();
            int? retVal;
            int? expectedVal = null;
            //act
            retVal = bs.Search(null, "5");
            //assert
            Assert.AreEqual<int?>(expectedVal, retVal);
        }
        [TestMethod]
        public void SearchInInt1_3_6_9_and_100OutNull()
        {
            //arrange
            var bs = new BinarySearch<int>();
            int[] intArr = new int[] { 1, 3, 6, 9 };
            int? retVal;
            int? expectedVal = null;
            //act
            retVal = bs.Search(null, 100);
            //assert
            Assert.AreEqual<int?>(expectedVal, retVal);
        }
    }
}