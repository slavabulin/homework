using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Tests
{
    [TestClass]
    public class BitInserterTests
    {
        BitInserter bi;
        public BitInserterTests()
        {
            BitInserter bi = new BitInserter();
            this.bi = bi;
        }
        [TestMethod]
        public void InsertBitsAllZeroesFromFirstIndexToLastIndexShouldReturnZero()
        {
            //arrange
            int firstIndex = 0;
            int lastIndex = 31;
            int firstNumber = -1;
            int secondNumber = 0;
            int? retVal;
            
            //act
            retVal = bi.InsertBits(firstNumber, secondNumber, firstIndex, lastIndex);

            //assert
            Assert.AreEqual(0, retVal);
        }
        [TestMethod]
        public void InsertBitsAllOnesFromFirstIndexToLastIndexShouldReturnZero()
        {
            //arrange
            int firstIndex = 0;
            int lastIndex = 31;
            int firstNumber = -1;
            int secondNumber = -1;
            int? retVal;

            //act
            retVal = bi.InsertBits(firstNumber, secondNumber, firstIndex, lastIndex);

            //assert
            Assert.AreEqual(-1, retVal);
        }
        [TestMethod]
        public void InsertBitsOnesFromZeroIndexTo15IndexShouldReturnMinus65536()
        {
            //arrange
            int firstIndex = 0;
            int lastIndex = 15;
            int firstNumber = -1;
            int secondNumber = 0;
            int? retVal;

            //act
            retVal = bi.InsertBits(firstNumber, secondNumber, firstIndex, lastIndex);

            //assert
            Assert.AreEqual(-65536, retVal);
        }
        [TestMethod]
        public void InsertBitsBothIndexesAreEqualShouldReturnNull()
        {
            //arrange
            int firstIndex = 0;
            int lastIndex = 0;
            int firstNumber = -1;
            int secondNumber = 0;
            int? retVal;

            //act
            retVal = bi.InsertBits(firstNumber, secondNumber, firstIndex, lastIndex);

            //assert
            Assert.IsNull(retVal);
        }
    }
}
