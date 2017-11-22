using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Task5.Tests
{
    [TestClass]
    public class WordOrderChangerTests
    {
        WordOrderChanger woc;
        public WordOrderChangerTests()
        {
            woc = new WordOrderChanger();
        }
        [TestMethod]
        public void ChangeInputStringShouldReturnRevers()
        {
            //arrange
            string inputData = "The greatest victory is that which requires no battle";
            string expectedVal = "battle no requires which that is victory greatest The";
            string retVal;
            //act
            retVal = woc.Change(inputData);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeInputNullShouldThrowArgExcptn()
        {
            //arrange
            string inputData = null;
            string retVal;
            //act
            retVal = woc.Change(inputData);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeInputWhiteSpaceShouldThrowArgExcptn()
        {
            //arrange
            string inputData = "   ";
            string retVal;
            //act
            retVal = woc.Change(inputData);
            //assert
        }
    }
}
