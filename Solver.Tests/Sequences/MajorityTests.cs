using FluentAssertions;
using NUnit.Framework;
using Solver.Sequences;

namespace Solver.Tests.Sequences;

[TestFixture]
public class MajorityTests
{
  [TestCase(new[] { 3, 2, 3 }, 3)]
  [TestCase(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
  public void MajorityElement(int[] a, int expected)
  {
    new Majority().MajorityElement(a).Should().Be(expected);
  }
  
  [TestCase(new[] { 3, 2, 3 }, new[] { 3 })]
  [TestCase(new[] { 1 }, new[] { 1 })]
  [TestCase(new[] { 1, 2 }, new[] { 1, 2 })]
  [TestCase(new[] { 1, 3, 4, 3, 3, 3, 1, 3, 5, 6, 1, 5, 3, 1, 5, 1, 1 }, new[] { 1, 3 })]
  public void ThirdMajorityElements(int[] a, int[] expected)
  {
    new Majority().ThirdMajorityElements(a).Should().BeEquivalentTo(expected);
  }
}
