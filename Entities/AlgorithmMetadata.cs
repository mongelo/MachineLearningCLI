namespace MachineLearningCLI.Entities;

public class AlgorithmMetadata
{
    public string Name { get; set; } = "";
    public string CLIName { get; set; } = "";
    public int Id { get; set; }
    public string AlgorithmType { get; set; } = "";
    public string Description { get; set; } = "";
    public string TrainingTimeComplexity { get; set; } = "";
    public string PredictionTimeComplexity { get; set; } = "";
    public string CommandSyntax { get; set; } = "";
    public string ExampleCommand { get; set; } = "";
    public string DefaultParameters { get; set; } = "";
}
