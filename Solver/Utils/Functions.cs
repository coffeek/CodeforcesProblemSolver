using System;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Utils;

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

  public static (int m1, int m2) Find2Max(Span<int> a)
  {
    var m1 = int.MinValue;
    var m2 = int.MinValue;
    for (int i = 0; i < a.Length; i++)
    {
      if (a[i] >= m1)
      {
        m2 = m1;
        m1 = a[i];
      }
      else if (a[i] > m2)
      {
        m2 = a[i];
      }
    }
    return (m1, m2);
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
}
