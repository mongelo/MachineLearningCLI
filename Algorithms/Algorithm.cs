using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms;

public interface IAlgorithm
{
    public void Run(IEnumerable<string> arguments);
}

public class Algorithm<T> : IAlgorithm where T : IAlgorithm, new()
{
    public T AlgorithmGeneric;
    public AlgorithmMetadata AlgorithmMetadata { get; set; }

    public virtual void Run(IEnumerable<string> arguments) { AlgorithmGeneric.Run(arguments); }

    public Algorithm(AlgorithmMetadata algorithmMetadata)
    {
        AlgorithmGeneric = new T();
        AlgorithmMetadata = algorithmMetadata;
    }

}
