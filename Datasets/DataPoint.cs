namespace MachineLearningCLI.Datasets;

public interface IData
{
    void InitializeDataPoint(string values);
    void PrintDataPoint();

    double[] GetDataAsDoubleArray();
    int GetClass();
    string GetClassName(int classNumber);
}

public interface IDataPoint
{
    double[] GetDataAsDoubleArray();
    int GetClass();
}

public class DataPoint<T> : IDataPoint where T : IData, new()
{
    public T Data;

    public DataPoint(string values)
    {
        Data = new T();
        Data.InitializeDataPoint(values);
    }

    public int GetClass()
    {
        return Data.GetClass();
    }

    public double[] GetDataAsDoubleArray()
    {
        return Data.GetDataAsDoubleArray();
    }

    public void Print()
    {
        Data.PrintDataPoint();
    }
}
