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
            //var studStrArr = new string[]{ "ted,math,20:33:24.7180514,A", "john,english,20:33:24.7180514,F", "mary,math,20:43:24,B" };
            IDataProvider fm = new FileManager();
            //fm.WriteTotalInfo(studStrArr);
            var list = fm.ReadTotalInfo();
            var sim = new StudentsInfoManager();
            var result = sim.GetStudentInfo("a:F tn:math");
        }
    }
    
    public class StudentsInfoManager
    {
        public List<StudentsInfo> GetStudentInfo(string args)
        {
            args = args.Trim();
            while(args.Last()=='\n')
            {
                args = args.Remove(args.Length - 1);
            }
            if (args == null) return null;

            var argPairsArray = args.Split();
            var filters = new StudentsInfo();
            foreach(string argPair in argPairsArray)
            {
                if (String.IsNullOrWhiteSpace(argPair)) continue;
                var filterKeyValueArr = argPair.Split(':');
                if (filterKeyValueArr.Length != 2) throw new ArgumentException("inconsistent args", nameof(args));
                switch(filterKeyValueArr[0])
                {
                    case "n":
                        filters.StudentName = filterKeyValueArr[1];
                        break;
                    case "a":
                        filters.Mark = filterKeyValueArr[1][0];
                        break;
                    case "td":
                        DateTime tmpDateVar;
                        if (DateTime.TryParse(filterKeyValueArr[1], out tmpDateVar))
                            filters.TestDate = tmpDateVar;
                        break;
                    case "tn":
                        filters.LessonName = filterKeyValueArr[1];
                        break;
                }
            }

            IDataProvider fm = new FileManager();
            var studInfoStrArr = fm.ReadTotalInfo();

            var s = studInfoStrArr.Where(x =>
            (x.StudentName == filters.StudentName
            || x.Mark == filters.Mark
            || x.TestDate.Equals(filters.TestDate)
            || x.LessonName == filters.LessonName
            ));

            return s.ToList();
        }
    }
    public class StudentsInfo
    {
        public string StudentName { get; set; }
        public string LessonName { get; set; }
        public DateTime TestDate { get; set; }
        public char Mark { get; set; }
    }

    public class FileManager : IDataProvider
    {
        public string filePath = "StudentsInfo.dat";
        public List<StudentsInfo> ReadTotalInfo()
        {
            string[] strArr = null;
            var studInfoList = new List<StudentsInfo>();
            using (var sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                var tmpStr = sr.ReadToEnd();
                while(tmpStr.Last<char>() == '\n')
                {
                    tmpStr = tmpStr.Remove(tmpStr.Length - 1);
                }                    
                strArr = tmpStr.Split('\n');
                foreach(string strInfo in strArr)
                {
                    var infoArr = strInfo.Split(',');
                    var studInfo = new StudentsInfo();
                    studInfo.StudentName = infoArr[0];
                    studInfo.LessonName = infoArr[1];
                    DateTime date;
                    DateTime.TryParse(infoArr[2], out date);
                    studInfo.TestDate = date;
                    studInfo.Mark = infoArr[3].ToUpper().TrimStart()[0];
                    studInfoList.Add(studInfo);
                }
            }            
            return studInfoList;
        }
        public bool WriteTotalInfo(string[] studInfoArr)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var sb = new StringBuilder();
                foreach (string studInfo in studInfoArr)
                {
                    sb.Append(studInfo);
                    sb.Append('\n');
                }
                sb.Remove(sb.Length - 1, 1);
                sw.Write(sb);
            }
            return true;
        }
    }
}
