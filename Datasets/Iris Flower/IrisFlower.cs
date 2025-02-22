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
        return Species switch
        {
            "Iris-setosa" => 0,
            "Iris-versicolor" => 1,
            "Iris-virginica" => 2,
            _ => throw new Exception($"Unknown IrisFlower class {Species}."),
        };
    }

    public override string GetClassName(int classNumber)
    {
        return classNumber switch
        {
            0 => "Iris-setosa",
            1 => "Iris-versicolor",
            2 => "Iris-virginica",
            _ => throw new Exception($"Unknown IrisFlower class {classNumber}."),
        };
    }

}
