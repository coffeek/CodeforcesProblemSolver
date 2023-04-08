using System;
using System.Collections.Generic;
using System.Linq;

namespace Olymp.Utils;

public static class Numbers
{
  public static int FastDigitsCount(int n)
  {
    if (n == int.MinValue)
      return 10;
    if (n < 0)
      n = -n;
    if (n < 100000)
    {
      if (n < 100)
        return n < 10 ? 1 : 2;
      if (n < 1000)
        return 3;
      return n < 10000 ? 4 : 5;
    }
    if (n < 10000000)
      return n < 1000000 ? 6 : 7;
    if (n < 100000000)
      return 8;
    return n < 1000000000 ? 9 : 10;
  }

  public static int DigitsCount(int n)
  {
    if (n == int.MinValue)
      return 10;
    if (n < 0)
      n = -n;
    return n == 0 ? 1 : (int)Math.Log10(n) + 1;
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

  public static bool Odd(int x) => (x & 1) != 0;
  
  public static bool Even(int x) => (x & 1) == 0;
  
  public static bool Odd(long x) => (x & 1) != 0;
  
  public static bool Even(long x) => (x & 1) == 0;

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
}
