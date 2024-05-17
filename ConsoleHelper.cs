namespace MachineLearningCLI
{
    public static class ConsoleHelper
    {
        public static void PrintWelcomeHeader()
        {
            //https://patorjk.com/software/taag/
            Console.WriteLine(@"
              __  __            _     _              _                           _                _____ _      _____ 
             |  \/  |          | |   (_)            | |                         (_)              / ____| |    |_   _|
             | \  / | __ _  ___| |__  _ _ __   ___  | |     ___  __ _ _ __ _ __  _ _ __   __ _  | |    | |      | |  
             | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \ | |    / _ \/ _` | '__| '_ \| | '_ \ / _` | | |    | |      | |  
             | |  | | (_| | (__| | | | | | | |  __/ | |___|  __/ (_| | |  | | | | | | | | (_| | | |____| |____ _| |_ 
             |_|  |_|\__,_|\___|_| |_|_|_| |_|\___| |______\___|\__,_|_|  |_| |_|_|_| |_|\__, |  \_____|______|_____|
                                                                                          __/ |                      
                                                                                         |___/                       
            ");
        }

        public static void HandleUnknownCommand() 
        {
            Console.WriteLine("Unknown command.");
            ShowHelpTooltip();
        }

        public static void ShowHelpTooltip() 
        {
            Console.WriteLine("Type 'help' for a list of commands.");
        }

        public static void ShowExampleCommands()
        {
            Console.WriteLine("Try commands like:\ndataset\nalgorithm\nwiki\nstats");
        }

        public static void PrintEmptyLine() 
        {
            Console.WriteLine("\n");
        }

        public static string GetUserInput() 
        {
            Console.Write("> ");
            return Console.ReadLine() ?? "";
        }
    }
}
