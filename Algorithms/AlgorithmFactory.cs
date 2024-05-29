using MachineLearningCLI.Entities;
using MachineLearningCLI.Algorithms;
using MachineLearningCLI.Algorithms.KMeans;

public class AlgorithmFactory
{
	public static IAlgorithm CreateAlgorithm(AlgorithmMetadata algorithmMetadata)
	{
		switch (algorithmMetadata.CLIName)
		{
			case "kmeans":
				return new Algorithm<KMeans>(algorithmMetadata);
			default:
				throw new InvalidOperationException("Unknown CLIName");
		}
	}
}