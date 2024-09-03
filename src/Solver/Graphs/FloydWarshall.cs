namespace Solver.Graphs;

/// <summary>
/// Floyd-Warshall Algorithm
/// Find the length of the shortest path d[i,j] between each pair of vertices i and j.
/// https://cp-algorithms.com/graph/all-pair-shortest-path-floyd-warshall.html
/// </summary>
public static class FloydWarshall
{
  public static void FindDistances(int n, int[][] d)
  {
    for (var k = 0; k < n; ++k)
    {
      for (var i = 0; i < n; ++i)
      {
        for (var j = 0; j < n; ++j)
        {
          d[i][j] = Math.Min(d[i][j], d[i][k] + d[k][j]);
        }
      }
    }
  }
  
  public static int[][] FindDistances(List<(int to, int w)>[] g)
  {
    int n = g.Length;
    var distanceMatrix = new int[n][];
    for (var i = 0; i < n; i++)
    {
      distanceMatrix[i] = new int[n];
      distanceMatrix[i].AsSpan().Fill((int)1e9);
    }
    for (var v = 0; v < g.Length; v++)
    {
      var edges = g[v];
      foreach (var (to, w) in edges)
        distanceMatrix[v][to] = w;
    }

    FindDistances(n, distanceMatrix);
    return distanceMatrix;
  }
}
