using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class DataParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataParserConstructorPassNullShouldThrowExcptn()
        {
            //arrange
            //act
            new DataParser(null);
            //assert
        }
        [TestMethod]
        public void DataParserParseArgsInNullShouldReturnNull()
        {
            //arrange
            var dataParser = new DataParser(new DataProvider("StudentsInfo.dat"));

            //act
            var retVal = dataParser.ParseArgs(null);
            //assert
            Assert.IsNull(retVal);
        }
        [TestMethod]
        public void DataParserParseArgsInWrongArgsShouldReturnNull()
        {
            //arrange
            var dataParser = new DataParser(new DataProvider("StudentsInfo.dat"));
            //act
            var retVal = dataParser.ParseArgs("gh:tyuo");
            //assert
            Assert.IsNull(retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DataParserParseArgsInWrongFormatgArgsShouldThrowArgExcptn()
        {
            //arrange
            var dataParser = new DataParser(new DataProvider("StudentsInfo.dat"));
            //act
            var retVal = dataParser.ParseArgs("gh:t:yuo");
            //assert
            Assert.IsNull(retVal);
        }

    }
}
