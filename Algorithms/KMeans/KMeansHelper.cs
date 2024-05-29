using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Algorithms.KMeans
{
	public static class KMeansHelper
	{
		public static double[][] InitializeKMeansCentroidsToBeRandomDataPoints(IDataset dataset, int k)
		{
			Random random = new Random();
			
			return dataset.GetDataPointsAsDoubleArray()
				.OrderBy(x => random.Next())
				.Take(k)
				.ToArray();
		}
	}
}
