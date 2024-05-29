namespace MachineLearningCLI.Datasets
{
    public interface IDataPoint
    {
        void InitializeDataPoint(string values);
        void PrintDataPoint();
    }

	public class DataPoint<T>  where T : IDataPoint, new()
    {
        public T Data;

        public DataPoint(string values)
        {
            Data = new T();
            Data.InitializeDataPoint(values);
        }

		public void Print()
        {
            Data.PrintDataPoint();
        }

    }
}
