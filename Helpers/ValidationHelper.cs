namespace MachineLearningCLI.Helpers;
public static class ValidationHelper
{
    public static void ShowValidationMessage(string message)
    {
        Console.WriteLine($"Input validation error:\n\t{message}");
    }
}
