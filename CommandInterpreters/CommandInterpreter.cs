using MachineLearningCLI.Entities;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class CommandInterpreter
    {
        public static void Interpret(Command command)
        {
            switch (command.CommandName)
            {
                case "":
                    break;
                case "dataset":
                    DatasetCommandInterpreter.Interpret(command);
                    break;
                case "exit":
                    Console.WriteLine("Exiting CLI. Goodbye!");
                    return;
                default:
                    ConsoleHelper.HandleUnknownCommand();
                    break;
            }
        }
    }
}
