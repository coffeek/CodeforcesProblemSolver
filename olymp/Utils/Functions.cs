using System;
using System.Collections.Generic;
using System.Linq;

namespace Olymp.Utils
{
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

    public static int IncCount<T>(IDictionary<T, int> counter, T item)
    {
      if (counter.TryGetValue(item, out var count))
        return (counter[item] = count + 1);
      counter.Add(item, 1);
      return 1;
    }

    public static void DecCount<T>(IDictionary<T, int> counter, T item)
    {
      if (counter.TryGetValue(item, out var count))
      {
        if (count == 1)
          counter.Remove(item);
        else
          counter[item] = count - 1;
      }
    }

    public static int GetCount<T>(IDictionary<T, int> counter, T item)
    {
      return counter.TryGetValue(item, out var count) ? count : 0;
    }

    public static Dictionary<T, int> Counts<T>(params T[] a)
    {
      var c = new Dictionary<T, int>();
      foreach (var t in a)
        IncCount(c, t);
      return c;
    }

    public static int Gcd(params int[] values)
    {
      return values.Length switch
      {
        0 => 0,
        1 => values[0],
        _ => values.Aggregate(Gcd)
      };
    }

    public static int Gcd(int a, int b)
    {
      if (a <= 0 || b <= 0)
        return 0;
      while (b != 0)
      {
        a %= b;
        (b, a) = (a, b);
      }
      return a;
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

    public static bool Odd(int x) => x % 2 == 1;

    public static bool Even(int x) => x % 2 == 0;

    public static bool Odd(long x) => x % 2 == 1;

    public static bool Even(long x) => x % 2 == 0;

    public static bool IsPrime(int x)
    {
      if (x < 2)
        return false;
      for (var i = 2; i * i <= x; i++)
      {
        if (x % i == 0)
          return false;
      }
      return true;
    }

    /// <summary>
    /// Вернуть список простых делителей числа.
    /// Если число простое, функция вернет само число.
    /// Делители могут повторяться (для 1024 вернет 10 двоек).
    /// </summary>
    public static List<int> PrimeDivisors(int number)
    {
      var p = new List<int>();
      var q = number;
      for (var i = 2; i * i <= number; i++)
      {
        while (q % i == 0)
        {
          p.Add(i);
          q /= i;
        }
      }
      if (q > 1)
        p.Add(q);
      return p;
    }

    public static bool IsVovel(char c) => "aeiouy".Contains(c);

    public static int[] ToBase(long n, int b)
    {
      if (n <= 0)
        return new[] { 0 };
      var s = new int[64];
      while (n != 0)
      {
        int i = 0;
        long d = 1;
        while (b * d <= n)
        {
          d *= b;
          i++;
        }
        var k = n / d;
        s[i] += (int)k;
        n -= d * k;
      }
      return s.Reverse().SkipWhile(d => d == 0).ToArray();
    }

    public static long ToLong(int[] n, int b)
    {
      long val = 0;
      long mul = 1;
      foreach (var d in n.Reverse())
      {
        val += mul * d;
        mul *= b;
      }
      return val;
    }

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
}
