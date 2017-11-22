using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;

namespace Task6.Tests
{
    [TestClass]
    public class SumTests
    {
        BigNumberOperator bno;
        public SumTests()
        {
            bno = new BigNumberOperator();
        }
        [TestMethod]
        public void SumInput27_5ShouldReturn32()
        {
            //arrange
            string in1 = "27";
            string in2 = "5";
            string retVal;
            string expectedVal = "32";
            //act
            retVal = bno.Sum(in1, in2);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void SumInput5_27ShouldReturn32()
        {
            //arrange
            string in1 = "5";
            string in2 = "27";
            string retVal;
            string expectedVal = "32";
            //act
            retVal = bno.Sum(in1, in2);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void SumInput27_27ShouldReturn54()
        {
            //arrange
            string in1 = "27000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string in2 = "27";
            string retVal;
            string expectedVal = "27000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000027";
            //act
            retVal = bno.Sum(in1, in2);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void SumInput55_66ShouldReturn121()
        {
            //arrange
            string in1 = "55";
            string in2 = "66";
            string retVal;
            string expectedVal = "121";
            //act
            retVal = bno.Sum(in1, in2);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SumInputNullShouldThrowArgNullExcptn()
        {
            //arrange
            string in1 = null;
            string in2 = "66";
            //act
            bno.Sum(in1, in2);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SumInputLettersShouldThrowFormatExcptn()
        {
            //arrange
            string in1 = "6lalala01";
            string in2 = "66";
            //act
            bno.Sum(in1, in2);
            //assert
        }
    }
}
