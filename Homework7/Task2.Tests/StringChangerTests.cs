using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    [TestClass]
    public class StringChangerTests
    {
        StringChanger stringChanger;
        public StringChangerTests()
        {
            stringChanger = new StringChanger();
        }

        [TestMethod]
        public void StringChangerInJUST_FOR_THE_TEST_and_FOR_THEOutJust_for_the_Test()
        {
            //arrange
            string originStr = "JUST FOR THE TEST";
            string exptnStr = "for the";
            string retVal, expectedVal = "Just for the Test";
            //act
            retVal = stringChanger.Convert(originStr, exptnStr);
            // assert
            Assert.AreEqual<string>(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringChangerInNullShoudThrowExptn()
        {
            //arrange
            //act
            stringChanger.Convert(null, null);
            // assert
        }
        [TestMethod]
        public void StringChangerInJUST_FOR_THE_TEST_OutJust_For_The_Test()
        {
            //arrange
            string originStr = "JUST FOR THE TEST";
            //string exptnStr = "for the";
            string retVal, expectedVal = "Just For The Test";
            //act
            retVal = stringChanger.Convert(originStr, null);
            // assert
            Assert.AreEqual<string>(expectedVal, retVal);
        }
        [TestMethod]
        public void StringChangerIn_just_for_the_test_OutJust_For_The_Test()
        {
            //arrange
            string originStr = "just for the test";
            //string exptnStr = "for the";
            string retVal, expectedVal = "Just For The Test";
            //act
            retVal = stringChanger.Convert(originStr, null);
            // assert
            Assert.AreEqual<string>(expectedVal, retVal);
        }
    }
}
