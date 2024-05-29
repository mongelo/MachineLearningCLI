using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Algorithms.KMeans
{
	public static class KMeansHelper
	{
		public static IDataPoint[] InitializeKMeansCentroidsToBeRandomDataPoints(IDataset dataset, int k)
		{
			Random random = new Random();
			return null;
			//return dataset
			//	.OrderBy(x => random.Next())
			//	.Take(k)
			//	.ToArray();
		}
	}
}
