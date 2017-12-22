using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;

namespace Olymp
{
  public class ProblemSolver
  {
    private Tokenizer input;

    public void Solve()
    {
      
    }

    public ProblemSolver(TextReader input)
    {
      this.input = new Tokenizer(input);
    }

    #region Service functions

    private static void AddCount<T>(Dictionary<T, int> counter, T item)
    {
      int count;
      if (counter.TryGetValue(item, out count))
        counter[item] = count + 1;
      else
        counter.Add(item, 1);
    }

    private static int GetCount<T>(Dictionary<T, int> counter, T item)
    {
      int count;
      return counter.TryGetValue(item, out count) ? count : 0;
    }

    private static int GCD(int a, int b)
    {
      while (b != 0)
      {
        a %= b;
        int t = b;
        b = a;
        a = t;
      }
      return a;
    }

    #endregion
  }

  #region Service classes

  public class Tokenizer
  {
    private TextReader reader;

    public string ReadToEnd()
    {
      return this.reader.ReadToEnd();
    }

    public int ReadInt()
    {
      var c = SkipWS();
      if (c == -1)
        throw new EndOfStreamException();
      bool isNegative = false;
      if (c == '-' || c == '+')
      {
        isNegative = c == '-';
        c = this.reader.Read();
        if (c == -1)
          throw new InvalidOperationException();
      }
      if (!char.IsDigit((char)c))
        throw new InvalidOperationException();
      int result = (char)c - '0';
      c = this.reader.Read();
      while (c > 0 && !char.IsWhiteSpace((char)c))
      {
        if (!char.IsDigit((char)c))
          throw new InvalidOperationException();
        result = result * 10 + (char)c - '0';
        c = this.reader.Read();
      }
      if (isNegative)
        result = -result;
      return result;
    }

    public string ReadLine()
    {
      return reader.ReadLine();
    }

    public long ReadLong()
    {
      return long.Parse(this.ReadToken());
    }

    public double ReadDouble()
    {
      return double.Parse(this.ReadToken(), CultureInfo.InvariantCulture);
    }

    public int[] ReadIntArray(int n)
    {
      int[] a = new int[n];
      for (int i = 0; i < n; i++)
        a[i] = ReadInt();
      return a;
    }

    public long[] ReadLongArray(int n)
    {
      long[] a = new long[n];
      for (int i = 0; i < n; i++)
        a[i] = ReadLong();
      return a;
    }

    public double[] ReadDoubleArray(int n)
    {
      double[] a = new double[n];
      for (int i = 0; i < n; i++)
        a[i] = ReadDouble();
      return a;
    }

    public string ReadToken()
    {
      var c = SkipWS();
      if (c == -1)
        return null;
      var sb = new StringBuilder();
      while (c > 0 && !char.IsWhiteSpace((char)c))
      {
        sb.Append((char)c);
        c = this.reader.Read();
      }
      return sb.ToString();
    }

    private int SkipWS()
    {
      int c = this.reader.Read();
      if (c == -1)
        return c;
      while (c > 0 && char.IsWhiteSpace((char)c))
        c = this.reader.Read();
      return c;
    }

    public Tokenizer(TextReader reader)
    {
      this.reader = reader;
    }
  }

  class Program
  {
    public static void Main(string[] args)
    {
      var solver = new ProblemSolver(Console.In);
      solver.Solve();
    }
  }

  #endregion
}