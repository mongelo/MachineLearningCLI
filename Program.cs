using MachineLearningCLI.CommandInterpreters;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI;

class Program
{
    static void Main()
    {
        InitializeApplication();

        while (true)
        {
            var currentInput = ConsoleHelper.GetUserInput();
            var command = CommandHelper.ProcessCommand(currentInput);
            CommandInterpreter.Interpret(command);
            if (currentInput != String.Empty) ConsoleHelper.PrintEmptyLine();
        }
    }

    static void InitializeApplication()
    {
        ConsoleHelper.PrintWelcomeHeader();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to Machine Learning CLI - Version 1.0.0");
        Console.ResetColor();
        ConsoleHelper.PrintEmptyLine();
        ConsoleHelper.ShowExampleCommands();
        ConsoleHelper.PrintEmptyLine();
        ConsoleHelper.ShowHelpTooltip();
    }

}
