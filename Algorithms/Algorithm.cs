using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public interface IAlgorithm
{
    public void Run(IEnumerable<string> arguments);
}

public abstract class Algorithm : IAlgorithm
{
    public AlgorithmMetadata? AlgorithmMetadata { get; set; }

    public abstract void Run(IEnumerable<string> arguments);

    protected Algorithm(AlgorithmMetadata algorithmMetadata)
    {
        AlgorithmMetadata = algorithmMetadata;
    }
}
