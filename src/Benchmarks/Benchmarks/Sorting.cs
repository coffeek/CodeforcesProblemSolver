using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Solver.Sorting;

namespace Benchmarks.Benchmarks;

public class SortRandomNumbersBenchmark
{
  [Params(100, 1_000, 10_000)]
  public int N;

  private int[] source;
  private int[] data;

  [GlobalSetup]
  public void Setup()
  {
    data = new int[N];
    source = new int[N];
    var bytes = MemoryMarshal.AsBytes(source.AsSpan());
    new Random().NextBytes(bytes);
  }

  [Benchmark(Baseline = true)]
  public void ArraySort()
  {
    source.AsSpan().CopyTo(data);
    Array.Sort(data);
  }

  [Benchmark]
  public void QuickSortHoare()
  {
    source.AsSpan().CopyTo(data);
    Sorting.QuickSort(data);
  }
    
  [Benchmark]
  public void QuickSortLomuto()
  {
    source.AsSpan().CopyTo(data);
    Sorting.QuickSortLomuto(data);
  }
    
  [Benchmark]
  public void HeapSort()
  {
    source.AsSpan().CopyTo(data);
    Sorting.HeapSort(data);
  }
  
  [Benchmark]
  public void ShellSort()
  {
    source.AsSpan().CopyTo(data);
    Sorting.ShellSort(data);
  }
    
  // [Benchmark]
  // public void HeapSortWithComparer()
  // {
  //   source.AsSpan().CopyTo(data);
  //   Sorting.HeapSort(data, Comparer<int>.Default.Compare);
  // }
}
  
public class SortOrderedNumbersBenchmark
{
  [Params(100, 1_000, 10_000)]
  public int N;

  private int[] source;
  private int[] data;
  
  [GlobalSetup]
  public void Setup()
  {
    data = new int[N];
    source = new int[N];
    for (int i = 0; i < N; i++)
      source[i] = i;
  }

  [Benchmark(Baseline = true)]
  public void ArraySort()
  {
    source.AsSpan().CopyTo(data);
    Array.Sort(data);
  }

  // [Benchmark]
  // public void QuickSortHoare()
  // {
  //   source.AsSpan().CopyTo(data);
  //   Sorting.QuickSort(data);
  // }
    
  // [Benchmark]
  // public void QuickSortLomuto()
  // {
  //   source.AsSpan().CopyTo(data);
  //   Sorting.QuickSortLomuto(data);
  // }
    
  [Benchmark]
  public void HeapSort()
  {
    source.AsSpan().CopyTo(data);
    Sorting.HeapSort(data);
  }
  
  [Benchmark]
  public void ShellSort()
  {
    source.AsSpan().CopyTo(data);
    Sorting.ShellSort(data);
  }
}
