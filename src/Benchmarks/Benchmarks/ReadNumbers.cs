using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class ReadIntArray
{
  private const int N = 10000;
  private readonly string data;

  public ReadIntArray()
  {
    var r = new Random();
    data = string.Join(" ", Enumerable.Range(0, N).Select(i => r.Next()));
  }

  [Benchmark]
  public int[] Tokenizer()
  {
    var t = new Tokenizer(new StringReader(data));
    return t.ReadIntArray(N);
  }
    
  [Benchmark]
  public int[] FastTokenizer()
  {
    var t = new FastTokenizer(new StringReader(data));
    return t.ReadIntArray(N);
  }
}
  
[MemoryDiagnoser]
public class ReadLongArray
{
  private const int N = 10000;
  private readonly string data;

  public ReadLongArray()
  {
    var r = new Random();
    var b = new byte[sizeof(long)];
    data = string.Join(" ", Enumerable.Range(0, N).Select(_ =>
    {
      r.NextBytes(b);
      var k = 0ul;
      for (int i = 0; i < b.Length; i++)
        k &= (ulong)b[i] << (8 * i);
      return (long)k;
    }));
  }

  [Benchmark]
  public long[] Tokenizer()
  {
    var t = new Tokenizer(new StringReader(data));
    return t.ReadLongArray(N);
  }
    
  [Benchmark]
  public long[] FastTokenizer()
  {
    var t = new FastTokenizer(new StringReader(data));
    return t.ReadLongArray(N);
  }
}
  
[MemoryDiagnoser]
public class ReadDoubleArray
{
  private const int N = 10000;
  private readonly string data;

  public ReadDoubleArray()
  {
    var r = new Random();
    data = string.Join(" ", Enumerable.Range(0, N).Select(i => r.NextDouble()));
  }

  [Benchmark]
  public double[] Tokenizer()
  {
    var t = new Tokenizer(new StringReader(data));
    return t.ReadDoubleArray(N);
  }
    
  [Benchmark]
  public double[] FastTokenizer()
  {
    var t = new FastTokenizer(new StringReader(data));
    return t.ReadDoubleArray(N);
  }
}
  
public class Tokenizer
{
  private readonly TextReader reader;
    
  public int ReadInt() => int.Parse(ReadToken());

  public long ReadLong() => long.Parse(ReadToken());

  public double ReadDouble() => double.Parse(ReadToken(), CultureInfo.InvariantCulture);

  public int[] ReadIntArray(int n) => ReadArray(n, ReadInt);

  public long[] ReadLongArray(int n) => ReadArray(n, ReadLong);

  public double[] ReadDoubleArray(int n) => ReadArray(n, ReadDouble);

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
  
public class FastTokenizer
{
  private readonly TextReader reader;

  private readonly char[] numBuffer = new char[50];

  public int ReadInt() => int.Parse(ReadToken(numBuffer));

  public long ReadLong() => long.Parse(ReadToken(numBuffer));

  public int[] ReadIntArray(int n) => ReadArray(n, ReadInt);

  public long[] ReadLongArray(int n) => ReadArray(n, ReadLong);
    
  public double ReadDouble() => double.Parse(ReadToken(numBuffer), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

  public double[] ReadDoubleArray(int n) => ReadArray(n, ReadDouble);
    
  public ReadOnlySpan<char> ReadToken(Span<char> buffer)
  {
    var c = SkipWs();
    if (c == -1)
      return null;
    var pos = 0;
    while (c > 0 && !char.IsWhiteSpace((char)c))
    {
      buffer[pos++] = (char)c;
      c = reader.Read();
    }
    return buffer[..pos];
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

  public FastTokenizer(TextReader reader)
  {
    this.reader = reader;
  }
}
