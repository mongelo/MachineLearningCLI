using MachineLearningCLI.Datasets;
using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using MachineLearningCLI.Processors;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.Algorithms.KNN;

public class KnnAlgorithm(AlgorithmMetadata algorithmMetadata) : Algorithm(algorithmMetadata)
{

    private static KnnModel TrainKnn(IDataset dataset, int numberOfNearestNeighbours)
    {
        var knnModelObject = new KnnModelObject
        {
			KnnDatapoints = dataset.GetDataPointsForTraining(),
            NumberOfNearestNeighbours = numberOfNearestNeighbours,
        };

		Console.WriteLine($"Model trained (loaded into memory).");

		return new KnnModel(knnModelObject);
    }

    public static void EvaluateKnn(IDataset dataset, KnnModel model)
    {
        var evaluationData = dataset.GetDataPointsForEvaluation();
        model.Evaluate(evaluationData);
    }

    public override void Run(IEnumerable<string> arguments)
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
            Console.WriteLine($"Specify the number of nearest neighbours (k) to use. Parameter format: \"k=<number-of-nearest-neighbours>\".");
            return;
        }

		var processorOption = DataProcessorOption.None;
		var p = (CommandHelper.GetParameterValueFromArguments(arguments, "p"));
		if (p != null) processorOption = (DataProcessorOption)Int32.Parse(p);

		var dataset = DatasetFactory.CreateDataset(datasetMetadata, processorOption, trainingSetFraction: 0.7);
        if (dataset.NumberOfTrainingDataPoints < int.Parse(k))
        {
            ValidationHelper.ShowValidationMessage($"The number of nearest neighbours, k, must be larger than the amount of training data points ({dataset.NumberOfTrainingDataPoints}).");
            return;
        }

        var numberOfNearestNeighbours = int.Parse(k);
        var model = TrainKnn(dataset, numberOfNearestNeighbours);
        EvaluateKnn(dataset, model);
    }

}
