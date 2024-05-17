using MachineLearningCLI.Entities;

namespace MachineLearningCLI.CommandInterpreters
{
    public static class DatasetCommandInterpreter
    {
        public static void Interpret(Command command)
        {
            switch (command.SubCommandName)
            {
                case "":
                    ShowDatasetHelp(command.CommandName);
                    break;
                case "--list":
                    HandleDatasetListCommand(command.Arguments);
                    break;
                case "--help":
                    ShowDatasetHelp(command.CommandName);
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

        private static void ShowDatasetHelp(string commandName)
        {
            //TODO: Show more specific helps
            ConsoleHelper.ShowHelpTooltip(commandName);
        }

        private static void HandleDatasetListCommand(IEnumerable<string> arguments)
        {
            Console.WriteLine("Handling 'dataset-list' command");
        }
        
    }
}
