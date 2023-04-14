using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Solver.Utils;

namespace Benchmarks.Benchmarks;

public class SortRandomNumbersBenchmark
{
  public int N = 1_000_000;

  private readonly int[] data;

  public SortRandomNumbersBenchmark()
  {
    data = new int[N];
  }

  [IterationSetup]
  public void IterationSetup()
  {
    var bytes = MemoryMarshal.AsBytes(data.AsSpan());
    new Random().NextBytes(bytes);
  }

  [Benchmark(Baseline = true)]
  public void ArraySort()
  {
    Array.Sort(data);
  }

  [Benchmark]
  public void QuickSortHoare()
  {
    Sorting.QuickSort(data);
  }
    
  [Benchmark]
  public void QuickSortLomuto()
  {
    Sorting.QuickSortLomuto(data);
  }
    
  [Benchmark]
  public void HeapSort()
  {
    Sorting.HeapSort(data);
  }
    
  [Benchmark]
  public void HeapSortWithComparer()
  {
    Sorting.HeapSort(data, Comparer<int>.Default.Compare);
  }
}
  
public class SortOrderedNumbersBenchmark
{
  public int N = 2_000_000;

  private readonly int[] data;

  public SortOrderedNumbersBenchmark()
  {
    data = new int[N];
    for (int i = 0; i < N; i++)
      data[i] = i;
  }

  [Benchmark(Baseline = true)]
  public void ArraySort()
  {
    Array.Sort(data);
  }

  [Benchmark]
  public void QuickSortHoare()
  {
    Sorting.QuickSort(data);
  }
    
  // [Benchmark]
  // public void QuickSortLomuto()
  // {
  //   Sorting.QuickSortLomuto(data);
  // }
    
  [Benchmark]
  public void HeapSort()
  {
    Sorting.HeapSort(data);
  }
}
