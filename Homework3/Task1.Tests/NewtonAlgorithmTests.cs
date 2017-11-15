using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class NewtonAlgorithmTests
    {
        NewtonAlgorithm na;
        public NewtonAlgorithmTests()
        {
            na = new NewtonAlgorithm(0);
        }
        [TestMethod]
        public void CalculateRootZeroAccuracyDegree3Number27ShouldReturn3()
        {
            //arrange
            uint degree = 3;
            int number = 27;
            double retVal;
            //act
            retVal = na.CalculateRoot(number, degree);
            //assert
            Assert.AreEqual(3, retVal);
        }
        [TestMethod]
        public void CalculateRootNumber0Degree3ShouldReturn0()
        {
            //arrange
            uint degree = 3;
            int number = 0;
            double retVal;
            //act
            retVal = na.CalculateRoot(number, degree);
            //assert
            Assert.AreEqual(0, retVal);
        }
        [TestMethod]
        public void CalculateRootNumber0Degree0ShouldReturn0()
        {
            //arrange
            uint degree = 0;
            int number = 0;
            double retVal;
            //act
            retVal = na.CalculateRoot(number, degree);
            //assert
            Assert.AreEqual(1, retVal);
        }
        //[TestMethod]
        public void CalculateRootDegree0Number10ShouldReturn1()
        {
            //arrange
            na = new NewtonAlgorithm(0.000001);
            uint degree = 0;
            int number = 10;
            double retVal;
            //act
            retVal = na.CalculateRoot(number, degree);
            //assert
            Assert.AreEqual(1, retVal);
        }
    }
}
