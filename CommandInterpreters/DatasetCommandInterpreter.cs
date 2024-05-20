using MachineLearningCLI.Datasets;
using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Entities;
using MachineLearningCLI.Repositories;
using System.Data;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class DatasetCommandInterpreter
    {
        private const string _commandName = "dataset";
        private static List<DatasetMetadata> _datasetsMetadata = new List<DatasetMetadata>();

        public static void Interpret(Command command)
        {
            ReloadDataset();

            switch (command.SubCommandName)
            {
                case "":
                    HandleNoSubcommand();
                    break;
                case "help":
                case "h":
                    ShowDatasetHelp();
                    break;
                case "list":
                case "l":
                    HandleDatasetListCommand(command.Arguments);
                    break;
                case "detail":
                case "d":
                    ShowDetailedDatasetInformation(command.Arguments);
                    break;
                case "print":
                case "p":
                    PrintDataset(command.Arguments);
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
            ConsoleHelper.WriteHelpText("dataset list", "Lists all available datasets.");
            ConsoleHelper.WriteHelpText("dataset detail <dataset-name || dataset-id>","Shows the detailed metadata of a dataset specified by name or id.");
            ConsoleHelper.WriteHelpText("dataset print <dataset-name || dataset-id> [raw]","Prints a formatted representation of the dataset. -raw prints dataset directly from file.");
        }

        private static void ShowDetailedDatasetInformation(IEnumerable<string> arguments) 
        {
            var datasetQuery = arguments.FirstOrDefault();
            if (datasetQuery == null) 
            {
                Console.WriteLine($"Specify a dataset name to list the details for. Command format: \"dataset detail <dataset-name || dataset-id>\".");
                return;
            }

            var datasetMetadata = GetDatasetMetadataFromQuery(datasetQuery);

            if (datasetMetadata == null)
            {
                NoDatasetFound(datasetQuery);
                return;
            }

            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Name: {datasetMetadata.Name}, Id={datasetMetadata.Id}");
            Console.WriteLine($"CLI Name: {datasetMetadata.CLIName}");
            Console.WriteLine($"Size: N={datasetMetadata.Size}");
            Console.WriteLine($"Source: {datasetMetadata.Source}");
            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Description: {datasetMetadata.Description}");
        }

        private static void PrintDataset(IEnumerable<string> arguments)
        {
            var datasetQuery = arguments.FirstOrDefault();
            if (datasetQuery == null)
            {
                Console.WriteLine($"Specify a dataset name to print. Command format: \"dataset print <dataset-name || dataset-id> [raw]\".");
                return;
            }

            var datasetMetadata = GetDatasetMetadataFromQuery(datasetQuery);
            if (datasetMetadata == null)
            {
                NoDatasetFound(datasetQuery);
                return;
            }

            //Change in the future
            var dataset = new Dataset<IrisFlower>(datasetMetadata);
            
            var isRaw = arguments.Contains("raw") || arguments.Contains("r");

            if (isRaw)
            {
                dataset.PrintRawDataset();
            }
            else
            {
                dataset.PrintDatasetFormatted();
            }
        }

        private static DatasetMetadata? GetDatasetMetadataFromQuery(string query)
        {
            return _datasetsMetadata.SingleOrDefault(meta =>
                meta.CLIName.ToLower() == query.ToLower() || meta.Id.ToString() == query);
        }

        private static void HandleDatasetListCommand(IEnumerable<string> arguments)
        {
            Console.WriteLine("Total Datasets: " + _datasetsMetadata.Count);
            ShowAllDatasets();
        }

        private static void ReloadDataset()
        {
            _datasetsMetadata.Clear();
            _datasetsMetadata = DatasetRepository.LoadAllDatasetMetadata();
        }

        private static void ShowAllDatasets()
        {
            _datasetsMetadata.ForEach(dataset => {
                Console.WriteLine($"-  {dataset.CLIName} (N={dataset.Size}), Id={dataset.Id}");
            });
        }
        private static void NoDatasetFound(string datasetQuery)
        {
            Console.WriteLine("No data set called " + datasetQuery);
            Console.WriteLine("Available datasets:");
            ShowAllDatasets();
        }
        
    }
}
