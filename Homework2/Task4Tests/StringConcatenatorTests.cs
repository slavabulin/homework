using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Task4Tests
{
    [TestClass]
    public class StringConcatenatorTests
    {
        StringConcatenator sc;
        public StringConcatenatorTests()
        {
            sc = new StringConcatenator();
        }
        [TestMethod]
        public void ConcatenateNoDuplicatesShouldReturnUnitedString()
        {
            //arrange
            string str1 = "123";
            string str2 = "456";
            string rezStr;
            //act
            rezStr = sc.Concatenate(str1, str2);
            //assert
            Assert.AreEqual("123456", rezStr);
        }
        [TestMethod]
        public void ConcatenateAllDuplicatesShouldReturnOneLetter()
        {
            //arrange
            string str1 = "aaaaaaa";
            string str2 = "aaa";
            string rezStr;
            //act
            rezStr = sc.Concatenate(str1, str2);
            //assert
            Assert.AreEqual("a", rezStr);
        }
        [TestMethod]
        public void ConcatenateEmptyStringsShouldNull()
        {
            //arrange
            string str1 = String.Empty;
            string str2 = String.Empty;
            string rezStr;
            //act
            rezStr = sc.Concatenate(str1, str2);
            //assert
            Assert.AreEqual("", rezStr);
        }
    }
}
