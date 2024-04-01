using System;
using System.Linq;
using Solver.Utils;

namespace Solver.Strings;

public static class Functions
{
  public static bool IsPalindrome(string s)
  {
    var n = s.Length;
    for (int i = 0; i < n / 2; i++)
    {
      if (s[i] != s[n - i - 1])
        return false;
    }
    return true;
  }

  public static string LongestPalindrome(string s)
  {
    if (s.Length == 0)
      return string.Empty;
    var result = s.AsSpan(0, 1);
    var n = s.Length;
    for (var i = 1; i < n - 1; i++)
    {
      int l = i - 1, r = i + 1;
      for (; l >= 0 && r < n && s[l] == s[r]; l--, r++) { }
      if (result.Length < r - l - 1)
        result = s.AsSpan(l + 1, r - l - 1);
    }
    for (var i = 0; i < n - 1; i++)
    {
      int l = i, r = i + 1;
      for (; l >= 0 && r < n && s[l] == s[r]; l--, r++) { }
      if (result.Length < r - l - 1)
        result = s.AsSpan(l + 1, r - l - 1);
    }
    return result.ToString();
  }

  public static string FastIntJoin(string sep, int[] data)
  {
    if (data.Length == 0)
      return string.Empty;

    int Len(int k)
    {
      var len = Numbers.FastDigitsCount(k);
      return k < 0 ? len + 1 : len;
    }

    int Write(int k, Span<char> s)
    {
      var n = Len(k);
      if (k < 0)
      {
        s[0] = '-';
        k = -k;
      }
      int i = n - 1;
      do
      {
        var d = k % 10;
        s[i] = (char)(d + '0');
        i--;
        k /= 10;
      }
      while (k != 0);

      return n;
    }

    var n = data.Sum(Len) + sep.Length * (data.Length - 1);

    return string.Create<object>(n, null, (s, _) =>
    {
      var ss = sep.AsSpan();
      var pos = 0;
      for (int i = 0; i < data.Length; i++)
      {
        pos += Write(data[i], s[pos..]);
        if (i != data.Length - 1 && sep.Length != 0)
        {
          ss.CopyTo(s[pos..]);
          pos += sep.Length;
        }
      }
    });
  }
}
