using System;
using System.Linq;

namespace Solver.Sequences;

public static class LisAlgorithms
{
  /// <summary>
  /// Return the length of the longest strictly increasing subsequence.
  /// </summary>
  public static int LengthOfLis(int[] numbers)
  {
    if (numbers is null || numbers.Length == 0)
      return 0;

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

  /// <summary>
  /// Return the number of longest increasing subsequences.
  /// </summary>
  public static int FindNumberOfLis(int[] numbers)
  {
    if (numbers is null || numbers.Length == 0)
      return 0;

    var n = numbers.Length;
    var length = new int[n];
    var count = new int[n];
    Array.Fill(length, 1);
    Array.Fill(count, 1);
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        if (numbers[j] < numbers[i])
        {
          if (length[j] + 1 > length[i])
          {
            length[i] = Math.Max(length[i], length[j] + 1);
            count[i] = 0;
          }
          if (length[j] + 1 == length[i])
            count[i] += count[j];
        }
      }
    }
    var maxLength = length.Max();
    var numberOfLis = 0;
    for (var i = 0; i < n; i++)
    {
      if (length[i] == maxLength)
        numberOfLis += count[i];
    }
    return numberOfLis;
  }
}
