namespace Solver.Graphs;

public class Dijkstra
{
  public int ShortestDistance(int[,] weights, int from, int to)
  {
    var n = weights.GetLength(0);
    var visited = new bool[n];
    var dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[from] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!visited[j] && (v == -1 || dist[j] < dist[v]))
          v = j;
      }
      if (dist[v] == int.MaxValue)
        break;
      visited[v] = true;
      for (var j = 0; j < n; j++)
      {
        if (weights[v, j] != 0)
          dist[j] = Math.Min(dist[j], dist[v] + weights[v, j]);
      }
    }
    return dist[to] == int.MaxValue ? -1 : dist[to];
  }

  public int ShortestDistance(List<(int to, int w)>[] g, int from, int to)
  {
    var n = g.Length;
    var visited = new bool[n];
    var dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[from] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!visited[j] && (v == -1 || dist[j] < dist[v]))
          v = j;
      }
      if (dist[v] == int.MaxValue)
        break;
      visited[v] = true;
      foreach (var edge in g[v])
        dist[edge.to] = Math.Min(dist[edge.to], dist[v] + edge.w);
    }
    return dist[to] == int.MaxValue ? -1 : dist[to];
  }
  
  /// <summary>
  /// O(m*log(n)) implementation.
  /// </summary>
  public int ShortestDistanceUsingQueue(List<(int to, int weight)>[] g, int from, int to)
  {
    var n = g.Length;
    var dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[from] = 0;
    var q = new PriorityQueue<int, int>();
    q.Enqueue(from, dist[from]);

    while (q.Count > 0)
    {
      q.TryDequeue(out var v, out var d);
      if (d > dist[v])
        continue; // skip duplicate
      foreach (var edge in g[v])
      {
        var newDist = dist[v] + edge.weight;
        if (newDist < dist[edge.to])
        {
          dist[edge.to] = newDist;
          q.Enqueue(edge.to, newDist);
        }
      }
    }
    return dist[to] == int.MaxValue ? -1 : dist[to];
  }

  public int[] ShortestPath(List<(int to, int w)>[] edges, int from, int to)
  {
    var n = edges.Length;
    var visited = new bool[n];
    var dist = new int[n];
    var prev = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[from] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!visited[j] && (v == -1 || dist[j] < dist[v]))
          v = j;
      }
      if (dist[v] == int.MaxValue)
        break;
      visited[v] = true;
      foreach (var edge in edges[v])
      {
        if (dist[v] + edge.w < dist[edge.to])
        {
          dist[edge.to] = dist[v] + edge.w;
          prev[edge.to] = v;
        }
      }
    }
    if (dist[to] == int.MaxValue)
      return Array.Empty<int>();
    var path = new Stack<int>();
    for (int v = to; v != from; v = prev[v])
      path.Push(v);
    path.Push(from);
    return path.ToArray();
  }
}
