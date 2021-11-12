using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
  public class FillArray
  {
    [Params(10, 1000, 100000)]
    public int N { get; set; }

    private int[] data;
    private int value;
    private readonly Random random = new Random();
    
    [GlobalSetup]
    public void Setup()
    {
      data = new int[N];
      value = random.Next();
    }
    
    [Benchmark]
    public int[] ArrayFill()
    {
      Array.Fill(data, value);
      return data;
    }

    [Benchmark]
    public int[] SpanFill()
    {
      data.AsSpan().Fill(value);
      return data;
    }
  }
}
