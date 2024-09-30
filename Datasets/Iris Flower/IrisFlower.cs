using System.Globalization;

namespace MachineLearningCLI.Datasets.Iris_Flower;

public class IrisFlower : DataPoint
{
    public double SepalLengt;
    public double SepalWidth;
    public double PetalLength;
    public double PetalWidth;
    public string Species = String.Empty;

    public override void InitializeDataPoint(string values)
    {
        var splitData = values.Split(',');
        SepalLengt = double.Parse(splitData[0], CultureInfo.InvariantCulture);
        SepalWidth = double.Parse(splitData[1], CultureInfo.InvariantCulture);
        PetalLength = double.Parse(splitData[2], CultureInfo.InvariantCulture);
        PetalWidth = double.Parse(splitData[3], CultureInfo.InvariantCulture);
        Species = splitData[4];
    }

    public override double[] GetDataAsDoubleArray()
    {
        return [SepalLengt, SepalWidth, PetalLength, PetalWidth];
    }

    public override void Print()
    {
        Console.WriteLine($"{SepalLengt:f2},          {SepalWidth:f2},         {PetalLength:f2},          {PetalWidth:f2},         {Species}");
    }

    public override int GetClass()
    {
        switch (Species)
        {
            case "Iris-setosa":
                return 0;
            case "Iris-versicolor":
                return 1;
            case "Iris-virginica":
                return 2;
            default:
                throw new Exception($"Unknown IrisFlower class {Species}.");
        }
    }

    public override string GetClassName(int classNumber)
    {
        switch (classNumber)
        {
            case 0:
                return "Iris-setosa";
            case 1:
                return "Iris-versicolor";
            case 2:
                return "Iris-virginica";
            default:
                throw new Exception($"Unknown IrisFlower class {classNumber}.");
        }
    }

}
