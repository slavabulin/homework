using System.Collections.Generic;

namespace Task11
{
    public interface IDataProvider
    {
        List<StudentsInfo> ReadTotalInfo();
        bool WriteTotalInfo(List<StudentsInfo> listStudentsInfo);
    }
}