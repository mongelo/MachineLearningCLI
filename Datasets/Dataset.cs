using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.Datasets;

public interface IDataset
{
    public void PrintRawDataset();
    public void PrintDatasetFormatted();
    public DataPoint[] GetDataPointsForTraining();
    public DataPoint[] GetDataPointsForEvaluation();
    public double[][] GetDataPointsAsDoubleArray();

    public int GetClass(int index);
    public string GetClassName(int index);

    int NumberOfTrainingDataPoints { get; }
    DatasetMetadata DatasetMetadata { get; }
}

public class Dataset<T> : IDataset where T : DataPoint, new()
{
    public DatasetMetadata DatasetMetadata { get; set; }
    public DataPoint[] _dataPoints;
    public DataPoint GenericDataPoint;
    public int NumberOfTrainingDataPoints { get; }

    protected string DatasetRawData { get; set; } = String.Empty;
    private readonly double _trainingSetFraction;
    private string[] _columnNames;
    private static readonly char[] newLineSeparator = ['\n'];
    private static readonly char[] commaSeparator = [','];

    public Dataset(DatasetMetadata datasetMetadata, double _trainingSetFraction)
    {
        DatasetMetadata = datasetMetadata;
        GenericDataPoint = new T();

        _dataPoints = new T[DatasetMetadata.Size];
        _columnNames = new string[DatasetMetadata.Columns];

        this._trainingSetFraction = _trainingSetFraction;
        NumberOfTrainingDataPoints = (int)(this._trainingSetFraction * DatasetMetadata.Size);

        Load();
    }

    private void Load()
    {
        DatasetRawData = DatasetRepository.GetDatsetRawText(DatasetMetadata);

        var allRawRows = DatasetRawData.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);
        _columnNames = allRawRows[0].Replace("\r", "").Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries);
        var allRawRowsList = allRawRows.Skip(1);

        var i = 0;
        foreach (var row in allRawRowsList)
        {
            _dataPoints[i] = DataPoint.CreateDataPoint<T>(row.Replace("\r", ""));
            i++;
        }

        var shouldShuffleDataPoints = _trainingSetFraction != 0 && _trainingSetFraction != 1;
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

    public DataPoint[] GetDataPointsForTraining()
    {
        return _dataPoints
           .Take(NumberOfTrainingDataPoints)
           .Cast<DataPoint>()
           .ToArray();
    }

    public DataPoint[] GetDataPointsForEvaluation()
    {
        return _dataPoints
           .Skip(NumberOfTrainingDataPoints)
           .Cast<DataPoint>()
           .ToArray();
    }

    public double[][] GetDataPointsAsDoubleArray()
    {
        return _dataPoints.Select(x => x.GetDataAsDoubleArray()).ToArray();
    }

    public int GetClass(int index)
    {
        return _dataPoints[index].GetClass();
    }

    public string GetClassName(int classNumber)
    {
        return GenericDataPoint.GetClassName(classNumber);
    }
}
