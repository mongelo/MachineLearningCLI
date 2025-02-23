namespace MachineLearningCLI.Helpers;

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

    public static void ShowHelpTooltip(string commandName = "")
    {
        if (commandName == string.Empty)
            Console.WriteLine("Type 'help' for a list of commands.");
        else
            Console.WriteLine($"Type '{commandName} help' for a list of commands.");
    }

    public static void ShowExampleCommands()
    {
        Console.WriteLine("Try commands like:\ndataset\nalgorithm\nprocessor\nwiki\nstats");
    }

    public static void PrintEmptyLine()
    {
        Console.WriteLine("");
    }

    public static string GetUserInput()
    {
        Console.Write("> ");
        return Console.ReadLine() ?? "";
    }

    public static void WriteHelpText(string command, string details)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(command);
        Console.ResetColor();
        Console.WriteLine(" - " + details);
    }

    public static void WritePartlyGreenText(string greenText, string whiteText)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(greenText);
        Console.ResetColor();
        Console.WriteLine(whiteText);
    }


}
