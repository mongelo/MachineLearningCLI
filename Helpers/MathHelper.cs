namespace MachineLearningCLI.Helpers
{
	public static class MathHelper
	{

		public static double EuclideanDistance(double[] point1, double[] point2)
		{
			double sum = 0.0;
			for (int i = 0; i < point1.Length; i++)
			{
				sum += Math.Pow(point1[i] - point2[i], 2);
			}
			return Math.Sqrt(sum);
		}

	}
}
