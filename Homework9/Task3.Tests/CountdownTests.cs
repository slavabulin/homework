using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3.Tests
{
    [TestClass]
    public class CountdownTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountdownInpuZeroShouldThrowArgExcptn()
        {
            //arrange
            //act
            var countdown = new Countdown(0);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CountdownInputMinus3ShouldThrowArgExcptn()
        {
            //arrange
            //act
            var countdown = new Countdown(-3);
            //assert
        }
        [TestMethod]
        public void CountdownInput300ShouldPass()
        {
            //arrange
            //act
            var countdown = new Countdown(300);
            //assert
        }
    }
}
