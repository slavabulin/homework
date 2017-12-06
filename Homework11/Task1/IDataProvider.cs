namespace Task11
{
    public interface IDataProvider
    {
        string[] ReadData();
        bool WriteData(string[] data);
    }
}