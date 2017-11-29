using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task4.Tests
{
    [TestClass]
    public class CustomQueueEnumeratorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomQueueEnumeratorConstructorInNullShouldThrowExcptn()
        {
            //arrange
            CustomQueueEnumerator<int> cqEnum = new CustomQueueEnumerator<int>(null);
            //act
            //assert
        }
    }
}
