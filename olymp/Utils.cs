using System;
using System.Collections.Generic;
using System.Linq;

namespace Olymp
{
  public class Utils
  {
    public static int IncCount<T>(Dictionary<T, int> counter, T item)
    {
      if (counter.TryGetValue(item, out var count))
        return (counter[item] = count + 1);
      counter.Add(item, 1);
      return 1;
    }

    public static void DecCount<T>(Dictionary<T, int> counter, T item)
    {
      if (counter.TryGetValue(item, out var count))
      {
        if (count == 1)
          counter.Remove(item);
        else
          counter[item] = count - 1;
      }
    }

    public static int GetCount<T>(Dictionary<T, int> counter, T item)
    {
      return counter.TryGetValue(item, out var count) ? count : 0;
    }

    public static int GCD(int a, int b)
    {
      while (b != 0)
      {
        a %= b;
        var t = b;
        b = a;
        a = t;
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
          Swap(ref a[i], ref a[j]);
          Permute(a, i + 1, n, process);
          Swap(ref a[i], ref a[j]);
        }
      }
    }

    public static void Swap<T>(ref T a, ref T b)
    {
      T t;
      t = a;
      a = b;
      b = t;
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
      using (var e = a.GetEnumerator())
      {
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
  }
}
