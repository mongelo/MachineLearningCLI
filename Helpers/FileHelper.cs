namespace MachineLearningCLI.Helpers;

public static class FileHelper
{
    public static string GetProjectFolder()
    {
        return TrimPathAtBin(AppDomain.CurrentDomain.BaseDirectory);
    }

    private static string TrimPathAtBin(string path)
    {
        int indexOfBin = path.IndexOf("bin", StringComparison.OrdinalIgnoreCase);

        if (indexOfBin != -1)
        {
            return path.Substring(0, indexOfBin);
        }
        else
        {
            return path;
        }
    }

    public static string ReadRawTextFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found", filePath);
        }
        return File.ReadAllText(filePath);
    }

}
