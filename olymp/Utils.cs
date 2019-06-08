using System;
using System.Collections.Generic;

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
  }
}