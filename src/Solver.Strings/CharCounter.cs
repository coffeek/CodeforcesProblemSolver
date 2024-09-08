namespace Solver.Strings;

public class CharCounter
{
  private readonly int[] count = new int['z' - 'a' + 1];
  private int distinct;

  public int DistinctCount => distinct;
  public int GetCount(char c) => count[c - 'a'];

  public void Add(char c)
  {
    if (count[c - 'a']++ == 0)
      distinct++;
  }

  public void Add(ReadOnlySpan<char> s)
  {
    for (int i = 0; i < s.Length; i++)
      Add(s[i]);
  }

  public void Remove(char c)
  {
    var i = c - 'a';
    if (count[i] == 0)
      return;
    if (--count[i] == 0)
      distinct--;
  }
}
