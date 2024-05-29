namespace MachineLearningCLI.Datasets
{
    public interface IData
    {
        void InitializeDataPoint(string values);
        void PrintDataPoint();
		double[] GetDataAsDoubleArray();
	}

	public interface IDataPoint
	{
        double[] GetDataAsDoubleArray();
	}

	public class DataPoint<T> : IDataPoint where T : IData, new()
    {
        public T Data;

        public DataPoint(string values)
        {
            Data = new T();
            Data.InitializeDataPoint(values);
        }

		public double[] GetDataAsDoubleArray()
		{
            return Data.GetDataAsDoubleArray();
		}

		public void Print()
        {
            Data.PrintDataPoint();
        }
	}
}
