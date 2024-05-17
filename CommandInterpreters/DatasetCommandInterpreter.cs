using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using System.Text.Json;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class DatasetCommandInterpreter
    {
        private const string _commandName = "dataset";
        private const string _datasetFolderName = "Datasets";
        private static List<DatasetMetadata> _datasetsMetadata = new List<DatasetMetadata>();

        public static void Interpret(Command command)
        {
            ReloadDataset();

            switch (command.SubCommandName)
            {
                case "":
                    HandleNoSubcommand();
                    break;
                case "--help":
                case "--h":
                    ShowDatasetHelp();
                    break;
                case "--list":
                case "--l":
                    HandleDatasetListCommand(command.Arguments);
                    break;
                case "--detail":
                case "--d":
                    ShowDetailedDatasetInformation(command.Arguments);
                    break;

                default:
                    ConsoleHelper.HandleUnknownCommand();
                    break;
            }
        }

        private static void HandleNoSubcommand()
        {
            ConsoleHelper.ShowHelpTooltip(_commandName);
        }

        private static void ShowDatasetHelp()
        {
            Console.WriteLine("Try commands like:");
            Console.WriteLine("dataset --list");
        }

        private static void ShowDetailedDatasetInformation(IEnumerable<string> arguments) 
        {
            var datasetCLIName = arguments.First();
            var datasetMetadata = _datasetsMetadata.Where(meta => meta.CLIName.ToLower() == datasetCLIName.ToLower()).SingleOrDefault();

            if (datasetMetadata == null)
            {
                Console.WriteLine("No data set called " + datasetCLIName);
                Console.WriteLine("Available datasets:");
                ShowAllDatasets();
                return;
            }

            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Name: {datasetMetadata.Name}");
            Console.WriteLine($"CLI Name: {datasetMetadata.CLIName}");
            Console.WriteLine($"Size: N={datasetMetadata.Size}");
            Console.WriteLine($"Source: {datasetMetadata.Source}");
            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Description: {datasetMetadata.Description}");
        }

        private static void HandleDatasetListCommand(IEnumerable<string> arguments)
        {
            Console.WriteLine("Total Datasets: " + _datasetsMetadata.Count);
            ShowAllDatasets();
        }

        private static void ReloadDataset()
        {
            _datasetsMetadata.Clear();

            var projectFolder = FileHelper.GetProjectFolder();
            var directoryPath = Path.Combine(projectFolder, _datasetFolderName);
            var datasetDirectories = Directory.GetDirectories(directoryPath);

            foreach (var directory in datasetDirectories)
            {
                var jsonData = FileHelper.ReadJsonFromFile(directory + "\\datasetMetadata.json");
                var dataset = JsonSerializer.Deserialize<DatasetMetadata>(jsonData);
                if (dataset != null) _datasetsMetadata.Add(dataset);
            }
        }

        private static void ShowAllDatasets()
        {
            _datasetsMetadata.ForEach(dataset => {
                Console.WriteLine($"-  {dataset.CLIName} (N={dataset.Size})");
            });
        }
        
    }
}
