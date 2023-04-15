using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solver.Sorting;

namespace Solver.Tests.Sorting;

[TestFixture]
public class SelectionTests
{
  [Test]
  public void QuickSelectTest()
  {
    TestSelect(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Selection.QuickSelect);
    TestSelect(new[] { 1 }, Selection.QuickSelect);
    TestSelect(new[] { -1, -99 }, Selection.QuickSelect);
    TestSelect(new[] { 1, 5, -10 }, Selection.QuickSelect);
    TestSelect(new[] { 6, 5, 4, 1, 2, 3 }, Selection.QuickSelect);
  }
  
  [Test]
  public void QuickSelectEMaxxTest()
  {
    TestSelect(new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 }, Selection.QuickSelectEMaxx);
    TestSelect(new[] { 1 }, Selection.QuickSelectEMaxx);
    TestSelect(new[] { -1, -99 }, Selection.QuickSelectEMaxx);
    TestSelect(new[] { 1, 5, -10 }, Selection.QuickSelectEMaxx);
    TestSelect(new[] { 6, 5, 4, 1, 2, 3 }, Selection.QuickSelectEMaxx);
  }

  private static void TestSelect(int[] a, Func<int[], int, int> select)
  {
    var b = a.OrderBy(x => x).ToArray();
    for (int i = 0; i < a.Length; i++)
      select(a, i).Should().Be(b[i]);
  }
  
  [Test]
  public void LowerBoundTests()
  {
    Assert.That(Selection.LowerBound(Array.Empty<int>(), 1), Is.EqualTo(0));

    var f = (Action<int[]>)(a =>
    {
      Assert.That(Selection.LowerBound(a, -1), Is.EqualTo(0));
      for (int i = 0; i < 10; i++)
      {
        var expected = Enumerable.Range(0, a.Length).Cast<int?>().FirstOrDefault(j => a[j.Value] >= i) ?? a.Length;
        Assert.That(Selection.LowerBound(a, i), Is.EqualTo(expected), $"a: [{string.Join(" ", a)}], value: {i}");
      }
    });

    f(new[] { 0 });
    f(new[] { 9 });
    f(new[] { 0, 0 });
    f(new[] { 1, 1, 1 });
    f(new[] { 1, 2, 3 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9, 9 });
  }
  
  [Test]
  public void UpperBoundTests()
  {
    Assert.That(Selection.UpperBound(Array.Empty<int>(), 1), Is.EqualTo(0));

    var f = (Action<int[]>)(a =>
    {
      Assert.That(Selection.UpperBound(a, -1), Is.EqualTo(0));
      for (int i = 0; i < 10; i++)
      {
        var expected = Enumerable.Range(0, a.Length).Cast<int?>().FirstOrDefault(j => a[j.Value] > i) ?? a.Length;
        Assert.That(Selection.UpperBound(a, i), Is.EqualTo(expected), $"a: [{string.Join(" ", a)}], value: {i}");
      }
    });

    f(new[] { 0 });
    f(new[] { 9 });
    f(new[] { 0, 0 });
    f(new[] { 1, 1, 1 });
    f(new[] { 1, 2, 3 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9, 9 });
  }
}
