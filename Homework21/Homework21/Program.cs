﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Homework21
{
    /*
     Разработать консольное приложение, позволяющее отмечать посещение студентов на паре и оценку.
Название: sc.exe
Функциональность:
	sc -init: инициализировать базу данных
		создать таблицу 
			студентов (Students {Name})
			лекций (Lecture {Date, Topic})
			посещаемости (Attendance {LectureDate, StudentName, Mark})
		создать хранимую процедуру, отмечающую определенного студента на лекции
			MarkAttendance @StudentName, @LectureDate, @Mark
	sc -lecture <DATE> <TOPIC>: добавить лекцию в таблицу лекций (по дате)
		например: sc -lecture 18.12.2017 ADONET
	
	sc -student <NAME>: добавить студента в таблицу студентов
		например: sc -student Ivan

	sc -attend <STUDENT_NAME> <DATE> <MARK>: добавить запись о посещении студента в таблице посещаемости
		например: sc -attend Ivan 18.12.2017 5
		
	sc -report: вывести отчет о посещаемости
		*выводить Topic лекции
		*если студент не посетил ни одной лекции, все равно выводить его имя
		*если лекцию никто не посеил, все равно выводить дату и тему
© 2017 GitHub, Inc.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------------------------------------------------
            var cmd = new CmdExecuter();
            cmd.Execute(args);
            //--------------------------------------------------------------------------------------------------------


            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sla\repo\Homework21\Homework21\Data\StudentCheckerDb.mdf;Integrated Security=True";
            //using (var dbManager = new DBManager(connectionString))
            //{
            //    switch (args[0])
            //    {
            //        case "-report":
            //            dbManager.GetReport();
            //            break;
            //        case "-lecture":
            //            dbManager.AddLecture(args);
            //            break;
            //        case "-init":
            //            dbManager.InitDB();
            //            break;
            //        case "-student":
            //            dbManager.AddStudent(args);
            //            break;
            //        case "-attend":
            //            dbManager.AddAttend(args);
            //            break;
            //        default:
            //            dbManager.GetReport();
            //            break;
            //    }
            //}
        }
    }
    public class DTO
    {
        public DateTime lectureDate;
        public string studentName;
        public int mark;
        public string lectureTopic;
    }
    public class DataManager : IDisposable
    {
        SqlConnection _connection;
        public DataManager(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public bool AddData(IEnumerable<DTO> data)
        {
            StringBuilder sb;
            SqlTransaction Transaction = null;
            try
            {
                _connection.Open();
                Transaction = _connection.BeginTransaction();
                foreach (DTO dataElem in data)
                {
                    sb = new StringBuilder();
                    if (dataElem.lectureDate != null
                        && dataElem.lectureTopic != null)
                    {
                        sb.Append($"insert into dbo.Lecture(Date, Topic) values(@Date, @Topic) ");
                    }
                    if (dataElem.lectureDate != null
                        && dataElem.studentName != null
                        && dataElem.mark != 0)
                    {
                        sb.Append($"insert into Attendance(LectureDate, StudentName, Mark) values (@Date, @Name, @Mark)");
                    }
                    if (dataElem.studentName != null)
                    {
                        sb.Append($"insert into Students(Name) values(@Name) ");
                    }
                    if (sb.Length >= 0)
                    {
                        SqlCommand command = new SqlCommand(sb.ToString(), _connection);
                        command.Transaction = Transaction;
                        command.Parameters.AddWithValue("@Date", dataElem.lectureDate.ToString("yyyy.MM.dd"));
                        command.Parameters.AddWithValue("@Topic", dataElem.lectureTopic);
                        command.Parameters.AddWithValue("@Mark", dataElem.mark);
                        command.Parameters.AddWithValue("@Name", dataElem.studentName);
                        command.ExecuteNonQuery();
                    }
                }
                Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (Transaction != null)
                    Transaction.Rollback();
                return false;
            }
            finally
            {
                if (Transaction != null)
                    Transaction.Dispose();
                _connection.Close();
            }
        }
        public bool AddData(DTO data)
        {
            return AddData(Enumerable.Repeat(data, 1));
        }
        public IEnumerable<DTO>GetData()
        {
            string queryString1 = $"select Topic, Date, Name, Mark from Students " +
                $"left join Attendance on Attendance.StudentName = Students.Name " +
                $"full join Lecture on LectureDate = Date order by Topic, Name ";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);
            var outData = new List<DTO>();
            DTO data;
            SqlDataReader reader = null;
            try
            {
                _connection.Open();
                reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    data = new DTO();
                    if (!DBNull.Value.Equals(reader[0]))
                    {
                        data.lectureTopic = (string)reader[0];
                    }
                    if (!DBNull.Value.Equals(reader[1]))
                    {
                        data.lectureDate = (DateTime)reader[1];
                    }
                    if (!DBNull.Value.Equals(reader[2]))
                    {
                        data.studentName = reader[2].ToString();
                    }                        
                    if (!DBNull.Value.Equals(reader[3]))
                    {
                        data.mark = (int)reader[3];
                    }
                    outData.Add(data);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
                _connection.Close();
            }
            return outData;
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                _connection.Dispose();
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DbManager1() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class CmdExecuter
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Sla\repo\Homework21\Homework21\Data\StudentCheckerDb.mdf;Integrated Security=True";
        public bool Execute(string[] args)
        {
            if (String.IsNullOrWhiteSpace(args[0])) return false;

            args[0] = args[0].ToLower();
            DTO dto = null;
            DateTime date;
            switch (args[0])
            {
                case "-student":
                    if (String.IsNullOrWhiteSpace(args[1])) return false;
                    dto = new DTO();
                    dto.studentName = args[1];
                    break;
                case "-lecture":
                    if (String.IsNullOrWhiteSpace(args[2]) || !DateTime.TryParse(args[1], out date)) return false;
                    dto = new DTO();
                    dto.lectureDate = date;
                    dto.lectureTopic = args[2];
                    break;
                case "-attend":
                    if (String.IsNullOrWhiteSpace(args[1])
                        || !DateTime.TryParse(args[2], out date)
                        || String.IsNullOrWhiteSpace(args[3])) return false;
                    dto = new DTO();
                    dto.studentName = args[1];
                    dto.lectureDate = date;
                    dto.mark = Int32.Parse(args[3]);
                    break;
                case "-report":
                    break;
                default:
                    return false;
            }

            StringBuilder sb;
            using (var mngr = new DataManager(connectionString))
            {
                if (dto != null)
                {
                    return mngr.AddData(dto);
                }
                else
                {
                    foreach (var data in mngr.GetData())
                    {
                        sb = new StringBuilder();
                        sb.Append($"\t{data.lectureTopic,10}");
                        sb.Append($"\t{data.lectureDate,20}");
                        sb.Append($"\t{data.studentName,10}");
                        sb.Append($"\t{data.mark,10}");
                        Console.WriteLine(sb.ToString());
                    }
                    return true;
                }
                    
            }
        }

        //public void CreateReport()
        //{
        //    StringBuilder sb;
        //    using (var mngr = new DbManager1(connectionString))
        //    {
        //        foreach(var data in mngr.GetData())
        //        {
        //            sb = new StringBuilder();
        //            sb.Append($"\t{data.lectureTopic, 10}");
        //            sb.Append($"\t{data.lectureDate, 20}");
        //            sb.Append($"\t{data.studentName, 10}");
        //            sb.Append($"\t{data.mark, 10}");
        //            Console.WriteLine(sb.ToString());
        //        }

        //    }
        //}
    }




    public class DBManager : IDisposable
    {
        SqlConnection _connection;
        public DBManager(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public void InitDB()
        {
            string queryString = $" Drop table Attendance, Lecture, Students \n" +
                $"CREATE TABLE[dbo].[Students]" +
                $"([Name] NVARCHAR (50) NOT NULL," +
                $"PRIMARY KEY CLUSTERED([Name] ASC)) " +
                $"CREATE TABLE[dbo].[Lecture]" +
                $"([Date] DATE          NOT NULL," +
                $"[Topic] NVARCHAR(50) NULL," +
                $"PRIMARY KEY CLUSTERED([Date] ASC)) " +
                $"CREATE TABLE[dbo].[Attendance](" +
                $"[Id] INT           IDENTITY(1, 1) NOT NULL," +
                $"[LectureDate] DATE NULL," +
                $"[StudentName] NVARCHAR(50) NULL," +
                $"[Mark]" +
                $"INT NULL," +
                $"PRIMARY KEY CLUSTERED([Id] ASC)," +
                $"CONSTRAINT[FK_Attendance_ToTable] FOREIGN KEY([StudentName]) REFERENCES[dbo].[Students] ([Name])," +
                $"CONSTRAINT[FK_Attendance_ToTable_1] FOREIGN KEY([LectureDate]) REFERENCES[dbo].[Lecture] ([Date])) ";
            AddData(queryString);
        }

        /// <summary>
        /// sc -report: вывести отчет о посещаемости
        /// *выводить Topic лекции
        /// * если студент не посетил ни одной лекции, все равно выводить его имя
        /// *если лекцию никто не посеил, все равно выводить дату и тему
        /// </summary>
        public void GetReport()
        {
            string queryString1 = $"select Topic, Date, Name, Mark from Students " +
                $"left join Attendance on Attendance.StudentName = Students.Name " +
                $"full join Lecture on LectureDate = Date order by Topic, Name ";
            SqlCommand command1 = new SqlCommand(queryString1, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"||\t{reader[0], 10}|\t{reader[1], 20}|\t{reader[2], 10}|\t{reader[3], 10}||");
                }
                reader.Close();
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
        /// <summary>
        /// sc -lecture <DATE> <TOPIC>: добавить лекцию в таблицу лекций (по дате)
        /// например: sc -lecture 18.12.2017 ADONET
        /// </summary>
        /// <param name="args"></param>
        public void AddLecture(string[] args)
        {
            string queryString = $"insert into dbo.Lecture(Date, Topic) values (@Date, @Topic)";
            SqlCommand command = new SqlCommand(queryString, _connection);
            command.Parameters.AddWithValue("@Date", FormatTime(args[1]).ToString("yyyy.MM.dd"));
            command.Parameters.AddWithValue("@Topic", args[2]);
            AddData(command);
        }
        /// <summary>
        /// sc -student <NAME>: добавить студента в таблицу студентов
        /// например: sc -student Ivan
        /// </summary>
        /// <param name="args"></param>
        public void AddStudent(string[] args)
        {
            string queryString = $"insert into dbo.Students(Name) values (@StudentName)";
            SqlCommand command = new SqlCommand(queryString, _connection);
            command.Parameters.AddWithValue("@StudentName", args[1]);
            AddData(command);
        }
        /// <summary>
        /// sc -attend <STUDENT_NAME> <DATE> <MARK>: добавить запись о посещении студента в таблице посещаемости
        /// например: sc -attend Ivan 18.12.2017 5
        /// </summary>
        /// <param name="args"></param>
        public void AddAttend(string[]args)
        {
            string queryString = $"insert into dbo.Attendance (StudentName, LectureDate, Mark)" +
                $" values (@StudentName, @LectureDate, @Mark)";
            SqlCommand command = new SqlCommand(queryString, _connection);
            command.Parameters.AddWithValue("@StudentName", args[1]);
            command.Parameters.AddWithValue("@LectureDate", FormatTime(args[2]).ToString("yyyy.MM.dd"));
            command.Parameters.AddWithValue("@Mark", args[3]);
            AddData(command);
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
        void AddData(SqlCommand command)
        {
            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
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
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                _connection.Dispose();
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~DBManager()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
