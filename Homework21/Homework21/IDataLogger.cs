using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework21
{
    public interface IDataLogger
    {
        bool Log(IEnumerable<DTO> data);
    }
}
