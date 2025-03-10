﻿using MachineLearningCLI.Datasets;
using MachineLearningCLI.Helpers;

namespace MachineLearningCLI.Algorithms.KMeans;

public static class KMeansHelper
{
    public static double[][] InitializeKMeansCentroidsToBeRandomDataPoints(IDataset dataset, int k)
    {
        Random random = new();

        return dataset.GetDataPointsAsDoubleArray()
            .OrderBy(x => random.Next())
            .Take(k)
            .ToArray();
    }

    public static Centroid CentroidClosestToPoint(List<Centroid> centroids, DataPoint dataPoint) 
    {
        var currentClosestDistance = double.MaxValue;
        Centroid currentClosestCentroid = centroids.First();
        foreach (var centroid in centroids)
        {
            var distance = MathHelper.EuclideanDistance(dataPoint.GetDataAsDoubleArray(), centroid.Coordinate);
            if (distance < currentClosestDistance)
            { 
                currentClosestDistance = distance;
                currentClosestCentroid = centroid;
            }
        }
        return currentClosestCentroid;
    }
}

public class Centroid()
{
    public int Classification { get; set; }
    public double[] Coordinate { get; set; } = [];
}