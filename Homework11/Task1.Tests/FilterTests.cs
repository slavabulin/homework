using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System.Collections.Generic;

namespace Task1.Tests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterFilterDataInDataNullShouldThrowExcptn()
        {
            //arrange
            var filter = new Filter();
            //act
            filter.FilterData(null, new FilterInfo());
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterFilterDataInFiltersNullShouldThrowExcptn()
        {
            //arrange
            var filter = new Filter();
            //act
            filter.FilterData(new List<StudentsInfo>(), null);
            //assert
        }
        [TestMethod]
        public void FilterFilterDataInValidDataShouldPass()
        {
            //arrange
            var filter = new Filter();
            var filters = new FilterInfo();
            filters.Mark = 'A';
            DateTime dateTime;
            DateTime.TryParse("03.12.2017", out dateTime);
            var data = new List<StudentsInfo>() { new StudentsInfo(){StudentName = "mary", LessonName = "math",
                Mark = 'A', TestDate = dateTime}, new StudentsInfo(){StudentName = "harry", LessonName = "math",
                    Mark = 'B', TestDate = dateTime } };
            List<StudentsInfo> retVal, expectedVal = new List<StudentsInfo>(){ new StudentsInfo(){StudentName = "mary",
                LessonName = "math", Mark = 'A', TestDate = dateTime} };
            //act
            retVal = filter.FilterData(data, filters);
            //assert
            CollectionAssert.AreEqual(expectedVal, retVal);

        }
    }
}
