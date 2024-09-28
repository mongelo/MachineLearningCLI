using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.CommandInterpreters;

public static class CommandInterpreter
{
    public static void Interpret(Command command)
    {
        switch (command.CommandName)
        {
            case "":
                break;
            case "dataset":
            case "d":
                DatasetCommandInterpreter.Interpret(command);
                break;
            case "algorithm":
            case "a":
                AlgorithmCommandInterpreter.Interpret(command);
                break;
            case "help":
            case "h":
                ShowGenericHelp();
                break;
            case "exit":
                Console.WriteLine("Exiting CLI. Goodbye!");
                return;
            default:
                ConsoleHelper.HandleUnknownCommand();
                break;
        }
    }

    private static void ShowGenericHelp()
    {
        Console.WriteLine("Try commands like:");
        ConsoleHelper.WriteHelpText("dataset help", "Shows more detailed dataset commands.");
        ConsoleHelper.WriteHelpText("algorithm help", "Shows more detailed algorithm commands.");
        ConsoleHelper.WriteHelpText("wiki help", "Shows more detailed wiki commands.");
        ConsoleHelper.WriteHelpText("stats help", "Shows more detailed stats commands.");
    }

}
