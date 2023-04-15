using System;
using BenchmarkDotNet.Attributes;
using Solver.Utils;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class JoinIntegersBenchmark
{
  private const int N = 10000;
  private readonly int[] data;
  private const string Separator = " ";

  public JoinIntegersBenchmark()
  {
    data = new int[N];
    for (int i = 0; i < N; i++)
      data[i] = i % 2 == 0 ? -i : i;
  }

  [Benchmark(Baseline = true)]
  public string StringJoin()
  {
    return string.Join(Separator, data);
  }

  [Benchmark]
  public string FastIntJoin()
  {
    return Strings.FastIntJoin(Separator, data);
  }
}

public class GetDigitsCount
{
  private readonly int n;

  public GetDigitsCount()
  {
    n = new Random().Next();
  }

  [Benchmark(Baseline = true)]
  public int SimpleLoop()
  {
    var k = n;
    var ans = k < 0 ? 1 : 0;
    do
    {
      ans++;
      k /= 10;
    }
    while (k != 0);
    return ans;
  }

  [Benchmark]
  public int DigitsCount()
  {
    return Numbers.DigitsCount(n);
  }

  [Benchmark]
  public int FastDigitsCount()
  {
    return Numbers.FastDigitsCount(n);
  }
}
