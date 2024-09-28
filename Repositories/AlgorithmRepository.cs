using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using System.Text.Json;


namespace MachineLearningCLI.Repositories;

public static class AlgorithmRepository
{
    private const string _algorithmFolderName = "Algorithms";

    public static List<AlgorithmMetadata> LoadAllAlgorithmMetadata()
    {
        var AlgorithmsMetadata = new List<AlgorithmMetadata>();

        var algorithmDirectories = Directory.GetDirectories(AlgorithmDirectoryPath());

        foreach (var directory in algorithmDirectories)
        {
            var jsonData = FileHelper.ReadRawTextFromFile(directory + "\\algorithmMetadata.json");
            var algorithm = JsonSerializer.Deserialize<AlgorithmMetadata>(jsonData);
            if (algorithm != null) AlgorithmsMetadata.Add(algorithm);
        }

        return AlgorithmsMetadata;
    }

    public static string AlgorithmDirectoryPath()
    {
        var projectFolder = FileHelper.GetProjectFolder();
        return Path.Combine(projectFolder, _algorithmFolderName);
    }
}
