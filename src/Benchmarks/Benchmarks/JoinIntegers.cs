using BenchmarkDotNet.Attributes;
using Solver.Strings;

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
    return Functions.FastIntJoin(Separator, data);
  }
}
