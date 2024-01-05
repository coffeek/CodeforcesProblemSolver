using System;
using FluentAssertions;
using NUnit.Framework;
using Solver.Sequences;

namespace Solver.Tests.Sequences;

[TestFixture]
public class LisAlgorithmsTests
{
  [TestCase(new[] { 1, 3, 5, 4, 7 }, 4)]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 1)]
  [TestCase(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }, 5)]
  [TestCase(new[] { 4 }, 1)]
  [TestCase(new[] { 4, 5 }, 2)]
  [TestCase(new int[0], 0)]
  public void LengthOfLis(int[] numbers, int expected)
  {
    LisAlgorithms.LengthOfLis(numbers).Should().Be(expected);
  }

  [TestCase(new[] { 1}, 1)]
  [TestCase(new[] { 1, 3, 5, 4, 7 }, 2)]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 5)]
  [TestCase(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }, 3)]
  [TestCase(new[] { 4, 5 }, 1)]
  [TestCase(new int[0], 0)]
  public void FindNumberOfLis(int[] numbers, int expected)
  {
    LisAlgorithms.FindNumberOfLis(numbers).Should().Be(expected);
  }
  
  [TestCase(new[] { 1, 3, 5, 4, 7 }, 4)]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 1)]
  [TestCase(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }, 5)]
  [TestCase(new[] { 4 }, 1)]
  [TestCase(new[] { 4, 5 }, 2)]
  [TestCase(new int[0], 0)]
  public void LengthOfLisBinarySearch(int[] numbers, int expected)
  {
    LisAlgorithms.LengthOfLisBinarySearch(numbers).Should().Be(expected);
  }
}
