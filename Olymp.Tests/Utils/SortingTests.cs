using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils;

[TestFixture]
public class SortingTests
{
  [Test]
  public void QuickSortTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSort);
    TestSort(new int[] { }, Sorting.QuickSort);
    TestSort(new[] { 1 }, Sorting.QuickSort);
    TestSort(new[] { -1, -99 }, Sorting.QuickSort);
    TestSort(new[] { 1, 5, -10 }, Sorting.QuickSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSort);
  }
    
  [Test]
  public void QuickSortLomutoTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSortLomuto);
    TestSort(new int[] { }, Sorting.QuickSortLomuto);
    TestSort(new[] { 1 }, Sorting.QuickSortLomuto);
    TestSort(new[] { -1, -99 }, Sorting.QuickSortLomuto);
    TestSort(new[] { 1, 5, -10 }, Sorting.QuickSortLomuto);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSortLomuto);
  }
    
  [Test]
  public void HeapSortTest()
  {
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.HeapSort);
    TestSort(new int[] { }, Sorting.HeapSort);
    TestSort(new[] { 1 }, Sorting.HeapSort);
    TestSort(new[] { -1, -99 }, Sorting.HeapSort);
    TestSort(new[] { 1, 5, -10 }, Sorting.HeapSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.HeapSort);
  }
    
  [Test]
  public void HeapSortGenericTest()
  {
    void HeapSort(int[] a) => Sorting.HeapSort(a, Comparer<int>.Default.Compare);
    TestSort(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, HeapSort);
    TestSort(new int[] { }, HeapSort);
    TestSort(new[] { 1 }, HeapSort);
    TestSort(new[] { -1, -99 }, HeapSort);
    TestSort(new[] { 1, 5, -10 }, HeapSort);
    TestSort(new[] { 6, 5, 4, 1, 2, 3 }, HeapSort);
  }

  [Test]
  public void QuickSelectEMaxxTest()
  {
    TestSelect(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSelectEMaxx);
    TestSelect(new[] { 1 }, Sorting.QuickSelectEMaxx);
    TestSelect(new[] { -1, -99 }, Sorting.QuickSelectEMaxx);
    TestSelect(new[] { 1, 5, -10 }, Sorting.QuickSelectEMaxx);
    TestSelect(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSelectEMaxx);
  }
    
  [Test]
  public void QuickSelectTest()
  {
    TestSelect(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSelect);
    TestSelect(new[] { 1 }, Sorting.QuickSelect);
    TestSelect(new[] { -1, -99 }, Sorting.QuickSelect);
    TestSelect(new[] { 1, 5, -10 }, Sorting.QuickSelect);
    TestSelect(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSelect);
  }
    
  private static void TestSort(int[] a, Action<int[]> sort)
  {
    var expected = a.OrderBy(x => x).ToArray();
    sort(a);
    a.Should().BeEquivalentTo(expected);
  }

  private static void TestSelect(int[] a, Func<int[], int, int> select)
  {
    var b = a.OrderBy(x => x).ToArray();
    for (int i = 0; i < a.Length; i++)
      select(a, i).Should().Be(b[i]);
  }
}