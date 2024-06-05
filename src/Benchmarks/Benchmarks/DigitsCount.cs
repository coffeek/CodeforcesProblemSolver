using BenchmarkDotNet.Attributes;
using Solver.Utils;

namespace Benchmarks.Benchmarks;

public class DigitsCount
{
  [Params(10, 9487, -10324, 5734821, 2137584383)]
  public int D { get; set; }
  
  [Benchmark(Baseline = true)]
  public int SimpleLoop()
  {
    var k = D;
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
  public int BaseDigitsCount()
  {
    return Numbers.DigitsCount(D);
  }
  
  [Benchmark]
  public int FastDigitsCount()
  {
    return Numbers.FastDigitsCount(D);
  }
}
