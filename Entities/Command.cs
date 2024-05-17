namespace MachineLearningCLI.Entities
{
    public class Command
    {
        public string CommandText { get; set; } = String.Empty;
        public string CommandName { get; set; } = String.Empty;
        public string SubCommandName { get; set; } = String.Empty;
        public List<string> Arguments { get; set; } = new List<string>();
    }
}
