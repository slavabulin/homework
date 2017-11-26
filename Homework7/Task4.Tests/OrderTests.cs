using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Task4;
using System.Collections.Generic;

namespace Task4.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void UniqueInOrderInArr1223ShouldReturnArr123()
        {
            //arrange
            Order<int> order = new Order<int>();
            int[] inArr = new int[] { 1, 2, 2, 3, 2 };
            var expArr = new List<int>() { 1, 2, 3, 2 };
            //act
            var retVal =
                order.UniqueInOrder(inArr);
            //assert
            CollectionAssert.AreEqual(expArr, retVal);
        }
        [TestMethod]
        public void UniqueInOrderInStrAAAABBBCCDAABBBShouldReturnABCDAB()
        {
            //arrange
            Order<char> order = new Order<char>();
            string inArr = "AAAABBBCCDAABBB";
            List<char> expArr = new List<char>() { 'A', 'B', 'C', 'D', 'A', 'B' };
            //act
            var retVal =
                order.UniqueInOrder(inArr);
            //assert
            CollectionAssert.AreEqual(expArr, retVal);
        }
        [TestMethod]
        public void UniqueInOrderInList11222233ShouldReturnABCDAB()
        {
            //arrange
            Order<int> order = new Order<int>();
            int[] inArr = new int[] { 1, 2, 2, 3, 2 };
            List<int> expArr = new List<int>() { 1, 2, 3, 2 };
            //act
            var retVal =
                order.UniqueInOrder(inArr);
            //assert
            CollectionAssert.AreEqual(expArr, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UniqueInOrderInNullShouldThrowArgNullExcptn()
        {
            //arrange
            Order<int> order = new Order<int>();
            int[] inArr = null;
            List<int> expArr = new List<int> { 1, 2, 3 };
            //act
            order.UniqueInOrder(inArr);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UniqueInOrderInArrayZeroLenghtShouldThrowArgOutOfRngExcptn()
        {
            //arrange
            Order<int> order = new Order<int>();
            int[] inArr = new int[0];
            List<int> expArr = new List<int> { 1, 2, 3 };
            //act
            order.UniqueInOrder(inArr);
            //assert
        }
    }
}
