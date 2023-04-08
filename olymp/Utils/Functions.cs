using System;
using System.Collections.Generic;
using System.Linq;

namespace Olymp.Utils;

public static class Functions
{
  public static int Min(params int[] values)
  {
    return values.Min();
  }

  public static int Max(params int[] values)
  {
    return values.Max();
  }

  public static void Permute<T>(T[] a, int i, int n, Action<T[]> process)
  {
    if (i == n - 1)
    {
      process(a);
    }
    else
    {
      for (var j = i; j < n; j++)
      {
        (a[i], a[j]) = (a[j], a[i]);
        Permute(a, i + 1, n, process);
        (a[i], a[j]) = (a[j], a[i]);
      }
    }
  }

  public static bool IsVovel(char c) => "aeiouy".Contains(c);

  public static IEnumerable<T> Compact<T>(IEnumerable<T> a) where T : IEquatable<T>
  {
    using var e = a.GetEnumerator();
    if (!e.MoveNext())
      yield break;
    var lastA = e.Current;
    while (e.MoveNext())
    {
      var val = e.Current;
      if (val.Equals(lastA))
        continue;
      yield return lastA;
      lastA = val;
    }
    yield return lastA;
  }

  public static int UpperBound(int[] a, int value)
  {
    return UpperBound(a, 0, a.Length, value);
  }

  private static int UpperBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] <= value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] <= value ? endIndex : l;
  }
}
