using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3.Tests
{
    [TestClass]
    public class URLEditorTests
    {
        URLEditor urlEditor;
        public URLEditorTests()
        {
            urlEditor = new URLEditor();
        }
        [TestMethod]
        public void AddOrChangeUrlParameterInDomainPlusKeyVal1OutDomainKeyval2()
        {
            //arrange
            string inString = "www.ms.com?key1=1&key10=qwerty";
            string keyToChange = "key1=2";
            string retVal, expectedVal = "www.ms.com?key1=2&key10=qwerty";
            //act
            retVal = urlEditor.AddOrChangeUrlParameter(inString, keyToChange);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void AddOrChangeUrlParameterInDomainPlusKeyVal1CaseSensiriveOutDomainKeyval2()
        {
            //arrange
            string inString = "www.ms.com?key1=1&key10=qwerty";
            string keyToChange = "KEY1=2";
            string retVal, expectedVal = "www.ms.com?key1=1&key10=qwerty&KEY1=2";
            //act
            retVal = urlEditor.AddOrChangeUrlParameter(inString, keyToChange);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void AddOrChangeUrlParameterInDomainPlusKeyValOutDomainKeyval()
        {
            //arrange
            string inString = "www.ms.com";
            string keyToChange = "KEY1=2";
            string retVal, expectedVal = "www.ms.com?KEY1=2";
            //act
            retVal = urlEditor.AddOrChangeUrlParameter(inString, keyToChange);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void AddOrChangeUrlParameterInDomainPlusKeyVal1OutDomainKeyval1()
        {
            //arrange
            string inString = "www.ms.com?key1=1&key10=qwerty";
            string keyToChange = String.Empty;
            string retVal, expectedVal = "www.ms.com?key1=1&key10=qwerty";
            //act
            retVal = urlEditor.AddOrChangeUrlParameter(inString, keyToChange);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddOrChangeUrlParameterInUrlNullShouldThrowArgNullExcptn()
        {
            //arrange
            //act
            urlEditor.AddOrChangeUrlParameter(null, null);
            //assert
        }
    }
}
