using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task8.Tests
{
    [TestClass]
    public class ReversePolishNotationTests
    {
        [TestMethod]
        public void CalculateIn723MulMiOut1()
        {
            int retVal, expectedVal = 7;
            var rpn = new ReversePolishNotation();
            retVal = rpn.Calculte("7 2 3 * - 3 2 * +");
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateIn723MulShouldThrowArgmentExcptn()
        {
            int retVal, expectedVal = 7;
            var rpn = new ReversePolishNotation();
            retVal = rpn.Calculte("7 2 3 * - 3 2 *");
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateIn723MulMin32MulMinPlusShouldThrowArgmentExcptn()
        {
            int retVal, expectedVal = 7;
            var rpn = new ReversePolishNotation();
            retVal = rpn.Calculte("7 2 3 * - 3 2 * - +");
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateInNullShouldThrowArgmentExcptn()
        {
            var rpn = new ReversePolishNotation();
            rpn.Calculte(null);
        }
    }
}
