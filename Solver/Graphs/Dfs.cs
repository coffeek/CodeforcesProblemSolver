using System;
using System.Collections.Generic;

namespace Solver.Graphs;

/// <summary>
/// Depth-First Search.
/// </summary>
public class Dfs
{
  private readonly List<List<int>> g;
  private readonly Action<int> action;
  private readonly bool[] visited;
  
  public Dfs(List<List<int>> g, Action<int> action)
  {
    this.g = g;
    this.action = action;
    visited = new bool[g.Count];
  }

  public void Run(int from)
  {
    action(from);
    visited[from] = true;
    if (g[from] is null)
      return;
    for (int i = 0; i < g[from].Count; i++)
    {
      if (!visited[from])
        Run(from);
    }
  }
}
