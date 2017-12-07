using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class DataProviderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataProviderConstructorPassNullShouldThrowExcptn()
        {
            //arrange
            //act
            new DataProvider(null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DataProviderConstructorPassWrongFilenameShouldThrowExcptn()
        {
            //arrange
            //act
            new DataProvider("lnblkhys.jghr");
            //assert
        }
    }
}
