namespace MachineLearningCLI.Helpers;

public static class ArrayHelper
{
    public static void ShuffleArray<T>(T[] array)
    {
        Random rng = new Random();
        int n = array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

}
