using MachineLearningCLI.Algorithms.KMeans;
using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public class AlgorithmFactory
{
    public static IAlgorithm CreateAlgorithm(AlgorithmMetadata algorithmMetadata)
    {
        return algorithmMetadata.CLIName switch
        {
            "kmeans" => new KMeansAlgorithm(algorithmMetadata),
            _ => throw new InvalidOperationException("Unknown CLIName"),
        };
    }
}