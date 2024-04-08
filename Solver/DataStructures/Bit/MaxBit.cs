namespace Solver.DataStructures.Bit;

/// <summary>
/// Binary indexed tree (Fenwick tree) for Max/Min operations.
/// </summary>
/// <remarks>
/// The Max() method can get the maximum only for the prefix [0;r].  
/// The Update() method can only increment the values.
/// </remarks>
public class MaxBit
{
  private readonly int[] bit; // 1-indexed.

  public int Max(int r)
  {
    var max = int.MinValue;
    // Bit is 1-indexed.
    for (r++; r > 0; r = Parent(r))
      max = Math.Max(max, bit[r]);
    return max;
  }

  /// <summary>
  /// Change value in array.
  /// Only increasing values allowed!
  /// </summary>
  public void Update(int index, int value)
  {
    // Bit is 1-indexed.
    for (index++; index < bit.Length; index = Next(index))
      bit[index] = Math.Max(bit[index], value);
  }

  /// <summary>
  /// Least significant 1-bit.
  /// </summary>
  private static int Lso(int n) => n & -n;

  private static int Parent(int i) => i - Lso(i);

  private static int Next(int i) => i + Lso(i);

  public MaxBit(int n) => bit = new int[n + 1];

  public MaxBit(int[] a) : this(a.Length)
  {
    for (var i = 0; i < a.Length; i++)
      Update(i, a[i]);
  }
}
