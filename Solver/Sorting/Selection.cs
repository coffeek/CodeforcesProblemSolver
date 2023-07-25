using System;
using System.Runtime.CompilerServices;

namespace Solver.Sorting;

public static class Selection
{
  public static int QuickSelect(int[] a, int k)
  {
    return QuickSelect(a, 0, a.Length - 1, k);
  }

  private static int QuickSelect(int[] a, int l, int r, int k)
  {
    while (l < r)
    {
      var q = Sorting.HoarePartition(a, l, r);
      if (k <= q)
        r = q;
      else
        l = q + 1;
    }
    return a[k];
  }

  public static int QuickSelectEMaxx(int[] a, int k)
  {
    var n = a.Length;

    var l = 0;
    var r = n - 1;
    while (true)
    {
      if (r <= l + 1)
      {
        if (r == l + 1 && a[r] < a[l])
          Swap(a, l, r);
        return a[k];
      }

      int mid = l + (r - l) / 2;
      Swap(a, mid, l + 1);
      if (a[l] > a[r])
        Swap(a, l, r);
      if (a[l + 1] > a[r])
        Swap(a, l + 1, r);
      if (a[l] > a[l + 1])
        Swap(a, l, l + 1);

      var i = l + 1;
      var j = r;
      var cur = a[l + 1];
      while (true)
      {
        do
        {
          i++;
        }
        while (a[i] < cur);

        do
        {
          j--;
        }
        while (a[j] > cur);

        if (i > j)
          break;

        Swap(a, i, j);
      }

      a[l + 1] = a[j];
      a[j] = cur;

      if (j >= k)
        r = j - 1;
      if (j <= k)
        l = i;
    }
  }
  
  /// <summary>
  /// Returns index of first element in sorted array that greater or equal to value,
  /// or r if no such element is found.
  /// </summary>
  /// <param name="a">An array.</param>
  /// <param name="value">Value to compare the elements to.</param>
  public static int LowerBound(int[] a, int value)
  {
    return LowerBound(a, 0, a.Length, value);
  }


  /// <summary>
  /// Returns index of first element in sorted array in the range [l, r)
  /// that greater or equal to value, or r if no such element is found.
  /// </summary>
  /// <param name="a">An array.</param>
  /// <param name="beginIndex">Left endpoint.</param>
  /// <param name="endIndex">Right endpoint (excluded).</param>
  /// <param name="value">Value to compare the elements to.</param>
  public static int LowerBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] < value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? endIndex : l;
  }

  /// <summary>
  /// Returns index of first element in sorted array that strictly greater value,
  /// or r if no such element is found.
  /// </summary>
  /// <param name="a">An array.</param>
  /// <param name="value">Value to compare the elements to.</param>
  public static int UpperBound(int[] a, int value)
  {
    return UpperBound(a, 0, a.Length, value);
  }
  
  /// <summary>
  /// Find maximum of unimodal function f() within [left, right].
  /// </summary>
  public static double TernarySearchMax(Func<double, double> f, double left, double right, double precision = 1e-10)
  {
    while (Math.Abs(right - left) >= precision)
    {
      var d = (right - left) / 3.0;
      var m1 = left + d;
      var m2 = right - d;
      if (f(m1) < f(m2))
        left = m1;
      else
        right = m2;
    }
    return (left + right) / 2.0;
  }
  
  /// <summary>
  /// Returns index of first element in sorted array in the range [l, r)
  /// that strictly greater value, or r if no such element is found.
  /// </summary>
  /// <param name="a">An array.</param>
  /// <param name="beginIndex">Left endpoint.</param>
  /// <param name="endIndex">Right endpoint (excluded).</param>
  /// <param name="value">Value to compare the elements to.</param>
  private static int UpperBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] <= value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] <= value ? endIndex : l;
  }
  
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void Swap(int[] a, int i, int j)
  {
    (a[j], a[i]) = (a[i], a[j]);
  }
}
