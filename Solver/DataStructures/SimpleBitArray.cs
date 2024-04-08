namespace Solver.DataStructures;

/// <summary>
/// Simple bit array without index checking.
/// </summary>
public class SimpleBitArray
{
  private readonly int[] data;

  public bool this[int index]
  {
    get
    {
      var i = index >> 5;
      var j = index & 31;
      return (data[i] & (1 << j)) != 0;
    }
    set
    {
      var i = index >> 5;
      var j = index & 31;
      if (value)
        data[i] |= 1 << j;
      else
        data[i] &= ~(1 << j);
    }
  }

  public override string ToString()
  {
    return string.Join(" ", data.Select(i => Convert.ToString(i, 2)));
  }

  public SimpleBitArray(int n)
  {
    data = new int[(n + 31) >> 5];
  }

  public SimpleBitArray(int n, bool initValue)
    : this(n)
  {
    if (initValue)
      Array.Fill(data, -1);
  }
}
