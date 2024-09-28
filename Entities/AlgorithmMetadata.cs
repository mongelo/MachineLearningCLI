namespace MachineLearningCLI.Entities;

public class AlgorithmMetadata
{
    public string Name { get; set; } = String.Empty;
    public string CLIName { get; set; } = String.Empty;
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public string TimeComplexity { get; set; } = String.Empty;
    public string CommandSyntax { get; set; } = String.Empty;
    public string ExampleCommand { get; set; } = String.Empty;
    public string DefaultParameters { get; set; } = String.Empty;
}
