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
        [TestMethod]
        public void ValidateShouldPass()
        {
            //arrange
            var xmlTransformer = new XmlTransformer("test.xml");
            //act
            xmlTransformer.Validate("test.xsd");
            //assert
            Assert.IsTrue(xmlTransformer.isValid);
        }
        [TestMethod]
        public void ValidateShouldFail()
        {
            //arrange
            var xmlTransformer = new XmlTransformer("wrong.xml");
            //act
            xmlTransformer.Validate("test.xsd");
            //assert
            Assert.IsFalse(xmlTransformer.isValid);
        }
        [TestMethod]
        public void TransformShouldPass()
        {
            //arrange
            var xmlTransformer = new XmlTransformer("test.xml");
            string retVal, expectedVal = null;
            //act
            retVal = xmlTransformer.Transform("test.xsl");
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
