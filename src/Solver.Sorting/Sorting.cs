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

  /// <summary>
  /// Dutch national flag problem
  /// https://en.wikipedia.org/wiki/Dutch_national_flag_problem
  /// </summary>
  public static void TreeWayPartition(int[] a, int mid)
  {
    var n = a.Length;
    var (i, j, k) = (0, 0, n - 1);
    while (j <= k)
    {
      if (a[j] < mid)
      {
        Swap(a, i, j);
        i++;
        j++;
      }
      else if (a[j] > mid)
      {
        Swap(a, j, k);
        k--;
      }
      else
      {
        j++;
      }
    }
  }

  public static void ShellSort(int[] a)
  {
    var n = a.Length;
    var nextPass = true;
    for (int gap = (n + 1) / 2; nextPass || gap > 1; gap = (gap + 1) / 2)
    {
      nextPass = false;
      for (int i = 0; i + gap < n; i++)
      {
        if (a[i] > a[i + gap])
        {
          Swap(a, i, i + gap);
          nextPass = true;
        }
      }
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void Swap(int[] a, int i, int j)
  {
    (a[j], a[i]) = (a[i], a[j]);
  }
}
