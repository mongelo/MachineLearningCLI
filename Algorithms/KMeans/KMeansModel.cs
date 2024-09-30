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
        var closestCentroid = KMeansHelper.CentroidClosestToPoint(((KMeansModelObject)ModelObject).Centroids, dataPoint);
        return dataPoint.GetClass() == closestCentroid.Classification;
    }
}

public class KMeansModelObject : ModelObject
{
    public KMeansModelObject(List<Centroid> centroids) => Centroids = centroids;
    public readonly List<Centroid> Centroids = new List<Centroid>();
}