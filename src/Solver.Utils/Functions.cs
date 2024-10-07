namespace Solver.Utils;

public static class Functions
{
  public static int Min(params int[] values)
  {
    return values.Min();
  }

  public static int Max(params int[] values)
  {
    return values.Max();
  }

  public static (int m1, int m2) Find2Max(Span<int> a)
  {
    var m1 = int.MinValue;
    var m2 = int.MinValue;
    for (int i = 0; i < a.Length; i++)
    {
      if (a[i] >= m1)
      {
        m2 = m1;
        m1 = a[i];
      }
      else if (a[i] > m2)
      {
        m2 = a[i];
      }
    }
    return (m1, m2);
  }

  public static void Permute<T>(T[] a, int i, int n, Action<T[]> process)
  {
    if (i == n - 1)
    {
      process(a);
    }
    else
    {
      for (var j = i; j < n; j++)
      {
        (a[i], a[j]) = (a[j], a[i]);
        Permute(a, i + 1, n, process);
        (a[i], a[j]) = (a[j], a[i]);
      }
    }
  }
  
  public static void NextPermutation(int[] nums)
  {
    var n = nums.Length;
    for (var i = n - 2; i >= 0; i--)
    {
      if (nums[i] >= nums[i + 1])
        continue;
      for (var j = n - 1; j > i; j--)
      {
        if (nums[j] > nums[i])
        {
          (nums[i], nums[j]) = (nums[j], nums[i]);
          nums.AsSpan(i + 1).Reverse();
          return;
        }
      }
    }
    nums.AsSpan().Reverse();
  }
  
  public static void NextPermutationBinarySearch(int[] nums)
  {
    var i = nums.Length - 2;
    while (i >= 0 && nums[i] >= nums[i + 1])
      i--;

    if (i >= 0)
    {
      var l = i + 1;
      var r = nums.Length;
      while (l < r)
      {
        var m = l + (r - l) / 2;
        if (nums[m] > nums[i])
          l = m + 1;
        else
          r = m;
      }
      (nums[i], nums[r - 1]) = (nums[r - 1], nums[i]);
    }
    nums.AsSpan(i + 1).Reverse();
  }

  public static bool IsVovel(char c) => "aeiouy".Contains(c);

  public static IEnumerable<T> Compact<T>(IEnumerable<T> a) where T : IEquatable<T>
  {
    using var e = a.GetEnumerator();
    if (!e.MoveNext())
      yield break;
    var lastA = e.Current;
    while (e.MoveNext())
    {
      var val = e.Current;
      if (val.Equals(lastA))
        continue;
      yield return lastA;
      lastA = val;
    }
    yield return lastA;
  }
  
  /// <summary>
  /// Calculate binomial coefficient (https://en.wikipedia.org/wiki/Binomial_coefficient).
  /// </summary>
  public static long Combinations(int n, int k)
  {
    if (k < 0 || k > n)
      return 0;

    if (k > n - k)
      k = n - k;

    var c = 1L;
    for (var i = 0; i < k; i++)
    {
      c *= n - i;
      c /= i + 1;
    }
    return c;
  }
}
