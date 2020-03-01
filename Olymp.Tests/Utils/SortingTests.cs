using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils
{
  [TestFixture]
  public class SortingTests
  {
    [Test]
    public void QuickSortTest()
    {
      QuickSortTestCase(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSort);
      QuickSortTestCase(new int[] { }, Sorting.QuickSort);
      QuickSortTestCase(new[] { 1 }, Sorting.QuickSort);
      QuickSortTestCase(new[] { -1, -99 }, Sorting.QuickSort);
      QuickSortTestCase(new[] { 1, 5, -10 }, Sorting.QuickSort);
      QuickSortTestCase(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSort);
    }
    
    [Test]
    public void QuickSortLomutoTest()
    {
      QuickSortTestCase(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSortLomuto);
      QuickSortTestCase(new int[] { }, Sorting.QuickSortLomuto);
      QuickSortTestCase(new[] { 1 }, Sorting.QuickSortLomuto);
      QuickSortTestCase(new[] { -1, -99 }, Sorting.QuickSortLomuto);
      QuickSortTestCase(new[] { 1, 5, -10 }, Sorting.QuickSortLomuto);
      QuickSortTestCase(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSortLomuto);
    }

    [Test]
    public void QuickSelectEMaxxTest()
    {
      QuickSelectTestCase(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSelectEMaxx);
      QuickSelectTestCase(new[] { 1 }, Sorting.QuickSelectEMaxx);
      QuickSelectTestCase(new[] { -1, -99 }, Sorting.QuickSelectEMaxx);
      QuickSelectTestCase(new[] { 1, 5, -10 }, Sorting.QuickSelectEMaxx);
      QuickSelectTestCase(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSelectEMaxx);
    }
    
    [Test]
    public void QuickSelectTest()
    {
      QuickSelectTestCase(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Sorting.QuickSelect);
      QuickSelectTestCase(new[] { 1 }, Sorting.QuickSelect);
      QuickSelectTestCase(new[] { -1, -99 }, Sorting.QuickSelect);
      QuickSelectTestCase(new[] { 1, 5, -10 }, Sorting.QuickSelect);
      QuickSelectTestCase(new[] { 6, 5, 4, 1, 2, 3 }, Sorting.QuickSelect);
    }
    
    private static void QuickSortTestCase(int[] a, Action<int[]> sort)
    {
      var expected = a.OrderBy(x => x).ToArray();
      sort(a);
      a.Should().BeEquivalentTo(expected);
    }

    private static void QuickSelectTestCase(int[] a, Func<int[], int, int> select)
    {
      var b = a.OrderBy(x => x).ToArray();
      for (int i = 0; i < a.Length; i++)
        select(a, i).Should().Be(b[i]);
    }
  }
}
