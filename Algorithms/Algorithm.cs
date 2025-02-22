using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public interface IAlgorithm
{
    public void Run(IEnumerable<string> arguments);
}

public abstract class Algorithm(AlgorithmMetadata algorithmMetadata) : IAlgorithm
{
    public AlgorithmMetadata? AlgorithmMetadata { get; set; } = algorithmMetadata;

    public abstract void Run(IEnumerable<string> arguments);
}
