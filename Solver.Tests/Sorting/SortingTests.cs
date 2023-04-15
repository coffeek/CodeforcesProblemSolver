using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Solver.Tests.Sorting;

[TestFixture]
public class SortingTests
{
  [Test]
  public void QuickSortTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Solver.Sorting.Sorting.QuickSort);
    TestSort(new int[] { }, Solver.Sorting.Sorting.QuickSort);
    TestSort(new[] { 1 }, Solver.Sorting.Sorting.QuickSort);
    TestSort(new[] { -1, -99 }, Solver.Sorting.Sorting.QuickSort);
    TestSort(new[] { 1, 5, -10 }, Solver.Sorting.Sorting.QuickSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Solver.Sorting.Sorting.QuickSort);
  }
    
  [Test]
  public void QuickSortLomutoTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Solver.Sorting.Sorting.QuickSortLomuto);
    TestSort(new int[] { }, Solver.Sorting.Sorting.QuickSortLomuto);
    TestSort(new[] { 1 }, Solver.Sorting.Sorting.QuickSortLomuto);
    TestSort(new[] { -1, -99 }, Solver.Sorting.Sorting.QuickSortLomuto);
    TestSort(new[] { 1, 5, -10 }, Solver.Sorting.Sorting.QuickSortLomuto);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Solver.Sorting.Sorting.QuickSortLomuto);
  }
    
  [Test]
  public void HeapSortTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Solver.Sorting.Sorting.HeapSort);
    TestSort(new int[] { }, Solver.Sorting.Sorting.HeapSort);
    TestSort(new[] { 1 }, Solver.Sorting.Sorting.HeapSort);
    TestSort(new[] { -1, -99 }, Solver.Sorting.Sorting.HeapSort);
    TestSort(new[] { 1, 5, -10 }, Solver.Sorting.Sorting.HeapSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Solver.Sorting.Sorting.HeapSort);
  }
    
  [Test]
  public void HeapSortGenericTest()
  {
    void HeapSort(int[] a) => Solver.Sorting.Sorting.HeapSort(a, Comparer<int>.Default.Compare);
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, HeapSort);
    TestSort(new int[] { }, HeapSort);
    TestSort(new[] { 1 }, HeapSort);
    TestSort(new[] { -1, -99 }, HeapSort);
    TestSort(new[] { 1, 5, -10 }, HeapSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, HeapSort);
  }
    
  private static void TestSort(int[] a, Action<int[]> sort)
  {
    var expected = a.OrderBy(x => x).ToArray();
    sort(a);
    a.Should().BeEquivalentTo(expected);
  }
}
