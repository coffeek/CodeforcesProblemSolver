namespace Olymp.DataStructures
{
  public class Bit
  {
    private readonly int n;
    private readonly int[] bit;

    public int Sum(int r)
    {
      int ret = 0;
      for (; r >= 0; r = (r & (r + 1)) - 1)
        ret += bit[r];
      return ret;
    }

    public int Sum(int l, int r)
    {
      return Sum(r) - Sum(l - 1);
    }

    public void Add(int index, int value)
    {
      for (; index < n; index |= (index + 1))
        bit[index] += value;
    }

    public Bit(int n)
    {
      this.n = n;
      bit = new int[n];
    }

    public Bit(int[] a) : this(a.Length)
    {
      for (int i = 0; i < a.Length; i++)
        Add(i, a[i]);
    }
  }
}
