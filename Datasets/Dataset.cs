using MachineLearningCLI.Entities;
using MachineLearningCLI.Repositories;
using System.Data.Common;

namespace MachineLearningCLI.Datasets
{
	public class Dataset<T> where T : IDataPoint, new()
	{
		protected string DatasetRawData { get; set; } = String.Empty;
		public DatasetMetadata DatasetMetadata { get; set; }
		private string[] _columnNames { get; set; }
        private DataPoint<T>[] _dataPoints;

        public Dataset(DatasetMetadata datasetMetadata) 
		{
            DatasetMetadata = datasetMetadata;
            _dataPoints = new DataPoint<T>[DatasetMetadata.Size];
            Load();
		}

		public void Load()
		{
			DatasetRawData = DatasetRepository.GetDatsetRawText(DatasetMetadata);
        }

        public void PrintRawDataset()
		{
			Console.WriteLine(DatasetRawData);
		}

		public void PrintDatasetFormatted()
        {
            //BOTH INIT AND PRINT, SPLIT THIS UP

            _dataPoints = new DataPoint<T>[DatasetMetadata.Size];
            var allRawRows = DatasetRawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            _columnNames = allRawRows[0].Replace("\r","").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var allRawRowsList = allRawRows.Skip(1);

            foreach (var column in _columnNames)
            {
                Console.Write(column+"   ");
            }
            ConsoleHelper.PrintEmptyLine();

            var i = 0;
            foreach (var row in allRawRowsList)
            {
				_dataPoints[i] = new DataPoint<T>(row.Replace("\r", ""));
                _dataPoints[i].Print();
                i++;
            }



        }

    }
}
