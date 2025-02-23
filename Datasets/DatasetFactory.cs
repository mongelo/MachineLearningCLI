using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Datasets.Red_Wine_Quality;
using MachineLearningCLI.Entities;
using MachineLearningCLI.Processors;

namespace MachineLearningCLI.Datasets;

public class DatasetFactory
{
    public static IDataset CreateDataset(DatasetMetadata datasetMetadata, DataProcessorOption processor, double trainingSetFraction = 0.7)
    {
        return datasetMetadata.CLIName switch
        {
            "IrisFlower" => new Dataset<IrisFlower>(datasetMetadata, processor, trainingSetFraction),
            "RedWine" => new Dataset<RedWine>(datasetMetadata, processor, trainingSetFraction),
            _ => throw new InvalidOperationException("Unknown CLIName"),
        };
    }
}