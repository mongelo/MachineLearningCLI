using MachineLearningCLI.Algorithms;
using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.CommandInterpreters;

public static class AlgorithmCommandInterpreter
{
    private const string _commandName = "algorithm";
    private static List<AlgorithmMetadata> _algorithmsMetadata = [];

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
                ShowAlgorithmHelp(command.Arguments);
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


    private static void ShowAlgorithmHelp(IEnumerable<string> arguments)
    {
        var algorithmQuery = arguments.FirstOrDefault();
        if (algorithmQuery == null)
        {
            ShowGenericAlgorithmHelp();
            return;
        }

        var algorithmMetadata = GetAlgorithmMetadataFromQuery(algorithmQuery);

        if (algorithmMetadata == null)
        {
            ShowGenericAlgorithmHelp();
            return;
        }

        ConsoleHelper.WriteHelpText(algorithmMetadata.CommandSyntax, "Runs the algorithm.");
    }

    private static void ShowGenericAlgorithmHelp()
    {
        Console.WriteLine("Try commands like:");
        ConsoleHelper.WriteHelpText("algorithm help <algorithm-name || algorithm-id>", "Shows how to run a specific algorithm.");
        ConsoleHelper.WriteHelpText("algorithm list", "Lists all available algorithms.");
        ConsoleHelper.WriteHelpText("algorithm detail <algorithm-name || algorithm-id>", "Shows the detailed metadata of an algorithm specified by name or id.");
        ConsoleHelper.WriteHelpText("algorithm run <algorithm-name || algorithm-id> d=<dataset-name || dataset-id> <algorithm-specific-parameters>", "Trains and evaluates an algorithm.");
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
        ConsoleHelper.WritePartlyGreenText("Name: ", $"{algorithmMetadata.Name}, Id={algorithmMetadata.Id}");
        ConsoleHelper.WritePartlyGreenText("CLI Name: ", $"{algorithmMetadata.CLIName}");
        ConsoleHelper.WritePartlyGreenText("Command Syntax: ", $"{algorithmMetadata.CommandSyntax}");
        ConsoleHelper.WritePartlyGreenText("Command Example: ", $"{algorithmMetadata.ExampleCommand}");
        ConsoleHelper.WritePartlyGreenText("Default Parameters: ", $"{algorithmMetadata.DefaultParameters}");
        ConsoleHelper.WritePartlyGreenText("Training Time Complexity: ", $"{algorithmMetadata.TrainingTimeComplexity}");
        ConsoleHelper.WritePartlyGreenText("Prediction Time Complexity: ", $"{algorithmMetadata.PredictionTimeComplexity}");
        ConsoleHelper.WritePartlyGreenText("Alogithm Type: ", $"{algorithmMetadata.AlgorithmType}");
        ConsoleHelper.WritePartlyGreenText("Description: ", $"{algorithmMetadata.Description}");
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
