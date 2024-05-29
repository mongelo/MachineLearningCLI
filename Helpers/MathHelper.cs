namespace MachineLearningCLI.Helpers
{
	public static class MathHelper
	{
		const double Tolerance = 1e-4;

		public static double EuclideanDistance(double[] point1, double[] point2)
		{
			double sum = 0.0;
			for (int i = 0; i < point1.Length; i++)
			{
				sum += Math.Pow(point1[i] - point2[i], 2);
			}
			return Math.Sqrt(sum);
		}

		public static bool AreEqual(double[][] array1, double[][] array2, double tolerance = Tolerance)
		{
			if (array1.Length != array2.Length) return false;

			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i].Length != array2[i].Length) return false;

				for (int j = 0; j < array1[i].Length; j++)
				{
					if (Math.Abs(array1[i][j] - array2[i][j]) > tolerance)
					{
						return false;
					}
				}
			}
			return true;
		}

	}
}
