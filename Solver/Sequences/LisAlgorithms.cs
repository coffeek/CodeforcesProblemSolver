using System;
using System.Linq;

namespace Solver.Sequences;

public static class LisAlgorithms
{
  /// <summary>
  /// return the length of the longest strictly increasing subsequence.
  /// </summary>
  public static int LengthOfLis(int[] numbers)
  {
    var n = numbers.Length;
    var length = new int[n];
    Array.Fill(length, 1);
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        if (numbers[j] < numbers[i])
          length[i] = Math.Max(length[i], length[j] + 1);
      }
    }
    return length.Max();
  }
}
