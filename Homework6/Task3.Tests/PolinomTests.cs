using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3.Tests
{
    [TestClass]
    public class polynomialTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PolynomialInputNullShouldThrowArgNullExcptn()
        {
            //arrange
            //act
            new Polynomial(null);
            //assert
        }
        [TestMethod]
        public void PolynomialAddInput0_1and1_2ShouldReturn1_3()
        {
            //arrange
            Polynomial polynomial1 = new Polynomial(0, 1);
            Polynomial polynomial2 = new Polynomial(1, 2);
            Polynomial retVal, expectedVal = new Polynomial(1, 3);

            //act
            retVal = polynomial1 + polynomial2;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void PolynomialAddInput0_1and1_2_3ShouldReturn1_3_3()
        {
            //arrange
            Polynomial polynomial1 = new Polynomial(0, 1);
            Polynomial polynomial2 = new Polynomial(1, 2, 3);
            Polynomial retVal, expectedVal = new Polynomial(1, 3, 3);

            //act
            retVal = polynomial1 + polynomial2;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void PolynomialSubInput0_1and1_2ShouldReturnMinus1_Minus1()
        {
            //arrange
            Polynomial polynomial1 = new Polynomial(0, 1);
            Polynomial polynomial2 = new Polynomial(1, 2);
            Polynomial retVal, expectedVal = new Polynomial(-1, -1);

            //act
            retVal = polynomial1 - polynomial2;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void PolynomialSubInput0_1and1_2_3ShouldReturnMinus1_Minus1_Minus3()
        {
            //arrange
            Polynomial polynomial1 = new Polynomial(0, 1);
            Polynomial polynomial2 = new Polynomial(1, 2, 3);
            Polynomial retVal, expectedVal = new Polynomial(-1, -1, -3);

            //act
            retVal = polynomial1 - polynomial2;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
