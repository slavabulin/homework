using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Task4.Tests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        public void CustomQueueEnqueueIn0Out0()
        {
            //arrange
            var cq = new CustomQueue<int>();
            int a = 0;
            int expectedVal = 0, retVal;
            //act
            cq.Enqueue(a);
            retVal = cq[0];
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomQueueDequeueIn1Out1()
        {
            //arrange
            var cq = new CustomQueue<int>();
            int a = 1;
            int expectedVal = 1, retVal;
            //act
            cq.Enqueue(a);
            retVal = cq.Dequeue();
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomQueuePeekIn1Out1()
        {
            //arrange
            var cq = new CustomQueue<int>();
            int a = 10;
            int expectedVal = 1, retVal;
            //act
            cq.Enqueue(a);
            cq.Peek();
            retVal = cq.Length;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomQueueLengthIn1Out1()
        {
            //arrange
            var cq = new CustomQueue<int>();
            int a = 10;
            int expectedVal = 1, retVal;
            //act
            cq.Enqueue(a);
            retVal = cq.Length;
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
