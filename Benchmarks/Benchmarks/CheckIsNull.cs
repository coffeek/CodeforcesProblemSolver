using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
  public class CheckIsNull
  {
    private const int N = 100000;
    private readonly MyClass[] data;

    private class MyClass
    {
      public int Property { get; set; }
    }

    public CheckIsNull()
    {
      var random = new Random();
      data = new MyClass[N];
      for (int i = 0; i < N; i++)
      {
        if (random.Next() % 3 == 0)
          data[i] = new MyClass { Property = random.Next() };
      }
    }

    [Benchmark]
    public long IsNull()
    {
      var s = 0L;
      for (int i = 0; i < N; i++)
      {
        if (data[i] is null)
          continue;
        s += data[i].Property;
      }
      return s;
    }

    [Benchmark]
    public long NotEqualNull()
    {
      var s = 0L;
      for (int i = 0; i < N; i++)
      {
        if (data[i] != null)
          s += data[i].Property;
      }
      return s;
    }

    [Benchmark]
    public long PatternMatching()
    {
      var s = 0L;
      for (int i = 0; i < N; i++)
      {
        if (data[i] is { } d)
          s += d.Property;
      }
      return s;
    }
  }
}
