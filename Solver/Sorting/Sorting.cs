using System;
using System.Runtime.CompilerServices;
using Solver.DataStructures;

namespace Solver.Sorting;

public static class Sorting
{
  public static void HeapSort(int[] a)
  {
    Heap.Sort(a);
  }
    
  public static void HeapSort<T>(T[] a, Comparison<T> comparer)
  {
    Heap.Sort(a, comparer);
  }
    
  public static void QuickSort(int[] a)
  {
    QuickSortHoare(a, 0, a.Length - 1);
  }
    
  /// <remarks>На отсортированном массиве ведёт себя паршиво.</remarks>
  public static void QuickSortLomuto(int[] a)
  {
    QuickSortLomuto(a, 0, a.Length - 1);
  }

  private static void QuickSortLomuto(int[] a, int l, int r)
  {
    if (l < r)
    {
      var q = LomutoPartition(a, l, r);
      QuickSortLomuto(a, l, q - 1);
      QuickSortLomuto(a, q + 1, r);
    }
  }

  private static void QuickSortHoare(int[] a, int l, int r)
  {
    if (l < r)
    {
      var q = HoarePartition(a, l, r);
      QuickSortHoare(a, l, q);
      QuickSortHoare(a, q + 1, r);
    }
  }

  private static int LomutoPartition(int[] a, int l, int r)
  {
    var pivot = a[r];
    int i = l;
    for (int j = l; j < r; j++)
    {
      if (a[j] < pivot)
      {
        Swap(a, i, j);
        i++;
      }
    }

    Swap(a, i, r);
    return i;
  }

  public static int HoarePartition(int[] a, int l, int r)
  {
    var pivot = a[l + (r - l) / 2];
    var i = l - 1;
    var j = r + 1;
    while (true)
    {
      do
      {
        i++;
      }
      while (a[i] < pivot);

      do
      {
        j--;
      }
      while (a[j] > pivot);

      if (i >= j)
        return j;

      Swap(a, i, j);
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void Swap(int[] a, int i, int j)
  {
    (a[j], a[i]) = (a[i], a[j]);
  }
}
