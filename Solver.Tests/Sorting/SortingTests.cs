using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Solver.Tests.Sorting;

[TestFixture]
public class SortingTests
{
  private static readonly object[] TestArrays =
  {
    new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 },
    Array.Empty<int>(),
    new[] { 1 },
    new[] { -1, -99 },
    new[] { 1, 5, -10 },
    new[] { 6, 5, 4, 1, 2, 3 }
  };
  
  [TestCaseSource(nameof(TestArrays))]
  public void QuickSortTest(int[] array)
  {
    TestSort(array, Solver.Sorting.Sorting.QuickSort);
  }
    
  [TestCaseSource(nameof(TestArrays))]
  public void QuickSortLomutoTest(int[] array)
  {
    TestSort(array, Solver.Sorting.Sorting.QuickSortLomuto);
  }
    
  [TestCaseSource(nameof(TestArrays))]
  public void HeapSortTest(int[] array)
  {
    TestSort(array, Solver.Sorting.Sorting.HeapSort);
  }
    
  [TestCaseSource(nameof(TestArrays))]
  public void HeapSortGenericTest(int[] array)
  {
    TestSort(array, a => Solver.Sorting.Sorting.HeapSort(a, Comparer<int>.Default.Compare));
  }
    
  private static void TestSort(int[] a, Action<int[]> sort)
  {
    var expected = a.OrderBy(x => x).ToArray();
    sort(a);
    a.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
