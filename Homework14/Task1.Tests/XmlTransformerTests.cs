using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;

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
            var xmlTransformer = new XmlTransformer("testFail.xml");
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
            string retVal;
            //act
            retVal = xmlTransformer.Transform("test.xsl");
            //assert
            Assert.IsTrue(XNode.DeepEquals(XDocument.Parse(retVal),
                XDocument.Load("expected.xml")
                ));

        }
        [TestMethod]
        public void TransformShouldFail()
        {
            //arrange
            var xmlTransformer = new XmlTransformer("test.xml");
            string retVal;
            //act
            retVal = xmlTransformer.Transform("testFail.xsl");
            //assert
            Assert.IsFalse(XNode.DeepEquals(XDocument.Parse(retVal),
                XDocument.Load("expected.xml")
                ));

        }
    }
}
