using MachineLearningCLI.Entities;
using MachineLearningCLI.Repositories;
using System.Linq;

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
                case "detail":
                case "d":
                    ShowDetailedAlgorithmInformation(command.Arguments);
                    break;
				case "run":
				case "r":
					HandleAlgorithmRunCommand(command.Arguments);
					break;

				default:
                    ConsoleHelper.HandleUnknownCommand();
                    break;
            }
        }

        private static void HandleAlgorithmRunCommand(IEnumerable<string> arguments)
        {
            var algorithmQuery = arguments.FirstOrDefault();
			if (algorithmQuery == null)
			{
				Console.WriteLine($"Specify an algorithm name to list the details for. Command format: \"algorithm detail <algorithm-name || algorithm-id>\".");
				return;
			}

			var algorithmMetadata = GetAlgorithmMetadataFromQuery(algorithmQuery);

			if (algorithmMetadata == null)
			{
				NoAlgorithmFound(algorithmQuery);
				return;
			}

			var algorithm = AlgorithmFactory.CreateAlgorithm(algorithmMetadata);
            algorithm.Run(arguments.Skip(1).ToArray());
		}


		private static void ShowAlgorithmHelp()
        {
            Console.WriteLine("Try commands like:");
            ConsoleHelper.WriteHelpText("algorithm list", "Lists all available algorithms.");
			ConsoleHelper.WriteHelpText("algorithm detail <algorithm-name || algorithm-id>", "Shows the detailed metadata of an algorithm specified by name or id.");
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

        private static void ShowDetailedAlgorithmInformation(IEnumerable<string> arguments)
        {
            var algorithmQuery = arguments.FirstOrDefault();
            if (algorithmQuery == null)
            {
                Console.WriteLine($"Specify an algorithm name to list the details for. Command format: \"algorithm detail <algorithm-name || algorithm-id>\".");
                return;
            }

            var algorithmMetadata = GetAlgorithmMetadataFromQuery(algorithmQuery);

            if (algorithmMetadata == null)
            {
                NoAlgorithmFound(algorithmQuery);
                return;
            }

            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Name: {algorithmMetadata.Name}, Id={algorithmMetadata.Id}");
            Console.WriteLine($"CLI Name: {algorithmMetadata.CLIName}");
            ConsoleHelper.PrintEmptyLine();
            Console.WriteLine($"Description: {algorithmMetadata.Description}");
			ConsoleHelper.PrintEmptyLine();
			Console.WriteLine($"Time Complexity: {algorithmMetadata.TimeComplexity}");
        }

        private static AlgorithmMetadata? GetAlgorithmMetadataFromQuery(string query)
        {
            return _algorithmsMetadata.SingleOrDefault(meta =>
                meta.CLIName.ToLower() == query.ToLower() || meta.Id.ToString() == query);
        }

        private static void ShowAllAlgorithms()
        {
            _algorithmsMetadata.ForEach(algorithm =>
            {
                Console.WriteLine($"-  {algorithm.CLIName}, Id={algorithm.Id}");
            });
        }

        private static void NoAlgorithmFound(string algorithmQuery)
        {
            Console.WriteLine("No algorithm called " + algorithmQuery);
            Console.WriteLine("Available algorithms:");
            ShowAllAlgorithms();
        }

    }
}
