using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    [TestClass]
    public class SorterTests
    {
        int[,] inputArray;

        [TestMethod]
        public void GetKeyOrderIncrease()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10, 11 } };
            int[] expectedKey = new int[] { 5, 11 };
            int[] retVal;

            //act
            retVal = Sorter.GetKey(inputArray, Order.increase);
            //assert
            for (int i = 0; i < expectedKey.Length; i++)
            {
                Assert.AreEqual(expectedKey[i], retVal[i]);
            }
        }
        [TestMethod]
        public void GetKeyOrderDecrease()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10, 11 } };
            int[] expectedKey = new int[] { 0, 6 };
            int[] retVal;

            //act
            retVal = Sorter.GetKey(inputArray, Order.decrease);
            //assert
            for (int i = 0; i < expectedKey.Length; i++)
            {
                Assert.AreEqual(expectedKey[i], retVal[i]);
            }

        }
        [TestMethod]
        public void GetKeyInputArrayNull()
        {
            //arrange
            int[,] inputArray = new int[,]{};
            int[] retVal;

            //act
            retVal = Sorter.GetKey(inputArray, Order.decrease);
            //assert
            Assert.IsNull(retVal);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwapRowsNullAsInputArrayShoulThrowArgNullExcptn()
        {
            //arrange
            uint firstRow = 0;
            uint secondRow = 15;
            //act
            Sorter.SwapRows(ref inputArray, firstRow, secondRow);
            //assert
        }
        [TestMethod]
        public void SwapRowsRowsNumbersAreSameShoulReturnInitialInput()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            int[,] expectedArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            uint firstRow = 0;
            uint secondRow = 0;
            //act
            Sorter.SwapRows(ref inputArray, firstRow, secondRow);
            //assert
            for (int i = 0; i < expectedArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < expectedArray.GetUpperBound(1); j++)
                {
                    Assert.AreEqual(expectedArray[i, j], inputArray[i, j]);
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SwapRowsRowsNumbersAreOutOfRangeShouldThrowOOR()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };            
            uint firstRow = 0;
            uint secondRow = 1252;
            //act
            Sorter.SwapRows(ref inputArray, firstRow, secondRow);
            //assert
        }
        [TestMethod]
        public void SortRowsByKeyShouldStaySame()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            int[,] expectedArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            int[] key = new int[] { 0, 3 };
            //act
            Sorter.SortRowsByKey(ref inputArray, key, Order.increase);
            //assert
            for (int i = 0; i < expectedArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < expectedArray.GetUpperBound(1); j++)
                {
                    Assert.AreEqual(expectedArray[i, j], inputArray[i, j]);
                }
            }
        }
        [TestMethod]
        public void SortRowsByKeyShouldSwapRows0and1()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            int[,] expectedArray = new int[,] { { 3, 4, 5, 6 }, { 0, 1, 2, 3 } };
            int[] key = new int[] { 3, 0 };
            //act
            Sorter.SortRowsByKey(ref inputArray, key, Order.increase);
            //assert
            for (int i = 0; i < expectedArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < expectedArray.GetUpperBound(1); j++)
                {
                    Assert.AreEqual(expectedArray[i, j], inputArray[i, j]);
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortRowsByKeyInputNullShouldThrowArgNullExcptn()
        {
            //arrange
            int[,] inputArray = null;
            int[] key = new int[] { 0, 3 };
            //act
            Sorter.SortRowsByKey(ref inputArray, key, Order.increase);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortRowsByKeyInputKeyNullShouldThrowArgNullExcptn()
        {
            //arrange
            int[,] inputArray = new int[,] { { 0, 1, 2, 3 }, { 3, 4, 5, 6 } };
            int[] key = null;// new int[] { 0, 3 };
            //act
            Sorter.SortRowsByKey(ref inputArray, key, Order.increase);
            //assert
        }
    }
}
