using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Benchmarks;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
public class XorArray
{
  private const int N = 100000;
  private readonly int[] a;
  private readonly int xor;

  public XorArray()
  {
    var random = new Random();
    a = new int[N];
    for (int i = 0; i < N; i++)
    {
      a[i] = random.Next();
      xor ^= a[i];
    }
  }

  [Benchmark(Baseline = true)]
  public int Xor()
  {
    var result = 0;
    for (int i = 0; i < N; i++)
      result ^= a[i];
    if (result != xor)
      throw new InvalidOperationException();
    return result;
  }
  
  [Benchmark]
  public int ForeachXor()
  {
    var result = 0;
    foreach (var x in a)
      result ^= x;
    if (result != xor)
      throw new InvalidOperationException();
    return result;
  }
  
  [Benchmark]
  public int AggregateXor()
  {
    var result = a.Aggregate(0, (current, x) => current ^ x);
    if (result != xor)
      throw new InvalidOperationException();
    return result;
  }

  [Benchmark]
  public int VectorXor()
  {
    var blockSize = Vector<int>.Count;
    var blockCount = a.Length / blockSize;
    var v = new Vector<int>();
    for (var i = 0; i < blockCount; i++)
      v ^= new Vector<int>(a, i * blockSize);
    var result = 0;
    for (var i = 0; i < blockSize; i++)
      result ^= v[i];
    for (var i = blockSize * blockCount; i < a.Length; i++)
      result ^= a[i];
    if (result != xor)
      throw new InvalidOperationException();
    return result;
  }

  [Benchmark]
  public unsafe int AvxXor()
  {
    var v = new Vector256<int>();
    var blockSize = Vector256<int>.Count;
    var blockCount = a.Length / blockSize;
    fixed (int* p = &a[0])
    {
      for (int i = 0, offset = 0; i < blockCount; i++, offset += blockSize)
        v = Avx2.Xor(v, Avx.LoadVector256(p + offset));
    }
    var result = 0;
    for (var i = 0; i < blockSize; i++)
      result ^= v.GetElement(i);
    for (var i = blockSize * blockCount; i < a.Length; i++)
      result ^= a[i];
    if (result != xor)
      throw new InvalidOperationException();
    return result;
  }
}
