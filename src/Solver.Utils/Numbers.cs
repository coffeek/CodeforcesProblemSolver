using System.Diagnostics.CodeAnalysis;
using Solver.DataStructures;

namespace Solver.Utils;

public static class Numbers
{
  [SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
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

  public static bool IsSquare(int n)
  {
    if (n < 0)
      return false;
    var sqrt = (int)Math.Sqrt(n);
    return sqrt * sqrt == n;
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
      (b, a) = (a % b, b);
    return a;
  }

  public static int Lcm(int a, int b)
  {
    return a * (b / Gcd(a, b));
  }

  public static int Lcm(params int[] values)
  {
    return values.Length switch
    {
      0 => 0,
      1 => values[0],
      _ => values.Aggregate(Lcm)
    };
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
  /// Sieve of Eratosthenes.
  /// </summary>
  public static IReadOnlyList<int> Sieve(int n)
  {
    if (n < 2)
      return Array.Empty<int>();
    var p = new bool[n + 1];
    Array.Fill(p, true);
    p[0] = p[1] = false;
    for (int i = 2; i * i <= n; i++)
    {
      if (p[i])
      {
        for (int j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }
    var result = new List<int>();
    for (int i = 2; i < n + 1; i++)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (via a bit array).
  /// </summary>
  public static IReadOnlyList<int> BitSieve(int n)
  {
    if (n < 2)
      return Array.Empty<int>();
    var p = new SimpleBitArray(n + 1, true);
    p[0] = p[1] = false;
    for (int i = 2; i * i <= n; i++)
    {
      if (p[i])
      {
        for (int j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }
    var result = new List<int>();
    for (int i = 2; i < n + 1; i++)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (30% faster).
  /// </summary>
  public static IReadOnlyList<int> EnhancedSieve(int n)
  {
    if (n < 2)
      return Array.Empty<int>();
    var p = new bool[n + 1];
    Array.Fill(p, true);
    for (int i = 3; i * i <= n; i += 2)
    {
      if (p[i])
      {
        for (var j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }
    var result = new List<int> { 2 };
    for (int i = 3; i <= n; i += 2)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (with linear complexity).
  /// </summary>
  public static IReadOnlyList<int> LinearSieve(int n)
  {
    var lp = new int[n + 1];
    var pr = new List<int>();
    for (int i = 2; i <= n; ++i)
    {
      if (lp[i] == 0)
      {
        lp[i] = i;
        pr.Add(i);
      }
      for (int j = 0; j < pr.Count && pr[j] <= lp[i] && i * pr[j] <= n; j++)
      {
        lp[i * pr[j]] = pr[j];
      }
    }
    return pr;
  }

  /// <summary>
  /// Euler's totient function.
  /// https://en.wikipedia.org/wiki/Euler%27s_totient_function
  /// </summary>
  public static int Phi(int n)
  {
    var result = n;
    for (var i = 2; i * i <= n; i++)
    {
      if (n % i == 0)
      {
        do { n /= i; }
        while (n % i == 0);
        result -= result / i;
      }
    }
    if (n > 1)
      result -= result / n;
    return result;
  }

  public static List<int> Factorize(int n)
  {
    var p = new List<int>();
    for (var i = 2; i * i <= n; i++)
    {
      while (n % i == 0)
      {
        p.Add(i);
        n /= i;
      }
    }
    if (n > 1)
      p.Add(n);
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

  public static long BinPow(long a, int n)
  {
    long res = 1;
    while (n != 0)
    {
      if ((n & 1) != 0)
        res *= a;
      a *= a;
      n >>= 1;
    }
    return res;
  }

  public static long BinMul(long x, long y, long mod)
  {
    if (x == 0 || y == 0)
      return 0;
    long res = 0;
    while (y != 0)
    {
      if ((y & 1) != 0)
        res = (res + x) % mod;
      x = (x + x) % mod;
      y >>= 1;
    }
    return res;
  }

  public static long BinPow(long a, long n, long mod)
  {
    long res = 1;
    while (n != 0)
    {
      if ((n & 1) != 0)
        res = BinMul(res, a, mod);
      a = BinMul(a, a, mod);
      n >>= 1;
    }
    return res;
  }

  public static int BinPow(int a, int n, int mod)
  {
    int res = 1;
    while (n != 0)
    {
      if ((n & 1) != 0)
        res = (int)(((long)res * a) % mod);
      a = (int)(((long)a * a) % mod);
      n >>= 1;
    }
    return res;
  }

  public static int CeilDiv(int value, int div)
  {
    return (value + div - 1) / div;
  }
  
  /// <summary>
  /// Digital root of number (https://en.wikipedia.org/wiki/Digital_root).
  /// </summary>
  /// <remarks>
  /// Iterative process of summing digits, on each iteration using the result from
  /// the previous iteration to compute a digit sum. The process continues until a single-digit
  /// number is reached.
  /// This is O(1) time implementation.
  /// </remarks>
  public static int DigitalRoot(int n)
  {
    if (n == 0)
      return 0;
    if (n % 9 == 0)
      return 9;
    return n % 9;
  }
}
