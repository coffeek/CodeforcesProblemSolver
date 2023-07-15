using System.Linq;

namespace Solver.DataStructures.SegmentTree;

public class UniqueCharCounter
{
  private readonly SegmentTree<int> t;

  public int GetCount(int l, int r)
  {
    var c = t.Query(l, r);
    var result = 0;
    while (c != 0)
    {
      result += c & 1;
      c >>= 1;
    }
    return result;
  }

  private static int GetValue(char c) => 1 << (c - 'a');

  public void Update(int pos, char c)
  {
    t.Update(pos, GetValue(c));
  }

  public UniqueCharCounter(string s)
  {
    t = new SegmentTree<int>(s.Select(GetValue).ToArray(), (x, y) => x | y);
  }
}
