namespace MachineLearningCLI.Algorithms
{
	public abstract class Algorithm
	{
		public abstract void Train();
		public abstract void Predict();
		public abstract void SaveResultToFile();
		public abstract void LoadDataset();
	}
}
