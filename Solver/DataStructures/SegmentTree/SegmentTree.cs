using static System.Math;

namespace Solver.DataStructures.SegmentTree;

public class SegmentTreeNode
{
  private readonly int l;
  private readonly int r;
  private int c;
  private readonly SegmentTreeNode left;
  private readonly SegmentTreeNode right;

  public void Set(int index, char value)
  {
    if (l == r)
    {
      c = 1 << (value - 'a');
    }
    else
    {
      if (index <= left.r)
        left.Set(index, value);
      else
        right.Set(index, value);
      c = left.c | right.c;
    }
  }

  public int GetUsedCharMask(int l, int r)
  {
    if (this.l == l && this.r == r)
      return c;

    var result = 0;
    if (l <= left.r)
      result |= left.GetUsedCharMask(l, Min(r, left.r));
    if (r >= right.l)
      result |= right.GetUsedCharMask(Max(l, right.l), r);

    return result;
  }

  public SegmentTreeNode(char[] s, int l, int r)
  {
    this.l = l;
    this.r = r;

    if (l != r)
    {
      var m = l + (r - l) / 2;
      left = new SegmentTreeNode(s, l, m);
      right = new SegmentTreeNode(s, m + 1, r);
    }

    for (int i = l; i <= r; i++)
      Set(i, s[i]);
  }
}

internal class SegmentTree
{
  private readonly SegmentTreeNode root;

  public void Set(int index, char value)
  {
    root.Set(index, value);
  }

  public int GetUniqueCharCount(int l, int r)
  {
    var c = root.GetUsedCharMask(l, r);
    var result = 0;
    while (c != 0)
    {
      result += c & 1;
      c >>= 1;
    }
    return result;
  }

  public SegmentTree(char[] s)
  {
    root = new SegmentTreeNode(s, 0, s.Length - 1);
  }
}