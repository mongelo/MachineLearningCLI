using MachineLearningCLI.Datasets;
using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets.Red_Wine_Quality;
using MachineLearningCLI.Entities;

public class DatasetFactory
{
    public static IDataset CreateDataset(DatasetMetadata datasetMetadata, double trainingSetFraction = 0.7)
    {
        switch (datasetMetadata.CLIName)
        {
            case "IrisFlower":
                return new Dataset<IrisFlower>(datasetMetadata, trainingSetFraction);
            case "RedWine":
                return new Dataset<RedWine>(datasetMetadata, trainingSetFraction);
            default:
                throw new InvalidOperationException("Unknown CLIName");
        }
    }
}