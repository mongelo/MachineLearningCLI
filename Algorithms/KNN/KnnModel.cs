using System.Data;
using MachineLearningCLI.Datasets;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.Algorithms.KNN;

public class KnnModel : Model
{
    public KnnModel(KnnModelObject kmeansModelObject) 
    {
        ModelObject = kmeansModelObject;
    }

	public override bool Predict(DataPoint dataPoint)
    {
        var model = (KnnModelObject)ModelObject!;
		var k = model.NumberOfNearestNeighbours;
		var numberOfTrainingDataPoints = model.KnnDatapoints.Length;
		var closestPoints = new (double distance, int classValue)[k];
		double cutOffDistance = -1;

		//Calculate distance to all points, keep track of k nearest points
        var currentDataPoint = dataPoint.GetDataAsDoubleArray();
		for (var i=0; i< numberOfTrainingDataPoints; i++)
		{
			var modelDatapoint = model.KnnDatapoints[i];
			var distance = MathHelper.EuclideanDistance(currentDataPoint, modelDatapoint.GetDataAsDoubleArray());
			if (i < k) 
			{
				closestPoints[i] = (distance, modelDatapoint.GetClass());
			}
			if (i == k - 1) 
			{
				closestPoints = closestPoints.OrderBy(cp => cp.distance).ToArray();
				cutOffDistance = closestPoints.Last().distance;
			}
			if (i >= k)
			{
				//Check if new distance is closer than previous distances
				if (distance < cutOffDistance)
				{
					//Check for proper place in array, insert and shift other values in array
					for (var j = k-1; j >= -1; j--) 
					{
						if (j != -1 && distance < closestPoints[j].distance)
						{
							if (j == 0) continue;
							closestPoints[j].distance = closestPoints[j - 1].distance;
							closestPoints[j].classValue = closestPoints[j - 1].classValue;
						}
						else 
						{
							closestPoints[j+1].distance = distance;
							closestPoints[j+1].classValue = modelDatapoint.GetClass();
							break;
						}
					}
					cutOffDistance = closestPoints.Last().distance;
				}
			}
		}

		//Implement different tie-breaking techniques (distance-based, random)
		var mostCommonClass = closestPoints
			.GroupBy(cp => cp.classValue)
			.OrderByDescending(g => g.Count())
			.First()
			.Key;

		//Check if majority nearest class is the correct class
		return dataPoint.GetClass() == mostCommonClass;
	}
}

public class KnnModelObject() : ModelObject
{
	public required DataPoint[] KnnDatapoints { get; set; }
    public int NumberOfNearestNeighbours { get; set; }
}