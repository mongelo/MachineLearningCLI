using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using static MachineLearningCLI.Statistics.Statistics;

namespace MachineLearningCLI.CommandInterpreters;

public static class StatsCommandInterpreter
{
    private const string _commandName = "statistics";

    public static void Interpret(Command command)
    {
        switch (command.SubCommandName)
        {
            case "":
                ConsoleHelper.ShowHelpTooltip(_commandName);
                break;
            case "help":
            case "h":
                ShowStatisticsHelp();
                break;
            case "list":
            case "l":
                HandleStatisticsListCommand(command.Arguments);
                break;

            default:
                ConsoleHelper.HandleUnknownCommand();
                break;
        }
    }

    private static void ShowStatisticsHelp()
    {
        Console.WriteLine("Statistics are kept as you use the CLI.");
        ConsoleHelper.PrintEmptyLine();
        Console.WriteLine("Try commands like:");
        ConsoleHelper.WriteHelpText("statistics list", "Lists all statistics.");
	}

    private static void HandleStatisticsListCommand(IEnumerable<string> arguments)
    {
        PrintAllStatistics();
    }

}
