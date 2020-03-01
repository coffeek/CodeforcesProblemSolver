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
      var a = new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 };
      Sorting.QuickSort(a);
      a.Should().BeEquivalentTo(a.OrderBy(x => x).ToArray());
      
      a = new int[] { };
      Sorting.QuickSort(a);
      a.Should().BeEquivalentTo(a.OrderBy(x => x).ToArray());
      
      a = new[] { 1 };
      Sorting.QuickSort(a);
      a.Should().BeEquivalentTo(a.OrderBy(x => x).ToArray());
      
      a = new[] { -1, -99 };
      Sorting.QuickSort(a);
      a.Should().BeEquivalentTo(a.OrderBy(x => x).ToArray());
      
      a = new[] { 1, 5, -10 };
      Sorting.QuickSort(a);
      a.Should().BeEquivalentTo(a.OrderBy(x => x).ToArray());
    }

    [Test]
    public void QuickSelectTest()
    {
      var a = new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 };
      var b = a.OrderBy(x => x).ToArray();
      for (int i = 0; i < a.Length; i++)
      {
        Sorting.QuickSelect(a, i).Should().Be(b[i]);
      }
      
      a = new[] { 1 };
      b = a.OrderBy(x => x).ToArray();
      for (int i = 0; i < a.Length; i++)
      {
        Sorting.QuickSelect(a, i).Should().Be(b[i]);
      }
      
      a = new[] { -1, -99 };
      b = a.OrderBy(x => x).ToArray();
      for (int i = 0; i < a.Length; i++)
      {
        Sorting.QuickSelect(a, i).Should().Be(b[i]);
      }
      
      a = new[] { 1, 5, -10 };
      b = a.OrderBy(x => x).ToArray();
      for (int i = 0; i < a.Length; i++)
      {
        Sorting.QuickSelect(a, i).Should().Be(b[i]);
      }
    }
  }
}
