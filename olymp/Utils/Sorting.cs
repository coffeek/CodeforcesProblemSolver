namespace Olymp.Utils
{
  public static class Sorting
  {
    public static void QuickSort(int[] a)
    {
      QuickSortHoare(a, 0, a.Length - 1);
    }
    
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

    private static int HoarePartition(int[] a, int l, int r)
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

    private static void Swap(int[] a, int i, int j)
    {
      var t = a[j];
      a[j] = a[i];
      a[i] = t;
    }

    public static int QuickSelect(int[] a, int k)
    {
      return QuickSelect(a, 0, a.Length - 1, k);
    }

    private static int QuickSelect(int[] a, int l, int r, int k)
    {
      while (l < r)
      {
        var q = HoarePartition(a, l, r);
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
  }
}
