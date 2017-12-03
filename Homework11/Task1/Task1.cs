using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task11
{
    /// <summary>
    /// Develop an console application that uses LINQ queries to retrieve and display data. Data is stored in binary file and represents information 
    /// about the results of students tests. Information about the student contains the name of the student, the name of the test, the date of the test
    /// and the assessment of the test for this student. To work with data the information is read into a binary search tree. Provide the ability to
    /// define user criteria for viewing data. Expand the ability to work with the application in such a way that users can specify the sort order and
    /// limit the number of rows retrieved.
    /// 
    /// args format: n - get by students name - n:john
    ///             tn - get by test name - td:math
    ///             td - get by test date
    ///             a - get by assessment (Capital letters from A to F) - a:A
    ///             
    ///             example - { n:ted a:A }
    /// </summary>
    class Task1
    {
        static void Main(string[] args)
        {
            var inputArgs = "n:ted";
            var StudentsList = StudentsInfoManager.GetStudentInfo(inputArgs);

            #region
            //var list = new List<StudentsInfo>();
            //DateTime createTime;
            //DateTime.TryParse("20:33:24.7180514", out createTime);
            //list.Add(new StudentsInfo() { Name = "ted", Tests = new List<Test>() { new Test() { TestName = "math", TestDate = createTime, Assessment = 'F' } } });
            //list.Add(new StudentsInfo() { Name = "john", Tests = new List<Test>() { new Test() { TestName = "english", TestDate = createTime, Assessment = 'A' } } });
            //IDataProvider fm = new FileManager();
            //fm.WriteTotalInfo(list);
            
            ////var list = fm.ReadTotalInfo();
            ////var studInfo = list.Where(student => student.Name == "ted");
            ////var studInfo = list.Where(student => student.Tests.Exists(test => test.Assessment == 'A'));

            ////Predicate<Test> predicate = CheckInput;
            ////var studInfo = list.Where(student => student.Tests.Exists(
            ////    //test =>
            ////    //test.Assessment == 'A'
            ////    CheckInput
            ////));

            ////var tmp = studInfo.ToList();
            ////Console.WriteLine(studInfo.ToList().ToString());
            #endregion
        }
    }
    
    public static class StudentsInfoManager
    {
        static Dictionary<string, string> argDictionary;
        public static List<StudentsInfo> GetStudentInfo(string args)
        {
            if (args == null) return null;
            var inArgPairArray = args.Split();
            argDictionary = new Dictionary<string, string>();
            foreach(string argPair in inArgPairArray)
            {
                var tmpArr = argPair.Split(':');
                if (tmpArr.Length != 2) throw new ArgumentException("incosistent args", nameof(args));
                argDictionary.Add(tmpArr[0], tmpArr[1]);
            }
            Predicate<StudentsInfo> predicate = CheckInput;
            IDataProvider fm = new FileManager();
            var list = fm.ReadTotalInfo();
            var studInfo = list.Where(CheckInput);
            if (studInfo.Count() > 0)
                return studInfo.ToList();
            else
                return null;
        }
        static bool CheckInput(StudentsInfo stdntInfo)
        {
            bool retVal = false;
            if(argDictionary.ContainsKey("n"))
            {
                string value;
                argDictionary.TryGetValue("n", out value);
                if (value == stdntInfo.Name) retVal = true;
            }
            if(argDictionary.ContainsKey("tn"))
            {
                string value;
                argDictionary.TryGetValue("tn", out value);
                if (stdntInfo.Tests.Any(test => test.TestName == value)) retVal = true;
            }
            if(argDictionary.ContainsKey("td"))
            {
                string value;
                argDictionary.TryGetValue("td", out value);
                DateTime dateTime;
                DateTime.TryParse(value, out dateTime);
                if (stdntInfo.Tests.Any(test => test.TestDate == dateTime)) retVal = true;
            }
            if(argDictionary.ContainsKey("a"))
            {
                string value;
                argDictionary.TryGetValue("a", out value);
                if (stdntInfo.Tests.Any(test => test.Assessment == value[0])) retVal = true;
            }
            return retVal;
        }
    }
    [Serializable]
    public class StudentsInfo
    {
        Guid _studentID;
        public StudentsInfo()
        {
            _studentID = Guid.NewGuid();
        }
        public Guid StudentID {
            get
            {
                return _studentID;
            }
        }

        public string Name { get; set; }
        public List<Test> Tests { get; set; }
    }
    [Serializable]
    public class Test
    {
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public char Assessment { get; set; }
    }
    public class FileManager : IDataProvider
    {
        public string filePath = "StudentsInfo.dat";
        public List<StudentsInfo> ReadTotalInfo()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var listStudentsInfo = (List<StudentsInfo>)formatter.Deserialize(fs);
                return listStudentsInfo;
            }
        }
        public bool WriteTotalInfo(List<StudentsInfo> listStudentsInfo)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listStudentsInfo);
            }
            return true;
        }
    }
}
