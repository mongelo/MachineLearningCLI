using MachineLearningCLI.Algorithms.KMeans;
using MachineLearningCLI.Algorithms.KNN;
using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public class AlgorithmFactory
{
    public static IAlgorithm CreateAlgorithm(AlgorithmMetadata algorithmMetadata)
    {
        return algorithmMetadata.CLIName switch
        {
            "kmeans" => new KMeansAlgorithm(algorithmMetadata),
            "knn" => new KnnAlgorithm(algorithmMetadata),
            _ => throw new InvalidOperationException("Unknown CLIName"),
        };
    }
}