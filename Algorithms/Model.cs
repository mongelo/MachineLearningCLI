using MachineLearningCLI.Datasets;
using MachineLearningCLI.Datasets.Iris_Flower;

namespace MachineLearningCLI.Algorithms;

public abstract class Model
{
    public bool ModelIsTrained { get => ModelObject != null; }
    public virtual ModelObject? ModelObject { get; set; } = null;

    public void Evaluate(IDataset dataset, IDataPoint[] dataPoints)
    {
        var correctPredictions = 0;
        foreach (var dataPoint in dataPoints)
        {
            if (Predict(dataset, dataPoint)) correctPredictions++;
        }
        Console.WriteLine($"Correct predictions: {(double)100 * correctPredictions / dataPoints.Length:F2}%.");
    }


    public abstract bool Predict(IDataset dataset, IDataPoint dataPoint);
}

public abstract class ModelObject;