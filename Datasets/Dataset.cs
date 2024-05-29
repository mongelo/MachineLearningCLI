using MachineLearningCLI.Entities;
using MachineLearningCLI.Helpers;
using MachineLearningCLI.Repositories;

namespace MachineLearningCLI.Datasets
{
    public interface IDataset
	{
        public void PrintRawDataset();
        public void PrintDatasetFormatted();
		IDataPoint[] GetDataPoints();
		double[][] GetDataPointsAsDoubleArray();
	}

    public class Dataset<T> : IDataset where T : IData, new()
    {
		protected string DatasetRawData { get; set; } = String.Empty;
		public DatasetMetadata DatasetMetadata { get; set; }
        public DataPoint<T>[] _dataPoints;

        private string[] _columnNames { get; set; }

        public Dataset(DatasetMetadata datasetMetadata) 
		{
            DatasetMetadata = datasetMetadata;
            _dataPoints = new DataPoint<T>[DatasetMetadata.Size];
            _columnNames = new string[DatasetMetadata.Size];
            Load();
		}

		public void Load()
		{
			DatasetRawData = DatasetRepository.GetDatsetRawText(DatasetMetadata);

            var allRawRows = DatasetRawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            _columnNames = allRawRows[0].Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var allRawRowsList = allRawRows.Skip(1);

            var i = 0;
            foreach (var row in allRawRowsList)
            {
                _dataPoints[i] = new DataPoint<T>(row.Replace("\r", ""));
                i++;
            }
        }

        public void PrintRawDataset()
        {
            Console.WriteLine(DatasetRawData);
        }

        public void PrintDatasetFormatted()
        {
            foreach (var column in _columnNames)
            {
                Console.Write(column + "   ");
            }
            ConsoleHelper.PrintEmptyLine();

            var i = 0;
            while (i < DatasetMetadata.Size)
            {
                _dataPoints[i].Print();
                i++;
            }
        }

		public IDataPoint[] GetDataPoints()
		{
			return _dataPoints.Cast<IDataPoint>().ToArray();
		}

		public double[][] GetDataPointsAsDoubleArray()
		{
			return _dataPoints.Select(x => x.GetDataAsDoubleArray()).ToArray();
		}

	}
}
