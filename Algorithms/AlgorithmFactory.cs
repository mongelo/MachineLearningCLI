using MachineLearningCLI.Algorithms.KMeans;
using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public class AlgorithmFactory
{
    public static IAlgorithm CreateAlgorithm(AlgorithmMetadata algorithmMetadata)
    {
        switch (algorithmMetadata.CLIName)
        {
            case "kmeans":
                return new Algorithm<KMeansAlgorithm>(algorithmMetadata);
            default:
                throw new InvalidOperationException("Unknown CLIName");
        }
    }
}