using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets;
using MachineLearningCLI.Entities;

public class DatasetFactory
{
	public static IDataset CreateDataset(DatasetMetadata datasetMetadata)
	{
		switch (datasetMetadata.CLIName)
		{
			case "IrisFlower":
				return new Dataset<IrisFlower>(datasetMetadata);
			default:
				throw new InvalidOperationException("Unknown CLIName");
		}
	}
}