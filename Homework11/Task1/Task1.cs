﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1
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
    ///             tb - get test info with time before inserted
    ///             ta - get test info with time after inserted
    ///             a - get by assessment (Capital letters from A to F) - a:A
    ///             
    ///             example - { n:ted a:A }
    /// </summary>
    class Task1
    {
        static void Main(string[] args)
        {
            var dataParser = new DataParser(new DataProvider("StudentsInfo.dat"));
            var filters = dataParser.ParseArgs("tn:math tb:03.12.2017");
            var filter = new Filter();
            var data  = dataParser.ParseData();
            var filteredList = filter.FilterData(data, filters);            
        }
    }
    public class StudentsInfo
    {
        public string StudentName { get; set; }
        public string LessonName { get; set; }
        public DateTime? TestDate { get; set; }
        public char Mark { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as StudentsInfo;

            if (item == null)
            {
                return false;
            }

            if (this.LessonName == item.LessonName
                && this.Mark == item.Mark
                && this.StudentName == item.StudentName
                && this.TestDate == item.TestDate)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = LessonName.GetHashCode()
                    + Mark.GetHashCode()
                    + StudentName.GetHashCode()
                    + TestDate.GetHashCode();
            }
            return hash;
        }
    }
    public class FilterInfo
    {
        public string StudentName { get; set; }
        public string LessonName { get; set; }
        public DateTime? TestDate { get; set; }
        public char Mark { get; set; }
        public DateTime? TimeBefore { get; set; }
        public DateTime? TimeAfter { get; set; }
    }

    public class DataProvider : IDataProvider
    {
        string _filePath;
        public DataProvider(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath), "argument should not be null");
            if (File.Exists(filePath))
            {
                _filePath = filePath;
            }
            else
                throw new ArgumentException("file is unavailable", nameof(filePath));
            
        }
        public string[] ReadData()
        {
            string[] strArr = null;
            using (var sr = new StreamReader(_filePath, Encoding.Default))
            {
                var tmpStr = sr.ReadToEnd();
                tmpStr = tmpStr.Trim();
                strArr = tmpStr.Split('\n');
            }
            return strArr;
        }
        public bool WriteData(string[] data)
        {
            using (var sw = new StreamWriter(_filePath))
            {
                var sb = new StringBuilder();
                foreach (string studInfo in data)
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
    public class DataParser
    {
        IDataProvider _dataProvider;
        public DataParser(IDataProvider dataProvider)
        {
            if (dataProvider == null) throw new ArgumentNullException(nameof(dataProvider), "params should not be null");
            _dataProvider = dataProvider;
        }
        public List<StudentsInfo> ParseData()
        {
            string[] strArr = _dataProvider.ReadData();
            var studInfoList = new List<StudentsInfo>();
            foreach (string strInfo in strArr)
            {
                var infoArr = strInfo.Split(',');
                var studInfo = new StudentsInfo();
                studInfo.StudentName = infoArr[0];
                studInfo.LessonName = infoArr[1];
                DateTime date;
                DateTime.TryParse(infoArr[2], out date);
                studInfo.TestDate = date.ToUniversalTime();
                studInfo.Mark = infoArr[3].ToUpper().TrimStart()[0];
                studInfoList.Add(studInfo);
            }
            return studInfoList;
        }
        public FilterInfo ParseArgs(string args)
        {
            if (args == null) return null;
            args = args.Trim();

            var argPairsArray = args.Split();
            var filters = new FilterInfo();
            foreach (string argPair in argPairsArray)
            {
                if (String.IsNullOrWhiteSpace(argPair)) continue;
                var filterKeyValueArr = argPair.Split(':');
                if (filterKeyValueArr.Length != 2)
                    throw new ArgumentException("wrong args stucture", nameof(args));
                switch (filterKeyValueArr[0])
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
                    case "tb":
                        DateTime tmpDateVar2;
                        if (DateTime.TryParse(filterKeyValueArr[1], out tmpDateVar2))
                            filters.TimeBefore = tmpDateVar2;
                        break;
                    case "ta":
                        DateTime tmpDateVar3;
                        if (DateTime.TryParse(filterKeyValueArr[1], out tmpDateVar3))
                            filters.TimeBefore = tmpDateVar3;
                        break;
                    default:
                        return null;
                }
            }
            return filters;
        }
    }
    public class Filter
    {
        public List<StudentsInfo> FilterData(List<StudentsInfo> data, FilterInfo filters)
        {
            if (data == null) throw new ArgumentNullException(nameof(data), "argument should not be null");
            if (filters == null) throw new ArgumentNullException(nameof(filters), "argument should not be null");

            var s = data as IEnumerable<StudentsInfo>;

            if (filters.LessonName != null)
            {
                s = s.Where(x => x.LessonName == filters.LessonName);
            }
            if(filters.Mark!=default(char))
            {
                s=s.Where(x => x.Mark == filters.Mark);
            }
            if(filters.StudentName!= null)
            {
                s = s.Where(x => (x.StudentName == filters.StudentName));
            }
            if(filters.TestDate!=null)
            {
                s = s.Where(x => x.TestDate.Equals(filters.TestDate));
            }
            if(filters.TimeAfter!=null)
            {
                s = s.Where(x => x.TestDate >= filters.TimeAfter);
            }
            if(filters.TimeBefore!=null)
            {
                s = s.Where(x => x.TestDate <= filters.TimeBefore);
            }
            return s.ToList();
        }
    }
}
