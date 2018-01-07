using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Homework21
{
    public class DTO
    {
        public CmdType cmdType;
        public DateTime lectureDate;
        public string studentName;
        public int mark;
        public string lectureTopic;
    }
    public enum CmdType
    {
        report,
        lecture,
        student,
        attend,
        init
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
                    SqlCommand command = null;
                    if (dataElem.cmdType == CmdType.lecture
                        && dataElem.lectureDate != null
                        && dataElem.lectureTopic != null)
                    {
                        sb.Append($"insert into dbo.Lecture(Date, Topic) values(@Date, @Topic) ");
                        command = new SqlCommand(sb.ToString(), _connection, Transaction);
                        command.Parameters.AddWithValue("@Date", dataElem.lectureDate.ToString("yyyy.MM.dd"));
                        command.Parameters.AddWithValue("@Topic", dataElem.lectureTopic);
                    }
                    if (dataElem.cmdType == CmdType.attend
                        && dataElem.lectureDate != null
                        && dataElem.studentName != null
                        && dataElem.mark != 0)
                    {
                        sb.Append($"insert into Attendance(LectureDate, StudentName, Mark) values (@Date, @Name, @Mark)");
                        command = new SqlCommand(sb.ToString(), _connection, Transaction);
                        command.Parameters.AddWithValue("@Date", dataElem.lectureDate.ToString("yyyy.MM.dd"));
                        command.Parameters.AddWithValue("@Mark", dataElem.mark);
                        command.Parameters.AddWithValue("@Name", dataElem.studentName);
                    }
                    if (dataElem.cmdType == CmdType.student
                        && dataElem.studentName != null)
                    {
                        sb.Append($"insert into Students(Name) values(@Name) ");
                        command = new SqlCommand(sb.ToString(), _connection, Transaction);
                        command.Parameters.AddWithValue("@Name", dataElem.studentName);
                    }
                    if (dataElem.cmdType == CmdType.init)
                    {
                        sb.Append($" Drop table Attendance, Lecture, Students \n" +
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
                            $"CONSTRAINT[FK_Attendance_ToTable_1] FOREIGN KEY([LectureDate]) REFERENCES[dbo].[Lecture] ([Date])) ");
                        command = new SqlCommand(sb.ToString(), _connection, Transaction);
                    }
                    if (sb.Length >= 0)
                    {
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
        public IEnumerable<DTO> GetData()
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
}
