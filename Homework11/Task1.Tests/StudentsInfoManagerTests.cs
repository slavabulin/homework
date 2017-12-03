using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task11;
using System.Collections.Generic;

namespace Task1.Tests
{
    [TestClass]
    public class StudentsInfoManagerTests
    {
        [TestMethod]
        public void StudentsInfoManagerGetStudentsInfoShouldPass()
        {
            //arrange
            List<StudentsInfo> retVal, expectedVal = new List<StudentsInfo>();
            DateTime createTime;
            DateTime.TryParse("20:33:24.7180514", out createTime);
            expectedVal.Add(new StudentsInfo() { Name = "ted", Tests = new List<Test>() { new Test() { TestName = "math", TestDate = createTime, Assessment = 'F' } } });
            expectedVal.Add(new StudentsInfo() { Name = "john", Tests = new List<Test>() { new Test() { TestName = "english", TestDate = createTime, Assessment = 'A' } } });
            //act
            retVal = StudentsInfoManager.GetStudentInfo("a:F tn:english");
            //assert
            CheckEqualityStudentsInfo(expectedVal, retVal);
        }
        [TestMethod]
        public void StudentsInfoManagerGetStudentsInfoInWrongArgsOutNull()
        {
            //arrange
            List<StudentsInfo> retVal, expectedVal = new List<StudentsInfo>();
            DateTime createTime;
            DateTime.TryParse("20:33:24.7180514", out createTime);
            expectedVal.Add(new StudentsInfo() { Name = "ted", Tests = new List<Test>() { new Test() { TestName = "math", TestDate = createTime, Assessment = 'F' } } });
            expectedVal.Add(new StudentsInfo() { Name = "john", Tests = new List<Test>() { new Test() { TestName = "english", TestDate = createTime, Assessment = 'A' } } });
            //act
            retVal = StudentsInfoManager.GetStudentInfo("xa:F tbn:english");
            //assert
            Assert.IsNull(retVal);
        }
        void CheckEqualityStudentsInfo(List<StudentsInfo> expectedVal, List<StudentsInfo> retVal)
        {
            IEnumerator<StudentsInfo> enumRetVal = retVal.GetEnumerator();
            IEnumerator<StudentsInfo> enumExpectedVal = expectedVal.GetEnumerator();

            while (enumRetVal.MoveNext())
            {
                enumExpectedVal.MoveNext();
                Assert.AreEqual(enumExpectedVal.Current.Name, enumRetVal.Current.Name);
                IEnumerator<Test> enumRetTests = enumRetVal.Current.Tests.GetEnumerator();
                IEnumerator<Test> enumExpTests = enumExpectedVal.Current.Tests.GetEnumerator();
                while(enumRetTests.MoveNext())
                {
                    enumExpTests.MoveNext();
                    Assert.AreEqual(enumExpTests.Current.Assessment, enumRetTests.Current.Assessment);
                    Assert.AreEqual(enumExpTests.Current.TestName, enumRetTests.Current.TestName);
                    Assert.AreEqual(enumExpTests.Current.TestDate, enumRetTests.Current.TestDate);
                }
            }
        }
        [TestMethod]
        public void StudentsInfoManagerGetStudentsInfoInNullOutNull()
        {
            //arrange
            List<StudentsInfo> retVal;
            //act
            retVal = StudentsInfoManager.GetStudentInfo(null);
            //assert
            Assert.IsNull(retVal);
        }
    }
}
