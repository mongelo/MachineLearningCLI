using MachineLearningCLI.CommandInterpreters;

namespace MachineLearningCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeApplication();

            while (true)
            {
                var currentInput = ConsoleHelper.GetUserInput();
                var command = CommandHelper.ProcessCommand(currentInput);
                CommandInterpreter.Interpret(command);
                if(currentInput != String.Empty)ConsoleHelper.PrintEmptyLine();
            }
        }

        static void InitializeApplication()
        {
            ConsoleHelper.PrintWelcomeHeader();
            Console.WriteLine("Welcome to Machine Learning CLI - Version 1.0.0");
            ConsoleHelper.PrintEmptyLine();
            ConsoleHelper.ShowExampleCommands();
            ConsoleHelper.PrintEmptyLine();
            ConsoleHelper.ShowHelpTooltip();
        }

    }
}
