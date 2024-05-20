using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using System.IO;
using System.Text.Json;


namespace MachineLearningCLI.Repositories
{
    public static class DatasetRepository
    {
        private const string _datasetFolderName = "Datasets";

        public static List<DatasetMetadata> LoadAllDatasetMetadata()
        {
            var DatasetsMetadata = new List<DatasetMetadata>();
            
            var datasetDirectories = Directory.GetDirectories(DatasetDirectoryPath());

            foreach (var directory in datasetDirectories)
            {
                var jsonData = FileHelper.ReadRawTextFromFile(directory + "\\datasetMetadata.json");
                var dataset = JsonSerializer.Deserialize<DatasetMetadata>(jsonData);
                if (dataset != null) DatasetsMetadata.Add(dataset);
            }

            return DatasetsMetadata;
        }

        public static string GetDatsetRawText(DatasetMetadata datasetMetadata) 
        {
            return FileHelper.ReadRawTextFromFile(DatasetDirectoryPath()+"\\"+datasetMetadata.Name + "\\data"+datasetMetadata.FileFormat);
        }

        public static string DatasetDirectoryPath()
        {
            var projectFolder = FileHelper.GetProjectFolder();
            return Path.Combine(projectFolder, _datasetFolderName);
        }
    }
}
