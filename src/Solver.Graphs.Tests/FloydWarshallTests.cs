namespace Solver.Graphs.Tests;

[TestFixture]
public class FloydWarshallTests
{
  [Test]
  public void FindDistance_ForAdjMatrixGraph()
  {
    const int inf = (int)1e9;
    int[][] distanceMatrix =
    {
      new[] { inf, 3, inf, inf }, 
      new[] { 3, inf, 1, 4 }, 
      new[] { inf, 1, inf, 1 }, 
      new[] { inf, 4, 1, inf }
    };
    FloydWarshall.FindDistances(4, distanceMatrix);

    distanceMatrix.Should()
      .BeEquivalentTo(new[]
        {
          new[] { 6, 3, 4, 5 }, 
          new[] { 3, 2, 1, 2 }, 
          new[] { 4, 1, 2, 1 }, 
          new[] { 5, 2, 1, 2 }
        },
        o => o.WithStrictOrdering());
  }

  [Test]
  public void FindDistance_ForListOfEdgesGraph()
  {
    var graph = new List<(int to, int w)>[]
    {
      new() { (1, 3), }, 
      new() { (0, 3), (2, 1), (3, 4) }, 
      new() { (1, 1), (3, 1) }, 
      new() { (2, 1), (1, 4) },
    };
    
    var distanceMatrix = FloydWarshall.FindDistances(graph);

    distanceMatrix.Should()
      .BeEquivalentTo(new[]
        {
          new[] { 6, 3, 4, 5 }, 
          new[] { 3, 2, 1, 2 }, 
          new[] { 4, 1, 2, 1 }, 
          new[] { 5, 2, 1, 2 }
        },
        o => o.WithStrictOrdering());
  }
}
