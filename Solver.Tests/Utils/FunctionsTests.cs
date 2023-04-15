using System.Collections.Generic;
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

  [Test]
  public void PermuteTest()
  {
    var expected = new[] { "1 2 3", "1 3 2", "2 1 3", "2 3 1", "3 2 1", "3 1 2" };
    var actual = new List<string>();
    Functions.Permute(new[] { 1, 2, 3 }, 0, 3, p => actual.Add(string.Join(" ", p)));
    CollectionAssert.AreEqual(expected, actual);
  }
}
