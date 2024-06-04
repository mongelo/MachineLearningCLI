using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets;
using MachineLearningCLI.Repositories;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.Algorithms.KMeans
{
    public class KMeans : IAlgorithm
	{
		const int numberOfConvergesInARowToComplete = 100;
		const int defaultNumberOfIterations = 250;

        //Should support any dataset later
        public void RunKMeans(Dataset<IrisFlower> dataset, int k, int numberOfIterations)
		{
			var allData = dataset.GetDataPoints();
			var N = dataset.DatasetMetadata.Size;
			var dimensions = dataset.DatasetMetadata.Columns-1;
			var classes = dataset.DatasetMetadata.Classes;
			var centroids = KMeansHelper.InitializeKMeansCentroidsToBeRandomDataPoints(dataset, k);
			var convergesInARow = 0;

			int[] dataPointCentroidAssignments = new int[N];
			if(numberOfIterations==default) numberOfIterations = defaultNumberOfIterations;

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

				//Check if the centroids have changed
				if (MathHelper.AreEqual(centroids, newCentroids, 0.0000001))
				{
					convergesInARow++;
					if(convergesInARow == numberOfConvergesInARowToComplete)
					{
						Console.WriteLine($"Converged after: {iterations + 1} iterations.");
						break;
					}
				}
				else 
				{
					convergesInARow = 0;
				}

				centroids = newCentroids;

				iterations++;
			}

			//Assign a class to each centroid based on counts per class in dataPointCentroidAssignments
			int[] centroidClass = new int[k];
			for (int i = 0; i < k; i++)
			{
				int[] classCounts = new int[classes];
				for (int j = 0; j < N; j++)
				{
					if (dataPointCentroidAssignments[j] == i)
					{
						classCounts[allData[j].GetClass()]++;
					}
				}

				int maxClass = 0;
				int maxCount = 0;
				for (int j = 0; j < classes; j++)
				{
					if (classCounts[j] > maxCount)
					{
						maxCount = classCounts[j];
						maxClass = j;
					}
				}

				centroidClass[i] = maxClass;
			}	

			Console.WriteLine("Centroids:");
			var centroidCount = 0;
			foreach (var centroid in centroids)
			{
				centroidCount++;
				Console.Write($"   - Centroid {centroidCount} (Most likely class = {dataset.GetClassName(centroidClass[centroidCount - 1])}): ");
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

			var iterations = CommandHelper.GetParameterValueFromArguments(arguments, "i");

			var dataset = (Dataset<IrisFlower>)DatasetFactory.CreateDataset(datasetMetadata);

			RunKMeans(dataset, Int32.Parse(k), iterations==null ? default : Int32.Parse(iterations));

			//TODO: Run only on 70% and then evaluate the model on the remaining 30%

		}

	}
}
