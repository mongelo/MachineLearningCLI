﻿namespace MachineLearningCLI.Helpers;

public static class ArrayHelper
{
    public static void ShuffleArray<T>(T[] array)
    {
        Random rng = new ();
        int n = array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (array[j], array[i]) = (array[i], array[j]);
        }
    }

    public static void InsertIntoArrayAndPushOtherValuesDown<T>(T[] array, T value, int position)
    {
		for (int i = array.Length - 1; i > position; i--)
		{
			array[i] = array[i - 1];
		}

		array[position] = value;
	}

}
