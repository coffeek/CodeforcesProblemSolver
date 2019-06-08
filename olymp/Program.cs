using System;
using System.Globalization;
using System.IO;
using System.Text;
using static System.Console;

namespace Olymp
{
  public class ProblemSolver
  {
    private readonly Tokenizer input;

    public void Solve()
    {
    }

    public ProblemSolver(TextReader input)
    {
      this.input = new Tokenizer(input);
    }
  }

  #region Service classes

  public class Tokenizer
  {
    private TextReader reader;

    public string ReadToEnd()
    {
      return reader.ReadToEnd();
    }

    public int ReadInt()
    {
      var c = SkipWS();
      if (c == -1)
        throw new EndOfStreamException();
      var isNegative = false;
      if (c == '-' || c == '+')
      {
        isNegative = c == '-';
        c = reader.Read();
        if (c == -1)
          throw new EndOfStreamException("Digit expected, but end of stream occurs");
      }
      if (!char.IsDigit((char)c))
        throw new InvalidOperationException($"Digit expected, but was: '{(char)c}'");
      var result = (char)c - '0';
      c = reader.Read();
      while (c > 0 && !char.IsWhiteSpace((char)c))
      {
        if (!char.IsDigit((char)c))
          throw new InvalidOperationException($"Digit expected, but was: '{(char)c}'");
        result = result * 10 + (char)c - '0';
        c = reader.Read();
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
      return long.Parse(ReadToken());
    }

    public double ReadDouble()
    {
      return double.Parse(ReadToken(), CultureInfo.InvariantCulture);
    }

    public int[] ReadIntArray(int n)
    {
      var a = new int[n];
      for (var i = 0; i < n; i++)
        a[i] = ReadInt();
      return a;
    }

    public (int, int) Read2Int() =>
      (ReadInt(), ReadInt());

    public (int, int, int) Read3Int() =>
      (ReadInt(), ReadInt(), ReadInt());

    public (int, int, int, int) Read4Int() =>
      (ReadInt(), ReadInt(), ReadInt(), ReadInt());

    public long[] ReadLongArray(int n)
    {
      var a = new long[n];
      for (var i = 0; i < n; i++)
        a[i] = ReadLong();
      return a;
    }

    public double[] ReadDoubleArray(int n)
    {
      var a = new double[n];
      for (var i = 0; i < n; i++)
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
        c = reader.Read();
      }
      return sb.ToString();
    }

    private int SkipWS()
    {
      var c = reader.Read();
      if (c == -1)
        return c;
      while (c > 0 && char.IsWhiteSpace((char)c))
        c = reader.Read();
      return c;
    }

    public Tokenizer(TextReader reader)
    {
      this.reader = reader;
    }
  }

  internal class Program
  {
    public static void Main(string[] args)
    {
      var solver = new ProblemSolver(In);
      solver.Solve();
    }
  }

  #endregion
}
