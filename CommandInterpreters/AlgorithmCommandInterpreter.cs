using MachineLearningCLI.Datasets;
using MachineLearningCLI.Datasets.Iris_Flower;
using MachineLearningCLI.Entities;
using MachineLearningCLI.Repositories;
using System.Data;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class AlgorithmCommandInterpreter
    {
        private const string _commandName = "algorithm";
        private static List<AlgorithmMetadata> _algorithmsMetadata = new List<AlgorithmMetadata>();

        public static void Interpret(Command command)
        {
            ReloadAlgorithmMetadata();

            switch (command.SubCommandName)
            {
                case "":
                    ConsoleHelper.ShowHelpTooltip(_commandName);
                    break;
                case "help":
                case "h":
                    ShowAlgorithmHelp();
                    break;
                case "list":
                case "l":
                    HandleAlgorithmListCommand(command.Arguments);
                    break;
                //DETAIL COMMAND
                default:
                    ConsoleHelper.HandleUnknownCommand();
                    break;
            }
        }

        private static void ShowAlgorithmHelp()
        {
            Console.WriteLine("Try commands like:");
            ConsoleHelper.WriteHelpText("algorithm list", "Lists all available algorithms.");
        }

        private static void HandleAlgorithmListCommand(IEnumerable<string> arguments)
        {
            Console.WriteLine("Total Algorithms: " + _algorithmsMetadata.Count);
            ShowAllAlgorithms();
        }

        private static void ReloadAlgorithmMetadata()
        {
            _algorithmsMetadata.Clear();
            _algorithmsMetadata = AlgorithmRepository.LoadAllAlgorithmMetadata();
        }

        private static void ShowAllAlgorithms()
        {
            _algorithmsMetadata.ForEach(algorithm =>
            {
                Console.WriteLine($"-  {algorithm.CLIName}, Id={algorithm.Id}");
            });
        }
        
    }
}
