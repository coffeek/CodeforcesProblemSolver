using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Solver.Utils;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class Eratosthenes
{
  [Params(1000, 1000000)]
  public int N { get; set; }
  
  [Benchmark(Baseline = true)]
  public IReadOnlyList<int> Sieve()
  {
    return Numbers.Sieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> BitSieve()
  {
    return Numbers.BitSieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> EnhancedSieve()
  {
    return Numbers.EnhancedSieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> LinearSieve()
  {
    return Numbers.LinearSieve(N);
  }
}
