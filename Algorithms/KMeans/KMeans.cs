using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets;
using MachineLearningCLI.Repositories;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.Algorithms.KMeans
{
    public class KMeans : IAlgorithm
	{
		//Should support any dataset later
		//Todo check for convergence and end early
		public void RunKMeans(Dataset<IrisFlower> dataset, int k)
		{
			var allData = dataset.GetDataPoints();
			var numberOfIterations = 250;
			var N = dataset.DatasetMetadata.Size;
			var dimensions = dataset.DatasetMetadata.Columns-1;
			var classes = dataset.DatasetMetadata.Classes;
			var centroids = KMeansHelper.InitializeKMeansCentroidsToBeRandomDataPoints(dataset, k);

			int[] dataPointCentroidAssignments = new int[N];
			int iterations = 0;
			while (iterations < numberOfIterations)
			{
				//Assign each data point to the closest centroid
				for (var i = 0; i < N; i++)
				{
					var datapoint = allData[i].GetDataAsDoubleArray();
					var closestCentroid = -1;
					var closestDistance = -1.0;
					for (var j = 0; j < k; j++)
					{ 
						var distance = MathHelper.EuclideanDistance(datapoint, centroids[j]);
						if (closestDistance > distance || closestDistance == -1)
						{
							closestDistance = distance;
							closestCentroid = j;
						}
						
						dataPointCentroidAssignments[i] = closestCentroid;
					}
				}

				//Update centroids by adding and dividing by the number of data points in each cluster
				double[][] newCentroids = new double[k][];
				int[] assignmentsPerCluster = new int[k];

				for (int i = 0; i < k; i++)
				{
					newCentroids[i] = new double[dimensions];
				}

				//Add add the data points to the new centroids
				for (var i = 0; i < N; i++)
				{
					int clusterAssignment = dataPointCentroidAssignments[i];
					assignmentsPerCluster[clusterAssignment]++;
					var dataPoint = allData[i].GetDataAsDoubleArray();
					for (int j = 0; j < dimensions; j++)
					{
						newCentroids[clusterAssignment][j] += dataPoint[j];
					}
				}

				//Divide by the number of data points in each cluster
				for (int i = 0; i < k; i++)
				{
					if (assignmentsPerCluster[i] == 0) continue;
					for (int j = 0; j < dimensions; j++)
					{
						newCentroids[i][j] /= assignmentsPerCluster[i];
					}
				}
				centroids = newCentroids;

				iterations++;
			}

			Console.WriteLine("Centroids:");
			var centroidCount = 0;
			foreach (var centroid in centroids)
			{
				centroidCount++;
				Console.Write($"   - Centroid {centroidCount}: ");
				Console.WriteLine(string.Join(", ", centroid.Select(c => $"{c:F4}")));
			}
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
