using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Solver.Utils;

namespace Solver.Tests.Utils;

[TestFixture]
public class FunctionsTests
{
  [Test]
  public void CompactTests()
  {
    static int[] Call(IEnumerable<int> a) => Functions.Compact(a).ToArray();

    Assert.That(Call(new[] { 0 }), Is.EquivalentTo(new[] { 0 }));
    Assert.That(Call(new[] { 1 }), Is.EquivalentTo(new[] { 1 }));
    Assert.That(Call(new[] { 0, 0, 0 }), Is.EquivalentTo(new[] { 0 }));
    Assert.That(Call(new[] { 1, 0, 1 }), Is.EquivalentTo(new[] { 1, 0, 1 }));
    Assert.That(Call(new[] { 1, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 1, 0, 1, 0 }));
    Assert.That(Call(new[] { 1, 2, 3, 4, 5 }), Is.EquivalentTo(new[] { 1, 2, 3, 4, 5 }));
    Assert.That(Call(new[] { 1, 1, 1, 2, 2, 2, 0, 0, 3, 1, 2 }), Is.EquivalentTo(new[] { 1, 2, 0, 3, 1, 2 }));
    Assert.That(Call(new[] { 0, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 0, 1, 0 }));
  }

  [Test]
  public void UpperBoundTests()
  {
    Assert.That(Functions.UpperBound(Array.Empty<int>(), 1), Is.EqualTo(0));

    var f = (Action<int[]>)(a =>
    {
      Assert.That(Functions.UpperBound(a, -1), Is.EqualTo(0));
      for (int i = 0; i < 10; i++)
      {
        var expected = Enumerable.Range(0, a.Length).Cast<int?>().FirstOrDefault(j => a[j.Value] > i) ?? a.Length;
        Assert.That(Functions.UpperBound(a, i), Is.EqualTo(expected));
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
