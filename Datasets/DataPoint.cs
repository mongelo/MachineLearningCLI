namespace MachineLearningCLI.Datasets;

public abstract class DataPoint
{
    public abstract int GetClass();
    public abstract string GetClassName(int classNumber);
    public abstract double[] GetDataAsDoubleArray();
    public abstract void Print();
    public abstract void InitializeDataPoint(string values);
    public abstract void OverwriteWithProcessedValues(double[] values);

    public static T CreateDataPoint<T>(string values) where T : DataPoint, new()
    {
        var dataPoint = new T();
        dataPoint.InitializeDataPoint(values);
        return dataPoint;
    }
}
