using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace NUnitTestRunner.Tests
{
    [TestFixture]
    public class TestRunnerData
    {
        [TestCase(1,1,2)]
        public void TestMethod1(int arg1, int arg2, int expVal)
        {
            int retVal = arg1 + arg2;
            Assert.AreEqual(retVal, expVal);
        }

        [TestCaseSource(nameof(SourceData))]
        public void TestMethod2(int arg1, int arg2, int expVal)
        {
            int retVal = arg1 + arg2;
            Assert.AreEqual(retVal, expVal);
        }

        private static object[] SourceData = new[] {
        new double[]{ 1,1,2 },
        new double[]{ 2,2,40}};
    }
}
