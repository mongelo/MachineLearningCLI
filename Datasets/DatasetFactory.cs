using MachineLearningCLI.Datasets;
using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Entities;

public class DatasetFactory
{
    public static IDataset CreateDataset(DatasetMetadata datasetMetadata, double trainingSetFraction = 0.7)
    {
        switch (datasetMetadata.CLIName)
        {
            case "IrisFlower":
                return new Dataset<IrisFlower>(datasetMetadata, trainingSetFraction);
            default:
                throw new InvalidOperationException("Unknown CLIName");
        }
    }
}