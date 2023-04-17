using FluentAssertions;
using NUnit.Framework;

namespace Solver.Tests.Geometry;

[TestFixture]
public class GeometryTests
{
  [TestCase(0.0000000015f, 0)]
  [TestCase(-0.0000000015f, 0)]
  [TestCase(0.00001f, 1)]
  [TestCase(-0.00001f, -1)]
  public void CmpZTest(float value, int expected)
  {
    Solver.Geometry.Geometry.CmpZ(value).Should().Be(expected);
  }
}
