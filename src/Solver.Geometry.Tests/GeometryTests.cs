using NUnit.Framework;

namespace Solver.Geometry.Tests;

[TestFixture]
public class GeometryTests
{
  [TestCase(0.0000000015f, 0)]
  [TestCase(-0.0000000015f, 0)]
  [TestCase(0.00001f, 1)]
  [TestCase(-0.00001f, -1)]
  public void CmpZTest(float value, int expected)
  {
    Geometry.CmpZ(value).Should().Be(expected);
  }

  [Test]
  public void ReflectTest()
  {
    Geometry.Reflect(new Vector3(-1, 0, 1), new Vector3(0, 0, 1))
      .Should().Be(new Vector3(-1, 0, -1));
    Geometry.Reflect(new Vector3(0, -1, 1), new Vector3(0, 0, 1))
      .Should().Be(new Vector3(0, -1, -1));
    Geometry.Reflect(new Vector3(-1, -1, -1), new Vector3(0, 0, 1))
      .Should().Be(new Vector3(-1, -1, 1));
  }
}
