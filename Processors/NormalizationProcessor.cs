using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Processors;

public static class NormalizationProcessor
{

	public static IDataset Normalize(IDataset dataset)
	{
		var dataPoints = dataset.GetDataPoints();
		var numberOfColumns = dataset.DatasetMetadata.Columns-1;

		var max = new double[numberOfColumns];
		var min = new double[numberOfColumns];

		for (int i = 0; i < numberOfColumns; i++)
		{
			min[i] = double.PositiveInfinity;
			max[i] = double.NegativeInfinity;
		}

		//Calculate min and maxes
		foreach (var dataPoint in dataPoints)
		{
			var dataPointDoubleArray = dataPoint.GetDataAsDoubleArray();

			for (int i = 0; i < numberOfColumns; i++)
			{
				if (dataPointDoubleArray[i] < min[i])
					min[i] = dataPointDoubleArray[i];

				if (dataPointDoubleArray[i] > max[i])
					max[i] = dataPointDoubleArray[i];
			}
		}

		//Normalize each data point
		foreach (var dataPoint in dataPoints)
		{
			var normalizedDataPoint = new double[numberOfColumns];

			for (int i = 0; i < numberOfColumns; i++)
			{
				if (max[i] != min[i])
				{
					normalizedDataPoint[i] = (dataPoint.GetDataAsDoubleArray()[i] - min[i]) / (max[i] - min[i]);
				}
				else
				{
					normalizedDataPoint[i] = 0;
				}
			}

			dataPoint.OverwriteWithProcessedValues(normalizedDataPoint);
		}

		return dataset;
	}

}