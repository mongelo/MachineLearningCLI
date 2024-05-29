using System.Globalization;

namespace MachineLearningCLI.Datasets.Iris_Flower
{
    public class IrisFlower : IData
    {
        public double SepalLengt;
        public double SepalWidth;
        public double PetalLength;
        public double PetalWidth;
        public string Species = String.Empty;

        public void InitializeDataPoint(string values)
        {
            var splitData = values.Split(',');
            SepalLengt = double.Parse(splitData[0], CultureInfo.InvariantCulture);
            SepalWidth = double.Parse(splitData[1], CultureInfo.InvariantCulture);
            PetalLength = double.Parse(splitData[2], CultureInfo.InvariantCulture);
            PetalWidth = double.Parse(splitData[3], CultureInfo.InvariantCulture);
            Species = splitData[4];
        }

        public double[] GetDataAsDoubleArray()
        { 
            return [ SepalLengt, SepalWidth, PetalLength, PetalWidth ];
		}


		public void PrintDataPoint()
        {    
            Console.WriteLine($"{SepalLengt:f2},          {SepalWidth:f2},         {PetalLength:f2},          {PetalWidth:f2},         {Species}");
        }
    }
}
