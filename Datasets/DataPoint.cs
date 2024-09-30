namespace MachineLearningCLI.Datasets;

public interface IData
{
    public void InitializeDataPoint(string values);
    public void PrintDataPoint();

    public double[] GetDataAsDoubleArray();
    public int GetClass();
    public string GetClassName(int classNumber);
}

public interface IDataPoint
{
    public double[] GetDataAsDoubleArray();
    public int GetClass();
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
