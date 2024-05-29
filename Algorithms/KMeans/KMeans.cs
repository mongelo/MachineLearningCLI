using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.Algorithms.KMeans
{
	public class KMeans : IAlgorithm
	{
		//Should support any dataset later
		public void RunKMeans(Dataset<IrisFlower> dataset, int k)
		{ 
			var centroids = KMeansHelper.InitializeKMeansCentroidsToBeRandomDataPoints(dataset, k);
		}


		public void Run(IEnumerable<string> arguments)
		{
			var datasetQuery = CommandHelper.GetParameterValueFromArguments(arguments, "d");
			if (datasetQuery == null)
			{
				Console.WriteLine($"Specify a dataset to use. Parameter format: \"d=<dataset-name || dataset-id>\".");
				return;
			}

			var datasetMetadata = DatasetRepository.LoadDatasetMetadata(datasetQuery);
			if (datasetMetadata == null)
			{
				Console.WriteLine($"Dataset not found.");
				return;
			}

			var k = CommandHelper.GetParameterValueFromArguments(arguments, "k");
			if (k == null)
			{
				Console.WriteLine($"Specify the number of clusters (k) to use. Parameter format: \"k=<number-of-clusters>\".");
				return;
			}

			var dataset = (Dataset<IrisFlower>)DatasetFactory.CreateDataset(datasetMetadata);
			RunKMeans(dataset, Int32.Parse(k));
		}

		public void Train(IEnumerable<string> arguments)
		{
			throw new NotImplementedException();
		}

		public void Predict(IEnumerable<string> arguments)
		{
			throw new NotImplementedException();
		}

		public void SaveResultToFile(IEnumerable<string> arguments)
		{
			throw new NotImplementedException();
		}

		public void LoadDataset(IEnumerable<string> arguments)
		{
			throw new NotImplementedException();
		}

	}
}
