using MachineLearningCLI.Datasets;

namespace MachineLearningCLI.Processors;

public enum DataProcessorOption
{
	None,
	Normalization,
}

public static class Processor
{
	public static IDataset Process(IDataset dataset, DataProcessorOption processorOption)
	{
		return processorOption switch
		{
			DataProcessorOption.Normalization => NormalizationProcessor.Normalize(dataset),
			_ => dataset,
		};
	}
}