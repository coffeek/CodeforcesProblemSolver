using FluentAssertions;
using NUnit.Framework;
using Solver.Sequences;

namespace Solver.Tests.Sequences;

[TestFixture]
public class MajorityTests
{
  [TestCase(new[] { 3, 2, 3 }, 3)]
  [TestCase(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
  public void Test(int[] a, int expected)
  {
    new Majority().MajorityElement(a).Should().Be(expected);
  }
}
