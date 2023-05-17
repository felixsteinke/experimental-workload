namespace sorting_library_csharp;

public abstract class SortingProcessor
{
    /// <summary>
    /// O(n*log(n)) sorting algorithm
    /// </summary>
    /// <param name="numbers"> as mutable array to be sorted</param>
    public static void SortInON1(List<int> numbers)
    {
        // Sort the input list using O(n*log(n)) algorithm
        numbers.Sort();
    }

    /// <summary>
    /// O(n^2) sorting algorithm
    /// </summary>
    /// <param name="numbers"> as mutable array to be sorted</param>
    public static void SortInON2(List<int> numbers)
    {
        // Sort the input list using O(n^2) algorithm
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] < numbers[i])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
    }

    /// <summary>
    /// O(n^3) sorting algorithm
    /// </summary>
    /// <param name="numbers"> as mutable array to be sorted</param>
    public static void SortInON3(List<int> numbers)
    {
        // Sort the input list using O(n^3) algorithm
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                for (int k = j + 1; k < numbers.Count; k++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                    if (numbers[j] > numbers[k])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[k];
                        numbers[k] = temp;
                    }
                }
            }
        }
    }
}