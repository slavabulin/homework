using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class XmlTransformerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void XmlTransformerInNullShouldThrowExptn()
        {
            //arrange
            //act
            var xt = new XmlTransformer(null);
            //assert
        }
    }
}
