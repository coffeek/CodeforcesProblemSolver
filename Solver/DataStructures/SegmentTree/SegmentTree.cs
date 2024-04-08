using static System.Math;

namespace Solver.DataStructures.SegmentTree;

public class SegmentTreeNode<T>
{
  private readonly int l;
  private readonly int r;
  private T data;
  private readonly SegmentTreeNode<T> left;
  private readonly SegmentTreeNode<T> right;
  private readonly Func<T, T, T> aggregateFunc;

  public void Update(int pos, T value)
  {
    if (l == r)
    {
      data = value;
    }
    else
    {
      if (pos <= left.r)
        left.Update(pos, value);
      else
        right.Update(pos, value);
      data = aggregateFunc(left.data, right.data);
    }
  }

  public T Query(int l, int r)
  {
    if (l > r)
      return default;
    if (this.l == l && this.r == r)
      return data;
    return aggregateFunc(left.Query(l, Min(r, left.r)), right.Query(Max(l, right.l), r));
  }

  public SegmentTreeNode(T[] data, int l, int r, Func<T, T, T> aggregateFunc)
  {
    this.l = l;
    this.r = r;
    this.aggregateFunc = aggregateFunc;

    if (l != r)
    {
      var m = l + (r - l) / 2;
      left = new SegmentTreeNode<T>(data, l, m, aggregateFunc);
      right = new SegmentTreeNode<T>(data, m + 1, r, aggregateFunc);
    }

    for (int i = l; i <= r; i++)
      Update(i, data[i]);
  }
}

public class SegmentTree<T>
{
  private readonly SegmentTreeNode<T> root;

  public void Update(int pos, T value)
  {
    root.Update(pos, value);
  }

  public T Query(int l, int r)
  {
    return root.Query(l, r);
  }

  public SegmentTree(T[] data, Func<T, T, T> aggregate)
  {
    root = new SegmentTreeNode<T>(data, 0, data.Length - 1, aggregate);
  }
}
