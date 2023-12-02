using System;
using System.Numerics;

namespace Solver.Utils;

public static class Bitmasks
{
  /// <summary>
  /// Number of 1 Bits.
  /// </summary>
  public static int HammingWeight(uint n)
  {
    int count = 0;
    while (n != 0)
    {
      n &= (n - 1);
      count++;
    }
    return count;
  }

  /// <summary>
  /// Number of 1 Bits.
  /// </summary>
  public static int HammingWeight2(uint n)
  {
    return BitOperations.PopCount(n);
  }

  public static uint ReverseBits(uint n)
  {
    uint result = 0;
    for (var i = 0; i < 32; i++)
    {
      result = (result << 1) | (n & 1);
      n >>= 1;
    }
    return result;
  }

  public static uint ReverseBits2(UInt32 n)
  {
    n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
    n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
    n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
    n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
    n = ((n & 0xffff0000) >> 16) | ((n & 0x0000ffff) << 16);
    return n;
  }

  public static uint LargestPower(uint n)
  {
    const uint maxPow = 1u << 31;
    if ((n & maxPow) != 0)
      return maxPow;
    // Fill trailing zeros with ones, eg 00010010 becomes 00011111.
    n |= (n >> 1);
    n |= (n >> 2);
    n |= (n >> 4);
    n |= (n >> 8);
    n |= (n >> 16);
    return (n + 1) >> 1;
  }

  public static uint LargestPower2(uint n)
  {
    return n == 0 ? 0 : 1u << BitOperations.Log2(n);
  }
  
  /// <remarks>Same as <see cref="BitOperations.IsPow2(int)"/></remarks>
  public static bool IsPowerOfTwo(int n)
  {
    return n > 0 && (n & (n - 1)) == 0;
  }

  public static bool IsPowerOfFour(int n)
  {
    return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
  }
}
