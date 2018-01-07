using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework21
{
    public class ConsoleLogger : IDataLogger
    {
        public bool Log(IEnumerable<DTO> data)
        {
            StringBuilder sb;
            foreach (var dataElem in data)
            {
                sb = new StringBuilder();
                sb.Append($"\t{dataElem.lectureTopic,10}");
                sb.Append($"\t{dataElem.lectureDate,20}");
                sb.Append($"\t{dataElem.studentName,10}");
                sb.Append($"\t{dataElem.mark,10}");
                Console.WriteLine(sb.ToString());
            }
            return true;
        }
    }
}
