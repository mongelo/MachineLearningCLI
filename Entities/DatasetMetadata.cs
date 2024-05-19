namespace MachineLearningCLI.Entities
{
    public class DatasetMetadata
    {
        public string Name { get; set; } = String.Empty;
        public string CLIName { get; set; } = String.Empty;
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Source { get; set; } = String.Empty;
        public int Size { get; set; }
        public string FileFormat { get; set; }
    }
}
