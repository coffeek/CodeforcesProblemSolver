using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class UnionFindTests
{
  [Test]
  public void UsageTest()
  {
    var dsu = new UnionFind(10);
    dsu.Count.Should().Be(10);
    dsu.Find(1).Should().Be(1);
    dsu.Find(9).Should().Be(9);
    dsu.Union(1, 9).Should().BeTrue();
    dsu.Union(1, 9).Should().BeFalse();
    dsu.Find(1).Should().Be(1);
    dsu.Find(9).Should().Be(1);
    dsu.Union(1, 5).Should().BeTrue();
    dsu.Find(5).Should().Be(1);
    dsu.Count.Should().Be(8);
    
    dsu.Union(0, 2).Should().BeTrue();
    dsu.Find(2).Should().Be(0);
    dsu.Count.Should().Be(7);

    dsu.Union(2, 9).Should().BeTrue();
    dsu.Find(0).Should().Be(1);
    dsu.Find(2).Should().Be(1);
    dsu.Count.Should().Be(6);
  }
}
