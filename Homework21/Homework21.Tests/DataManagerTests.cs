using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework21;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Homework21.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        DataManager _dbManager;
        SqlConnection _connection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sla\repo\Homework21\Homework21\Data\StudentCheckerDb.mdf;Integrated Security=True";

        public DataManagerTests()
        {
            _connection = new SqlConnection(connectionString);
        }
        [TestInitialize]
        public void Init()
        {
            Cleanup();
            _dbManager = new DataManager(connectionString);
            _connection.Open();
        }
        [TestCleanup]
        public void Cleanup()
        {
            if (_dbManager != null)
                _dbManager.Dispose();
            _connection.Close();
        }
        [TestMethod]
        public void AddLectureShouldPass()
        {
            //Arrange
            string dateString = "31.12.2222";
            string topicString = "math";
            var dto = new DTO()
            {
                lectureDate = DateTime.Parse(dateString),
                lectureTopic = topicString
            };
            dto.cmdType = CmdType.lecture;

            string[] args = new[] { "-lecture", dateString, topicString };
            DateTime date = FormatTime(args[1]);
            string queryString1 = "select * from Lecture";

            var lectureTopicDate = new List<Tuple<string, string>>();
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            //Act
            _dbManager.AddData(dto);

            //Assert
            try
            {
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    lectureTopicDate.Add(new Tuple<string, string>(reader[0].ToString(), reader[1].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Assert.IsTrue(lectureTopicDate.Contains(new Tuple<string, string>(date.ToString("G"), args[2])));

            string queryToRemove = $"delete from Lecture where Date = (@Date) and Topic = (@Topic)";

            try
            {
                SqlCommand command2 = new SqlCommand(queryToRemove, _connection);
                command2.Parameters.AddWithValue("@Date", FormatTime(args[1]).ToString("yyyy.MM.dd"));
                command2.Parameters.AddWithValue("@Topic", args[2]);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void AddStudentShouldPass()
        {
            //Arrange
            string name = "Ivan";
            var dto = new DTO()
            {
                cmdType = CmdType.student,
                studentName = name
            };
            string[] args = new[] { "-student", name };
            string queryString1 = "select * from Students";

            var studNames = new List<string>();
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            //Act
            _dbManager.AddData(dto);

            //Assert
            try
            {
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    studNames.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Assert.IsTrue(studNames.Contains(args[1]));

            string queryToRemove = $"delete from Students where Name = @Name";

            try
            {
                SqlCommand command2 = new SqlCommand(queryToRemove, _connection);
                command2.Parameters.AddWithValue("@Name", args[1]);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void AddAttendShouldPass()
        {
            //Arrange
            string name = "Ivan", dateString = "18.12.2017", mark = "5", topic = "math";
            var studentDto = new DTO()
            {
                cmdType = CmdType.student,
                studentName = name
            };
            var lectureDto = new DTO()
            {
                cmdType = CmdType.lecture,
                lectureDate = DateTime.Parse(dateString),
                lectureTopic = topic
            };
            var attendDto = new DTO()
            {
                cmdType = CmdType.attend,
                lectureDate = DateTime.Parse(dateString),
                studentName = name,
                mark = Int32.Parse(mark)
            };

            string[] args = new[] { "-attend", name, dateString, mark };

            string queryString1 = "select LectureDate, StudentName, Mark from Attendance";
            DateTime date = FormatTime(args[2]);

            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            var attendStudDateMark = new List<Tuple<string, string, string>>();
            _dbManager.AddData(studentDto);
            _dbManager.AddData(lectureDto);

            //Act
            _dbManager.AddData(attendDto);

            //Assert
            try
            {
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    attendStudDateMark.Add(new Tuple<string, string, string>
                        (reader[0].ToString(), reader[1].ToString(), reader[2].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Assert.IsTrue(attendStudDateMark.Contains(new Tuple<string, string, string>(date.ToString("G"), args[1], args[3])));
            try
            {
                string queryToRemove = $"delete from Attendance where StudentName = @StudentName " +
                $"and LectureDate = @LectureDate and Mark = @Mark delete from Students where Name = @StudentName";
                SqlCommand command2 = new SqlCommand(queryToRemove, _connection);
                command2.Parameters.AddWithValue("@StudentName", args[1]);
                command2.Parameters.AddWithValue("@LectureDate", date.ToString("yyyy.MM.dd"));
                command2.Parameters.AddWithValue("@Mark", args[3]);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void InitDbShouldPass()
        {
            //Arrange
            string queryString1 = $"IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL " +
                $"and OBJECT_ID('dbo.Lecture', 'U') is not null " +
                $"and OBJECT_ID('dbo.Attendance','U') is not null " +
                $"BEGIN  select 42 END" +
                $" ELSE BEGIN select 1 END ";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            int retVal = 0;

            var initDto = new DTO()
            {
                cmdType = CmdType.init
            };
            //Act
            _dbManager.AddData(initDto);
            //Assert
            try
            {
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    retVal = (int)reader[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Assert.AreEqual(42, retVal);
        }
        DateTime FormatTime(string arg)
        {
            DateTime date = default(DateTime);
            try
            {
                date = Convert.ToDateTime(arg);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Не удалось преобразовать дату - {0}", fe.Message);
                throw;
            }
            return date;
        }
    }
}
