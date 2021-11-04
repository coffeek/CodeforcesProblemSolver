using System;
using static System.Math;

namespace Olymp.Utils
{
  public static class StringUtils
  {
    public static int[] ZFunc(string s)
    {
      if (s.Length == 0)
        return Array.Empty<int>();
      int n = s.Length;
      var z = new int[n];
      var l = 0;
      var r = 0;
      for (int i = 1; i < n; ++i)
      {
        if (i <= r)
          z[i] = Min(r - i + 1, z[i - l]);
        while (i + z[i] < n && s[z[i]] == s[i + z[i]])
          ++z[i];
        if (i + z[i] - 1 > r)
        {
          l = i;
          r = i + z[i] - 1;
        }
      }
      return z;
    }

    public static int ZMatch(string str, string substr)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr) || str.Length < substr.Length)
        return -1;
      var s = substr + '\0' + str;
      int n = s.Length;
      var m = substr.Length;
      var z = new int[n];
      var l = 0;
      var r = 0;
      for (int i = 1; i < n; ++i)
      {
        if (i <= r)
          z[i] = Min(r - i + 1, z[i - l]);
        while (i + z[i] < n && s[z[i]] == s[i + z[i]])
          ++z[i];
        if (z[i] == m)
          return i - m - 1;
        if (i + z[i] - 1 > r)
        {
          l = i;
          r = i + z[i] - 1;
        }
      }
      return -1;
    }

    public static int[] PiFunc(string s)
    {
      if (s.Length == 0)
        return Array.Empty<int>();
      var n = s.Length;
      var pi = new int[n];
      pi[0] = 0;
      var k = 0;
      for (int i = 1; i < n; i++)
      {
        while (k != 0 && s[k] != s[i])
          k = pi[k - 1];
        if (s[k] == s[i])
          k++;
        pi[i] = k;
      }
      return pi;
    }

    public static int KmpMatch(string str, string substr)
    {
      if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr) || str.Length < substr.Length)
        return -1;
      var n = str.Length;
      var m = substr.Length;
      var pi = PiFunc(substr);
      var q = 0;
      for (int i = 0; i < n; i++)
      {
        while (q > 0 && substr[q] != str[i])
          q = pi[q - 1];
        if (substr[q] == str[i])
          ++q;
        if (q == m)
          return i - m + 1;
      }
      return -1;
    }
    
    public static string FastIntJoin(string sep, int[] data)
    {
      if (data.Length == 0)
        return string.Empty;
      
      int Len(int k) => k >= 0 ? Numbers.GetDigitsCount(k) : Numbers.GetDigitsCount(-k) + 1;

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

      var n = 0;
      for (int i = 0; i < data.Length; i++)
        n += Len(data[i]);
      n += sep.Length * (data.Length - 1);

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
}
