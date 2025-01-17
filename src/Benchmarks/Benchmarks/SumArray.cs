using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Benchmarks;

// [SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
public class SumArray
{
  private const int N = 100000;
  private readonly int[] a;
  private readonly int expected;

  public SumArray()
  {
    int[] data = { 0, 1, 17, 9, 104, 45, 159 };
    a = new int[N];
    for (int i = 0; i < N; i++)
    {
      a[i] = data[i % data.Length];
      expected += a[i];
    }
  }

  [Benchmark(Baseline = true)]
  public int Sum()
  {
    var result = 0;
    for (int i = 0; i < N; i++)
      result += a[i];
    if (result != expected)
      throw new InvalidOperationException();
    return result;
  }
  
  // [Benchmark]
  // public int ForeachSum()
  // {
  //   var result = 0;
  //   foreach (var x in a)
  //     result += x;
  //   if (result != expected)
  //     throw new InvalidOperationException();
  //   return result;
  // }
  
  [Benchmark]
  public int LinqSum()
  {
    var result = a.Sum();
    if (result != expected)
      throw new InvalidOperationException();
    return result;
  }

  [Benchmark]
  public int VectorSum()
  {
    var blockSize = Vector<int>.Count;
    var blockCount = a.Length / blockSize;
    var v = new Vector<int>();
    for (var i = 0; i < blockCount; i++)
      v += new Vector<int>(a, i * blockSize);
    var result = Vector.Dot(v, Vector<int>.One);
    for (var i = blockSize * blockCount; i < a.Length; i++)
      result += a[i];
    if (result != expected)
      throw new InvalidOperationException();
    return result;
  }
}
