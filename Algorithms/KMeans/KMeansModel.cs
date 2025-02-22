using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Algorithms.KMeans;

public class KMeansModel : Model
{
    public KMeansModel(KMeansModelObject kmeansModelObject) 
    {
        ModelObject = kmeansModelObject;
    }

    public override bool Predict(DataPoint dataPoint)
    {
        var closestCentroid = KMeansHelper.CentroidClosestToPoint(((KMeansModelObject)ModelObject!).Centroids, dataPoint);
        return dataPoint.GetClass() == closestCentroid.Classification;
    }
}

public class KMeansModelObject(List<Centroid> centroids) : ModelObject
{
    public readonly List<Centroid> Centroids = centroids;
}