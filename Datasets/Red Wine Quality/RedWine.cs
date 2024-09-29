using System.Globalization;

namespace MachineLearningCLI.Datasets.Red_Wine_Quality;

public class RedWine : IData
{
    public double FixedAcidity;
    public double VolatileAcidity;
    public double CitricAcid;
    public double ResidualSugar;
    public double Chlorides;
    public double FreeSulfurDioxide;
    public double TotalSulfurDioxide;
    public double Density;
    public double PH;
    public double Sulphates;
    public double Alcohol;
    public int Quality;

    public void InitializeDataPoint(string values)
    {
        var splitData = values.Split(',');
        FixedAcidity = double.Parse(splitData[0], CultureInfo.InvariantCulture);
        VolatileAcidity = double.Parse(splitData[1], CultureInfo.InvariantCulture);
        CitricAcid = double.Parse(splitData[2], CultureInfo.InvariantCulture);
        ResidualSugar = double.Parse(splitData[3], CultureInfo.InvariantCulture);
        Chlorides = double.Parse(splitData[4], CultureInfo.InvariantCulture);
        FreeSulfurDioxide = double.Parse(splitData[5], CultureInfo.InvariantCulture);
        TotalSulfurDioxide = double.Parse(splitData[6], CultureInfo.InvariantCulture);
        Density = double.Parse(splitData[7], CultureInfo.InvariantCulture);
        PH = double.Parse(splitData[8], CultureInfo.InvariantCulture);
        Sulphates = double.Parse(splitData[9], CultureInfo.InvariantCulture);
        Alcohol = double.Parse(splitData[10], CultureInfo.InvariantCulture);
        Quality = int.Parse(splitData[11], CultureInfo.InvariantCulture);
    }

    public double[] GetDataAsDoubleArray()
    {
        return [FixedAcidity, VolatileAcidity, CitricAcid, ResidualSugar, Chlorides, FreeSulfurDioxide, TotalSulfurDioxide, Density, PH, Sulphates, Alcohol];
    }

    public void PrintDataPoint()
    {
        Console.WriteLine($"{FixedAcidity:f2}, {VolatileAcidity:f2}, {CitricAcid:f2}, {ResidualSugar:f2}, {Chlorides:f2}, {FreeSulfurDioxide:f2}, {TotalSulfurDioxide:f2}, {Density:f2}, {PH:f2}, {Sulphates:f2}, {Alcohol:f2}");
    }

    public int GetClass()
    {
        return Quality;
    }

    public string GetClassName(int classNumber)
    {
        return classNumber.ToString();
    }

}
