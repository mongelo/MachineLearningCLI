using MachineLearningCLI.Entities;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class DatasetCommandInterpreter
    {
        public static void Interpret(Command command)
        {
            switch (command.CommandText)
            {
                case "dataset":
                    HandleDatasetCommand(command.Arguments);
                    break;
                case "dataset-list":
                    HandleDatasetListCommand();
                    break;
                default:
                    ConsoleHelper.HandleUnknownCommand();
                    break;
            }
        }

        private static void HandleDatasetCommand(IEnumerable<string> arguments)
        {
            Console.WriteLine("Handling 'dataset' command with arguments:");
            foreach (string arg in arguments)
            {
                Console.WriteLine(arg);
            }
        }

        private static void HandleDatasetListCommand()
        {
            Console.WriteLine("Handling 'dataset-list' command");
        }
    }
}
