using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Algorithms.KNN;

public class KnnModel : Model
{
    public KnnModel(KnnModelObject kmeansModelObject) 
    {
        ModelObject = kmeansModelObject;
    }

    public override bool Predict(DataPoint dataPoint)
    {
        // TODO IMPLEMENT

        //1. Calculate distance to all points,

        //2. Find the k nearest neighbours,

        //3. Implement differetn tie-breaking techniques (distance-based, random)

        //4. Check if majority nearest class is the correct class

        return false;
    }
}

public class KnnModelObject() : ModelObject
{
    public double[][] KnnDataPoints { get; set; } = [];
    public int NumberOfNearestNeighbours { get; set; }
}