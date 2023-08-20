using FluentAssertions;
using NUnit.Framework;
using Solver.Graphs;

namespace Solver.Tests.Graphs;

[TestFixture]
public class MstTests
{
  [Test]
  public void KruskalTest()
  {
    Mst.Kruskal(
      new[]
      {
        new Edge(0, 1, 4),
        new Edge(0, 2, 13),
        new Edge(0, 3, 7),
        new Edge(0, 4, 7),
        new Edge(1, 2, 9),
        new Edge(1, 3, 3),
        new Edge(1, 4, 7),
        new Edge(2, 3, 10),
        new Edge(2, 4, 14),
        new Edge(3, 4, 4)
      }, 5).Should().Be(20);
    Mst.Kruskal(new[] { new Edge(0, 1, 12), new Edge(0, 2, 18), new Edge(1, 2, 6) }, 3).Should().Be(18);
  }

  [Test]
  public void PrimTest()
  {
    Mst.Prim(new[]
    {
      new[] { 0, 4, 13, 7, 7 },
      new[] { 4, 0, 9, 3, 7 },
      new[] { 13, 9, 0, 10, 14 },
      new[] { 7, 3, 10, 0, 4 },
      new[] { 7, 7, 14, 4, 0 }
    }).Should().Be(20);
    Mst.Prim(new[] { new[] { 0, 12, 18 }, new[] { 12, 0, 6 }, new[] { 18, 6, 0 } }).Should().Be(18);
  }
}
