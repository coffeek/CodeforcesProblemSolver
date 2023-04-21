using System;
using System.Collections.Generic;

namespace Solver.Graphs;

/// <summary>
/// Breadth-First Search.
/// </summary>
public class Bfs
{
  private readonly List<List<int>> g;
  private readonly Action<int> action;
  private readonly bool[] visited;

  public Bfs(List<List<int>> g, Action<int> action)
  {
    this.g = g;
    this.action = action;
    visited = new bool[g.Count];
  }

  public void Run(int from)
  {
    if (visited[from])
      return;
    
    var q = new Queue<int>();
    q.Enqueue(from);
    while (q.Count > 0)
    {
      var v = q.Dequeue();
      action(v);
      visited[v] = true;
      if (g[v] is null)
        continue;
      for (int i = 0; i < g[v].Count; i++)
      {
        var to = g[v][i];
        if (!visited[to])
        {
          action(to);
          visited[to] = true;
          q.Enqueue(to);
        }
      }
    }
  }
}
