using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Array;
using static System.Console;
using static System.Math;

namespace Solver;

public class ProblemSolver
{
  private readonly Tokenizer input;
  private readonly TextWriter output;

  private void SolveCase()
  {
  }

  public void Solve()
  {
    var t = input.ReadInt();
    for (int _ = 0; _ < t; _++)
      SolveCase();
  }

  public ProblemSolver(TextReader input, TextWriter output)
  {
    this.input = new Tokenizer(input);
    this.output = output;
  }
}

#region Service classes

public class Tokenizer
{
  private readonly TextReader reader;
  private readonly char[] numBuffer = new char[50];

  public string ReadToEnd() => reader.ReadToEnd();

  public string ReadLine() => reader.ReadLine();

  public int ReadInt() => int.Parse(ReadToken(numBuffer));

  public long ReadLong() => long.Parse(ReadToken(numBuffer));

  public double ReadDouble() => double.Parse(ReadToken(numBuffer), NumberStyles.Float | NumberStyles.AllowThousands,
    CultureInfo.InvariantCulture);

  public (int, int) Read2Int() => (ReadInt(), ReadInt());

  public (int, int, int) Read3Int() => (ReadInt(), ReadInt(), ReadInt());

  public (int, int, int, int) Read4Int() => (ReadInt(), ReadInt(), ReadInt(), ReadInt());

  public (long, long) Read2Long() => (ReadLong(), ReadLong());

  public int[] ReadIntArray(int n) => ReadArray(n, ReadInt);

  public long[] ReadLongArray(int n) => ReadArray(n, ReadLong);

  public double[] ReadDoubleArray(int n) => ReadArray(n, ReadDouble);

  public ReadOnlySpan<char> ReadToken(Span<char> buffer)
  {
    var c = SkipWs();
    var pos = 0;
    while (c > 0 && !char.IsWhiteSpace((char)c))
    {
      buffer[pos++] = (char)c;
      c = reader.Read();
    }
    return buffer[..pos];
  }

  public string ReadToken()
  {
    var c = SkipWs();
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

  private static T[] ReadArray<T>(int n, Func<T> reader)
  {
    var a = new T[n];
    for (var i = 0; i < n; i++)
      a[i] = reader();
    return a;
  }

  private int SkipWs()
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

internal static class Program
{
  public static void Main()
  {
    using var reader = new StreamReader(OpenStandardInput(), Encoding.ASCII, false);
    using var writer = new StreamWriter(OpenStandardOutput(), Encoding.ASCII);
    new ProblemSolver(reader, writer).Solve();
  }
}

#endregion
