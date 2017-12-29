using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework21;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Homework21.Tests
{
    [TestClass]
    public class DbManagerTests
    {
        DBManager _dbManager;
        SqlConnection _connection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sla\repo\Homework21\Homework21\Data\StudentCheckerDb.mdf;Integrated Security=True";

        public DbManagerTests()
        {
            _connection = new SqlConnection(connectionString);
        }
        [TestInitialize]
        public void Init()
        {
            Cleanup();
            _dbManager = new DBManager(connectionString);
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
            string[] args = new[] { "-lecture", "31.12.2222", "math" };

            string queryString1 = "select * from Lecture";
            DateTime date = FormatTime(args[1]);
            string queryToRemove = $"delete from Lecture where Date = '{date:yyyyMMdd}' and Topic = '{args[2]}'";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            var lectureTopicDate = new List<Tuple<string,string>>();

            //Act
            _dbManager.AddLecture(args);

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
            try
            {
                command1 = new SqlCommand(queryToRemove, _connection);
                command1.ExecuteNonQuery();
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
            string[] args = new []{"-student","Ivan" };
            string queryString1 = "select * from Students";
            string queryToRemove = $"delete from Students where Name = '{args[1]}'";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            var studNames = new List<string>();
            
            //Act
            _dbManager.AddStudent(args);

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
            try
            {
                command1 = new SqlCommand(queryToRemove, _connection);
                command1.ExecuteNonQuery();
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
            string[] args = new[] { "-attend", "Ivan",  "18.12.2017", "5"};

            string queryString1 = "select LectureDate, StudentName, Mark from Attendance";
            DateTime date = FormatTime(args[2]);
            string queryToRemove = $"delete from Attendance where StudentName = '{args[1]}'" +
                $"and LectureDate = '{date.ToString("yyyy.MM.dd")}' and Mark = '{args[3]}'";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            var attendStudDateMark = new List<Tuple<string, string, string>>();
            _dbManager.AddStudent(new[] { "-student", $"{args[1]}" });
            _dbManager.AddLecture(new[] { "-lecture", $"{args[2]}", "math" });

            //Act
            _dbManager.AddAttend(args);

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
                command1 = new SqlCommand(queryToRemove, _connection);
                command1.ExecuteNonQuery();
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

            //Act
            _dbManager.InitDB();
            //Assert
            try
            {
                //SqlParameter returnParameter = command1.Parameters.Add("RetVal", SqlDbType.Int);
                //returnParameter.Direction = ParameterDirection.ReturnValue;
                SqlDataReader reader = command1.ExecuteReader();
                while(reader.Read())
                {
                    retVal = (int)reader[0];
                }
                //retVal = (int)returnParameter.Value;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Assert.AreEqual(42, retVal);
        }
        void AddData(string queryString)
        {
            SqlCommand command1 = new SqlCommand(queryString, _connection);

            try
            {
                _connection.Open();
                command1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
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
