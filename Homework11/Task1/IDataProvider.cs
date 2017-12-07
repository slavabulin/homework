namespace Task1
{
    public interface IDataProvider
    {
        string[] ReadData();
        bool WriteData(string[] data);
    }
}