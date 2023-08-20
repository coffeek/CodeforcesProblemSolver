namespace Solver.DataStructures;

/// <summary>
/// Disjoint-set / Union–find / Merge-find data structure.
/// https://en.wikipedia.org/wiki/Disjoint-set_data_structure 
/// </summary>
public class UnionFind
{
  private readonly int[] parent;
  private readonly int[] size;
  private int count;

  public int Count => count;

  public void MakeSet(int x)
  {
    parent[x] = x;
    size[x] = 1;
    count++;
  }

  public int Find(int x)
  {
    while (parent[x] != x)
    {
      parent[x] = parent[parent[x]];
      x = parent[x];
    }
    return x;
  }

  public bool Union(int x, int y)
  {
    x = Find(x);
    y = Find(y);
    if (x != y)
    {
      if (size[x] < size[y])
        (x, y) = (y, x);
      parent[y] = x; // Always add a smaller set to a larger set.
      size[x] += size[y];
      count--; // After the operation, the number of sets decreased by 1.
    }
    return x != y;
  }

  public UnionFind(int n)
  {
    parent = new int[n];
    size = new int[n];
    for (var i = 0; i < n; i++)
      MakeSet(i);
  }
}
