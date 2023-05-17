# Libraries for Workloads

## Libraries Structure

```
libraries
 |__ sorting-library-csharp/      --> C# project for sorting
 |__ sorting-library-csharp-test/ --> C# test project for the sorting library
 |__ sorting-library-java/        --> Java module for sorting with included tests
```

## Sorting Library

Implementation of a `SortingProcessor` in a [C# project](sorting-library-csharp/SortingProcessor.cs)
and a [Java project](sorting-library-java/src/main/java/org/experimental/library/SortingProcessor.java).

The tests have a separated [C# test project](sorting-library-csharp-test/SortingProcessorTest.cs), while they are
included within
the [Java test directory](sorting-library-java/src/test/java/org/experimental/library/SortingProcessorTest.java).
