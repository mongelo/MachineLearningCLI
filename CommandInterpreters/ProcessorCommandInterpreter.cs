using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.CommandInterpreters;

public static class ProcessorCommandInterpreter
{
    private const string _commandName = "processor";

    public static void Interpret(Command command)
    {
        switch (command.SubCommandName)
        {
            case "":
                ConsoleHelper.ShowHelpTooltip(_commandName);
                break;
            case "help":
            case "h":
                ShowProcessorHelp();
                break;
            case "list":
            case "l":
                HandleProcessorListCommand(command.Arguments);
                break;

            default:
                ConsoleHelper.HandleUnknownCommand();
                break;
        }
    }

    private static void ShowProcessorHelp()
    {
        Console.WriteLine("Processors modify datasets before usage in an algorithm.\nThey are used with the \"p\"-parameter in the \"run algorithm\"-command.");
		ShowExampleUsage();
        ConsoleHelper.PrintEmptyLine();
        Console.WriteLine("Try commands like:");
        ConsoleHelper.WriteHelpText("processor list", "Lists all data processors.");
	}

    private static void HandleProcessorListCommand(IEnumerable<string> arguments)
    {
        ConsoleHelper.WriteHelpText("0 - None", "No processing of data. Use by writing nothing.");
        ConsoleHelper.WriteHelpText("1 - Normalize", "Normalizes all data points to be between 0 and 1. Usage: write p=1 in the \"run algorithm\"-command.");
		ConsoleHelper.PrintEmptyLine();
		ShowExampleUsage();

	}

    private static void ShowExampleUsage()
    {
        Console.WriteLine("Example usage: a r 0 d=0 p=1 k=3");
    }
}
