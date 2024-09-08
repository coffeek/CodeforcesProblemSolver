namespace Solver.DataStructures.BinaryTrees;

public class CountingBst
{
  private BstNode root;

  public CountingBst(long[] sorted)
  {
    root = new BstNode(sorted, 0, sorted.Length - 1, null);
  }

  public int CountLessThan(long value)
  {
    return CountLessThan(root, value);
  }

  private int CountLessThan(BstNode node, long value)
  {
    while (true)
    {
      if (node == null)
        return 0;
      if (node.Value >= value)
      {
        node = node.Left;
        continue;
      }

      var count = 1;
      if (node.Left != null)
        count += node.Left.Count;
      return count + CountLessThan(node.Right, value);
    }
  }

  public void Remove(long value)
  {
    var node = Find(root, value);
    Delete(node);
    while (node.Parent != null)
    {
      node = node.Parent;
      node.Count--;
    }
  }

  private BstNode Find(BstNode node, long value)
  {
    while (true)
    {
      if (node is null)
        return null;
      if (node.Value == value)
        return node;
      if (value < node.Value)
        node = node.Left;
      else
        node = node.Right;
    }
  }

  private void Delete(BstNode z)
  {
    if (z.Left == null)
    {
      Transplant(z, z.Right);
    }
    else if (z.Right == null)
    {
      Transplant(z, z.Left);
    }
    else
    {
      var y = Minimum(z.Right);

      var p = y.Parent;
      while (p != z)
      {
        p.Count--;
        p = p.Parent;
      }

      if (y.Parent != z)
      {
        Transplant(y, y.Right);
        y.Right = z.Right;
        y.Right.Parent = y;
      }

      Transplant(z, y);
      y.Left = z.Left;
      y.Left.Parent = y;

      y.Count = 1;
      if (y.Left != null)
        y.Count += y.Left.Count;
      if (y.Right != null)
        y.Count += y.Right.Count;
    }
  }

  private BstNode Minimum(BstNode x)
  {
    while (x.Left != null)
      x = x.Left;
    return x;
  }

  private void Transplant(BstNode u, BstNode v)
  {
    if (u.Parent == null)
      root = v;
    else if (u == u.Parent.Left)
      u.Parent.Left = v;
    else
      u.Parent.Right = v;
    if (v != null)
      v.Parent = u.Parent;
  }

  private class BstNode
  {
    public BstNode Parent;
    public BstNode Left;
    public BstNode Right;
    public long Value;
    public int Count;

    public BstNode(long[] sorted, int l, int r, BstNode parent)
    {
      Parent = parent;
      if (l < r)
      {
        var m = l + (r - l) / 2;
        Value = sorted[m];
        Count = r - l + 1;
        if (l < m)
          Left = new BstNode(sorted, l, m - 1, this);
        if (m < r)
          Right = new BstNode(sorted, m + 1, r, this);
      }
      else
      {
        Value = sorted[l];
        Count = 1;
      }
    }
  }
}
