namespace Solver.DataStructures;

public static class Heap
{
  public static void Build(int[] a)
  {
    var n = a.Length;
    for (int i = n / 2 - 1; i >= 0; i--)
    {
      PushDown(a, i, n);
    }
  }

  public static void Sort(int[] a)
  {
    Build(a);
    for (int i = a.Length - 1; i > 0; i--)
    {
      (a[i], a[0]) = (a[0], a[i]);
      PushDown(a, 0, i);
    }
  }

  public static void Build<T>(T[] a, Comparison<T> comparer)
  {
    int n = a.Length;
    for (int i = n >> 1; i >= 1; i--)
    {
      DownHeap(a, i, n, comparer);
    }
  }

  public static void Sort<T>(T[] a, Comparison<T> comparer)
  {
    comparer ??= Comparer<T>.Default.Compare;
    Build(a, comparer);
    int n = a.Length;
    for (int i = n; i > 1; i--)
    {
      (a[0], a[i - 1]) = (a[i - 1], a[0]);
      DownHeap(a, 1, i - 1, comparer);
    }
  }

  public static void DownHeap<T>(Span<T> a, int i, int n, Comparison<T> comparer)
  {
    T d = a[i - 1];
    while (i <= n >> 1)
    {
      int child = 2 * i;
      if (child < n && comparer(a[child - 1], a[child]) < 0)
      {
        child++;
      }

      if (!(comparer(d, a[child - 1]) < 0))
        break;

      a[i - 1] = a[child - 1];
      i = child;
    }

    a[i - 1] = d;
  }
    
  public static void UpHeap<T>(Span<T> a, int i, int n, Comparison<T> comparer)
  {
    while (i > 0)
    {
      int p = (i - 1) >> 1;
      if (comparer(a[i], a[p]) >= 0)
        break;
      (a[p], a[i]) = (a[i], a[p]);
      i = p;
    }
  }
    
  private static void PushUp(Span<int> a, int i)
  {
    while (i > 0)
    {
      int p = (i - 1) >> 1;
      if (a[p] >= a[i])
        break;
      (a[p], a[i]) = (a[i], a[p]);
      i = p;
    }
  }

  private static void PushDown(Span<int> a, int i, int n)
  {
    while (true)
    {
      var largest = i;
      int l = (i << 1) + 1; /* 2*id + 1 */
      int r = (i + 1) << 1; /* 2*id + 2 */
      if (l < n && a[l] > a[largest])
        largest = l;
      if (r < n && a[r] > a[largest])
        largest = r;
      if (largest == i)
        break;
      (a[largest], a[i]) = (a[i], a[largest]);
      i = largest;
    }
  }
}