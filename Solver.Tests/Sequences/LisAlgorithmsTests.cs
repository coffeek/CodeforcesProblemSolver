using System;
using FluentAssertions;
using NUnit.Framework;
using Solver.Sequences;

namespace Solver.Tests.Sequences;

[TestFixture]
public class LisAlgorithmsTests
{
  [Test]
  public void LengthOfLis()
  {
    LisAlgorithms.LengthOfLis(Array.Empty<int>()).Should().Be(0);
    LisAlgorithms.LengthOfLis(new[] { 1 }).Should().Be(1);
    LisAlgorithms.LengthOfLis(new[] { 1, 3, 5, 4, 7 }).Should().Be(4);
    LisAlgorithms.LengthOfLis(new[] { 2, 2, 2, 2, 2 }).Should().Be(1);
    LisAlgorithms.LengthOfLis(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }).Should().Be(5);
  }

  [Test]
  public void FindNumberOfLis()
  {
    LisAlgorithms.FindNumberOfLis(Array.Empty<int>()).Should().Be(0);
    LisAlgorithms.FindNumberOfLis(new[] { 1 }).Should().Be(1);
    LisAlgorithms.FindNumberOfLis(new[] { 1, 3, 5, 4, 7 }).Should().Be(2);
    LisAlgorithms.FindNumberOfLis(new[] { 2, 2, 2, 2, 2 }).Should().Be(5);
    LisAlgorithms.FindNumberOfLis(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }).Should().Be(3);
  }
}
