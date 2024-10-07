namespace Solver.Graphs.Tests;

[TestFixture]
public class DijkstraTests
{
  [Test]
  public void ShortestDistanceTest_Matrix()
  {
    var g = new[,] { { 0, 2, 5, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 3, 0, 0, 0 } };
    new Dijkstra().ShortestDistance(g, 3, 3).Should().Be(0);
    new Dijkstra().ShortestDistance(g, 3, 0).Should().Be(3);
    new Dijkstra().ShortestDistance(g, 3, 1).Should().Be(5);
    new Dijkstra().ShortestDistance(g, 3, 2).Should().Be(6);
    new Dijkstra().ShortestDistance(g, 0, 2).Should().Be(3);
    new Dijkstra().ShortestDistance(g, 2, 3).Should().Be(-1);
  }

  [Test]
  public void ShortestDistanceTest_EdgeList()
  {
    var g = new List<(int to, int w)>[]
    {
      new() { (2, 5), (1, 2) }, // 0
      new() { (2, 1) }, // 1
      new(), // 2
      new() { (0, 3) } // 3
    };
    new Dijkstra().ShortestDistance(g, 3, 3).Should().Be(0);
    new Dijkstra().ShortestDistance(g, 3, 0).Should().Be(3);
    new Dijkstra().ShortestDistance(g, 3, 1).Should().Be(5);
    new Dijkstra().ShortestDistance(g, 3, 2).Should().Be(6);
    new Dijkstra().ShortestDistance(g, 0, 2).Should().Be(3);
    new Dijkstra().ShortestDistance(g, 2, 3).Should().Be(-1);
  }
  
  [Test]
  public void ShortestDistanceUsingQueueTest_EdgeList()
  {
    var g = new List<(int to, int w)>[]
    {
      new() { (2, 5), (1, 2) }, // 0
      new() { (2, 1) }, // 1
      new(), // 2
      new() { (0, 3) } // 3
    };
    new Dijkstra().ShortestDistanceUsingQueue(g, 3, 3).Should().Be(0);
    new Dijkstra().ShortestDistanceUsingQueue(g, 3, 0).Should().Be(3);
    new Dijkstra().ShortestDistanceUsingQueue(g, 3, 1).Should().Be(5);
    new Dijkstra().ShortestDistanceUsingQueue(g, 3, 2).Should().Be(6);
    new Dijkstra().ShortestDistanceUsingQueue(g, 0, 2).Should().Be(3);
    new Dijkstra().ShortestDistanceUsingQueue(g, 2, 3).Should().Be(-1);
  }

  [Test]
  public void ShortestPathTest_EdgeList()
  {
    var g = new List<(int to, int w)>[]
    {
      new() { (2, 5), (1, 2) }, // 0
      new() { (2, 1) }, // 1
      new(), // 2
      new() { (0, 3) } // 3
    };
    new Dijkstra().ShortestPath(g, 3, 3).Should().BeEquivalentTo(new[] { 3 });
    new Dijkstra().ShortestPath(g, 3, 0).Should().BeEquivalentTo(new[] { 3, 0 }, o => o.WithStrictOrdering());
    new Dijkstra().ShortestPath(g, 3, 1).Should().BeEquivalentTo(new[] { 3, 0, 1 }, o => o.WithStrictOrdering());
    new Dijkstra().ShortestPath(g, 3, 2).Should().BeEquivalentTo(new[] { 3, 0, 1, 2 }, o => o.WithStrictOrdering());
    new Dijkstra().ShortestPath(g, 0, 2).Should().BeEquivalentTo(new[] { 0, 1, 2 }, o => o.WithStrictOrdering());
    new Dijkstra().ShortestPath(g, 2, 3).Should().BeEmpty();
  }
}
