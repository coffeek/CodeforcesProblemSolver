﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

  [TestCase(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MinTest(int[] values)
  {
    Functions.Min(values).Should().Be(values.Min());
  }

  [TestCase(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MaxTest(int[] values)
  {
    Functions.Max(values).Should().Be(values.Max());
  }

  [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
  [TestCase(new[] { -1 }, -1, int.MinValue)]
  [TestCase(new[] { -1, -10 }, -1, -10)]
  [TestCase(new[] { 7, -10, 1014, 895, 1014, 0 }, 1014, 1014)]
  [TestCase(new int[] { }, int.MinValue, int.MinValue)]
  public void Find2MaxTest(int[] values, int expectedMax1, int expectedMax2)
  {
    Functions.Find2Max(values).Should().Be((expectedMax1, expectedMax2));
  }

  [Test]
  public void PermuteTest()
  {
    var expected = new[] { "1 2 3", "1 3 2", "2 1 3", "2 3 1", "3 2 1", "3 1 2" };
    var actual = new List<string>();
    Functions.Permute(new[] { 1, 2, 3 }, 0, 3, p => actual.Add(string.Join(" ", p)));
    CollectionAssert.AreEqual(expected, actual);
  }

  [TestCase(1, 0, 1)]
  [TestCase(1, 1, 1)]
  [TestCase(0, 1, 0)]
  [TestCase(2, 3, 0)]
  [TestCase(2, 1, 2)]
  [TestCase(20, 1, 20)]
  [TestCase(20, 19, 20)]
  [TestCase(20, 10, 184756)]
  public void CombinationsTest(int n, int k, long expected)
  {
    Functions.Combinations(n, k).Should().Be(expected);
  }
}
