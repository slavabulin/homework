using System;
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
    class StudentChecker
    {
        static void Main(string[] args)
        {
            var cmd = new CmdExecuter();
            cmd.Execute(args);
        }
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
                    dto = new DTO
                    {
                        cmdType = CmdType.student,
                        studentName = args[1]
                    };
                    break;
                case "-lecture":
                    if (String.IsNullOrWhiteSpace(args[2]) || !DateTime.TryParse(args[1], out date)) return false;
                    dto = new DTO
                    {
                        cmdType = CmdType.lecture,
                        lectureDate = date,
                        lectureTopic = args[2]
                    };
                    break;
                case "-attend":
                    if (String.IsNullOrWhiteSpace(args[1])
                        || !DateTime.TryParse(args[2], out date)
                        || String.IsNullOrWhiteSpace(args[3])) return false;
                    dto = new DTO
                    {
                        cmdType = CmdType.attend,
                        studentName = args[1],
                        lectureDate = date
                    };
                    Int32.TryParse(args[3], out dto.mark);
                    break;
                case "-report":
                    dto = new DTO
                    {
                        cmdType = CmdType.report
                    };
                    break;
                case "-init":
                    dto = new DTO
                    {
                        cmdType = CmdType.init
                    };
                    break;
                default:
                    return false;
            }

            using (var mngr = new DataManager(connectionString))
            {
                if (dto != null)
                {
                    if (dto.cmdType != CmdType.report)
                    {
                        return mngr.AddData(dto);
                    } else
                    {
                        var CLogger = new ConsoleLogger();
                        return CLogger.Log(mngr.GetData());
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
