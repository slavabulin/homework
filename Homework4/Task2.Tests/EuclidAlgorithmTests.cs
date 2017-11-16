using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class EuclidAlgorithmTests
    {
        EuclidAlgorithm ea = new EuclidAlgorithm();

        [TestMethod]
        public void CalculateGCDEuclidAlgoInput1_2_3ShouldReturn1()
        {
            //arrange
            Algorithm alg = Algorithm.Euclid;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 1, 2, 3 };
            uint expectedVal = 1;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        public void CalculateGCDSteinAlgoInput1_2_3ShouldReturn1()
        {
            //arrange
            Algorithm alg = Algorithm.Stein;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 1, 2, 3 };
            uint expectedVal = 1;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        public void CalculateGCDEuclidAlgoInput0_5_10ShouldReturn5()
        {
            //arrange
            Algorithm alg = Algorithm.Euclid;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 0, 5, 10 };
            uint expectedVal = 5;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        public void CalculateGCDSteinAlgoInput0_5_10ShouldReturn5()
        {
            //arrange
            Algorithm alg = Algorithm.Stein;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 0, 5, 10 };
            uint expectedVal = 5;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateGCDEuclidAlgoNullShouldThrowArgNullExcptn()
        {
            //arrange
            Algorithm alg = Algorithm.Euclid;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = null;
            uint expectedVal = 5;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateGCDSteinAlgoNullShouldThrowArgNullExcptn()
        {
            //arrange
            Algorithm alg = Algorithm.Stein;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = null;
            uint expectedVal = 5;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        public void CalculateGCDEuclidAlgoInputZeroesShouldReturn1()
        {
            //arrange
            Algorithm alg = Algorithm.Euclid;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 0, 0, 0 };
            uint expectedVal = 0;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
        [TestMethod]
        public void CalculateGCDSteinAlgoInputZeroesShouldReturn1()
        {
            //arrange
            Algorithm alg = Algorithm.Stein;
            Tuple<uint, TimeSpan> retVal;
            uint[] inputArray = new uint[] { 0, 0, 0 };
            uint expectedVal = 0;
            //act
            retVal = ea.CalculateGCD(alg, inputArray);
            //assert
            Assert.AreEqual(expectedVal, retVal.Item1);
        }
    }
}
