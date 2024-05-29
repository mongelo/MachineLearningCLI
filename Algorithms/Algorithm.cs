using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Algorithms
{
	public interface IAlgorithm
	{
		public void Run(IEnumerable<string> arguments);
		public void Train(IEnumerable<string> arguments);
		public void Predict(IEnumerable<string> arguments);
		public void SaveResultToFile(IEnumerable<string> arguments);
		public void LoadDataset(IEnumerable<string> arguments);
	}

	public class Algorithm<T> : IAlgorithm where T : IAlgorithm, new()//not sure if T should also be IAlgorithm
	{
		public T AlgorithmGeneric;
		public AlgorithmMetadata AlgorithmMetadata { get; set; }

		public virtual void Run(IEnumerable<string> arguments) { AlgorithmGeneric.Run(arguments); }
		public virtual void Train(IEnumerable<string> arguments) { AlgorithmGeneric.Train(arguments); }
		public virtual void Predict(IEnumerable<string> arguments) { AlgorithmGeneric.Predict(arguments); }
		public virtual void SaveResultToFile(IEnumerable<string> arguments) { AlgorithmGeneric.SaveResultToFile(arguments); }
		public virtual void LoadDataset(IEnumerable<string> arguments) { AlgorithmGeneric.LoadDataset(arguments);  }

		public Algorithm(AlgorithmMetadata algorithmMetadata)
		{
			AlgorithmGeneric = new T();
			AlgorithmMetadata = algorithmMetadata;
		}

	}
}
