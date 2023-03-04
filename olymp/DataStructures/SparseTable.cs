using System;
using static System.Math;

namespace Olymp.DataStructures;

public class SparseTable
{
  private readonly int N;
  private readonly int[] log;
  private readonly int K;
  private readonly int[,] table;

  public int GetMin(int l, int r)
  {
    var result = Int32.MaxValue;

    while (l <= r)
    {
      int k = log[r - l + 1];
      result = Min(result, table[l, k]);
      l += 1 << k;
    }

    return result;
  }

  public int GetMinFast(int l, int r)
  {
    int j = log[r - l + 1];
    return Min(table[l, j], table[r - (1 << j) + 1, j]);
  }
    
  public int GetRightIndexLessThan(int val, int l, int r)
  {
    while (l <= r)
    {
      var k = -1;
      for (int i = 0; l <= r - (1 << i) + 1; i++)
      {
        if (table[r - (1 << i) + 1, i] < val)
        {
          k = i;
          break;
        }
      }
      switch (k)
      {
        case 0:
          return r;
        case -1:
          r -= 1 << log[r - l + 1];
          break;
        default:
        {
          if (l == r)
            return l;
          l = r - (1 << k) + 1;
          r = l + (1 << (k - 1)) - 1;
          break;
        }
      }
    }
    return -1;
  }

  private void Build(int[] data)
  {
    for (int i = 0; i < N; i++)
    {
      table[i, 0] = data[i];
    }
    for (int j = 1; j <= K; j++)
    {
      for (int i = 0; i + (1 << j) <= N; i++)
      {
        table[i, j] = Min(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
      }
    }
  }

  private void PrecomputeLog()
  {
    for (int i = 2; i <= N; i++)
      log[i] = log[i / 2] + 1;
  }

  public SparseTable(int[] data)
  {
    N = data.Length;
    log = new int[N + 1];
    PrecomputeLog();
    K = log[N];
    table = new int[N + 1, K + 1];
    Build(data);
  }
}