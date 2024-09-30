using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Algorithms;

public abstract class Model
{
    public bool ModelIsTrained { get => ModelObject != null; }
    public virtual ModelObject? ModelObject { get; set; }

    public void Evaluate(DataPoint[] dataPoints)
    {
        if (!ModelIsTrained)
        {
            Console.WriteLine("Model has not been trained yet!");
            return;
        }

        var correctPredictions = 0;
        foreach (var dataPoint in dataPoints)
        {
            if (Predict(dataPoint)) correctPredictions++;
        }
        Console.WriteLine($"Correct predictions: {(double)100 * correctPredictions / dataPoints.Length:F2}%.");
    }


    public abstract bool Predict(DataPoint dataPoint);
}

public abstract class ModelObject;