using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.Datasets;

public interface IDataset
{
    public void PrintRawDataset();
    public void PrintDatasetFormatted();
    IDataPoint[] GetDataPointsForTraining();
    double[][] GetDataPointsAsDoubleArray();
    int GetClass(int index);
    string GetClassName(int index);
}

public class Dataset<T> : IDataset where T : IData, new()
{
    public DatasetMetadata DatasetMetadata { get; set; }
    public DataPoint<T>[] _dataPoints;
    public T StaticDataPoint;
    public int NumberOfTrainingDataPoints;

    protected string DatasetRawData { get; set; } = String.Empty;

    private double trainingSetFraction;

    private string[] _columnNames { get; set; }

    public Dataset(DatasetMetadata datasetMetadata, double _trainingSetFraction)
    {
        DatasetMetadata = datasetMetadata;
        _dataPoints = new DataPoint<T>[DatasetMetadata.Size];
        _columnNames = new string[DatasetMetadata.Columns];
        StaticDataPoint = new T();
        trainingSetFraction = _trainingSetFraction;
        NumberOfTrainingDataPoints = (int)(trainingSetFraction * DatasetMetadata.Size);

        Load();
    }

    public void Load()
    {
        DatasetRawData = DatasetRepository.GetDatsetRawText(DatasetMetadata);

        var allRawRows = DatasetRawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _columnNames = allRawRows[0].Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var allRawRowsList = allRawRows.Skip(1);

        var i = 0;
        foreach (var row in allRawRowsList)
        {
            _dataPoints[i] = new DataPoint<T>(row.Replace("\r", ""));
            i++;
        }

        var shouldShuffleDataPoints = trainingSetFraction != 0 && trainingSetFraction != 1;
        if (shouldShuffleDataPoints)
        {
            ArrayHelper.ShuffleArray(_dataPoints);
        }

    }

    public void PrintRawDataset()
    {
        Console.WriteLine(DatasetRawData);
    }

    public void PrintDatasetFormatted()
    {
        foreach (var column in _columnNames)
        {
            Console.Write(column + "   ");
        }
        ConsoleHelper.PrintEmptyLine();

        var i = 0;
        while (i < DatasetMetadata.Size)
        {
            _dataPoints[i].Print();
            i++;
        }
    }

    public IDataPoint[] GetDataPointsForTraining()
    {
        return _dataPoints
           .Take(NumberOfTrainingDataPoints)
           .Cast<IDataPoint>()
           .ToArray();
    }

    public IDataPoint[] GetDataPointsForEvaluation()
    {
        return _dataPoints
           .Skip(NumberOfTrainingDataPoints)
           .Cast<IDataPoint>()
           .ToArray();
    }

    public double[][] GetDataPointsAsDoubleArray()
    {
        return _dataPoints.Select(x => x.GetDataAsDoubleArray()).ToArray();
    }

    public int GetClass(int index)
    {
        return _dataPoints[index].Data.GetClass();
    }

    public string GetClassName(int classNumber)
    {
        return StaticDataPoint.GetClassName(classNumber);
    }
}
