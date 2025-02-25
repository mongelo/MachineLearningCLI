using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.Statistics;

public static class Statistics
{
    private static int _numberOfModelsTrained;

    public static int GetNumberOfModelsTrained() => _numberOfModelsTrained;

    public static void IncreaseNumberOfModelsTrained()
    { 
        _numberOfModelsTrained++;
    }

    public static void PrintAllStatistics()
    {
        ConsoleHelper.WritePartlyGreenText("Models trained: ",GetNumberOfModelsTrained().ToString());
    }

}
