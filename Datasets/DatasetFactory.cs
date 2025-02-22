using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets.Red_Wine_Quality;
using MachineLearningCLI.Entities;

namespace MachineLearningCLI.Datasets;

public class DatasetFactory
{
    public static IDataset CreateDataset(DatasetMetadata datasetMetadata, double trainingSetFraction = 0.7)
    {
        return datasetMetadata.CLIName switch
        {
            "IrisFlower" => new Dataset<IrisFlower>(datasetMetadata, trainingSetFraction),
            "RedWine" => new Dataset<RedWine>(datasetMetadata, trainingSetFraction),
            _ => throw new InvalidOperationException("Unknown CLIName"),
        };
    }
}