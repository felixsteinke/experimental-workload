using sorting_library_csharp;

namespace sorting_library_csharp_test;

public class SortingProcessorTest
{
    private List<int> sampleArray;

    private static bool IsSorted(List<int> array)
    {
        for (int i = 0; i < array.Count - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public SortingProcessorTest()
    {
        sampleArray = new List<int> { 5, 3, 4, 1, 2 };
    }

    [Fact]
    public void SortInON1()
    {
        // Act
        SortingProcessor.SortInON1(sampleArray);
        // Assert
        Assert.True(IsSorted(sampleArray), "sample array is sorted");
    }

    [Fact]
    public void SortInON2()
    {
        // Act
        SortingProcessor.SortInON2(sampleArray);
        // Assert
        Assert.True(IsSorted(sampleArray), "sample array is sorted");
    }

    [Fact]
    public void SortInON3()
    {
        // Act
        SortingProcessor.SortInON3(sampleArray);
        // Assert
        Assert.True(IsSorted(sampleArray), "sample array is sorted");
    }
}