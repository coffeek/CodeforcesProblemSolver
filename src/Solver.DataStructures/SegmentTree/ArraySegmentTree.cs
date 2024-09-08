namespace Solver.DataStructures.SegmentTree;

public class ArraySegmentTree<T>
{
  private readonly Func<T, T, T> aggregateFunc;
  private readonly T[] tree;
  private readonly int n;

  public T Query(int l, int r)
  {
    return Query(1, 0, n - 1, l, r);
  }

  private T Query(int v, int tl, int tr, int l, int r)
  {
    if (l > r)
      return default;
    if (l == tl && r == tr)
      return tree[v];
    int tm = tl + (tr - tl) / 2;
    return aggregateFunc(Query(v * 2, tl, tm, l, Math.Min(r, tm)),
      Query(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r));
  }

  public void FastUpdate(int pos, T value)
  {
    var v = 1;
    var tl = 0;
    var tr = n - 1;
    while (tl != tr)
    {
      int tm = tl + (tr - tl) / 2;
      if (pos <= tm)
      {
        v = 2 * v;
        tr = tm;
      }
      else
      {
        v = 2 * v + 1;
        tl = tm + 1;
      }
    }
    tree[v] = value;
    while (v != 1)
    {
      v /= 2;
      tree[v] = aggregateFunc(tree[v * 2], tree[v * 2 + 1]);
    }
  }

  public void Update(int pos, T value)
  {
    Update(1, 0, n - 1, pos, value);
  }

  private void Update(int v, int tl, int tr, int pos, T value)
  {
    if (tl == tr)
    {
      tree[v] = value;
    }
    else
    {
      int tm = tl + (tr - tl) / 2;
      if (pos <= tm)
        Update(v * 2, tl, tm, pos, value);
      else
        Update(v * 2 + 1, tm + 1, tr, pos, value);
      tree[v] = aggregateFunc(tree[v * 2], tree[v * 2 + 1]);
    }
  }

  private void Build(T[] data, int v, int tl, int tr)
  {
    if (tl == tr)
    {
      tree[v] = data[tl];
    }
    else
    {
      int tm = tl + (tr - tl) / 2;
      Build(data, v * 2, tl, tm);
      Build(data, v * 2 + 1, tm + 1, tr);
      tree[v] = aggregateFunc(tree[v * 2], tree[v * 2 + 1]);
    }
  }

  public ArraySegmentTree(T[] data, Func<T, T, T> aggregate)
  {
    aggregateFunc = aggregate;
    n = data.Length;
    tree = new T[4 * n];
    Build(data, 1, 0, n - 1);
  }
}
