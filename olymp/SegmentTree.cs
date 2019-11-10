using System;
using static System.Math;

namespace Olymp
{
  namespace SegmentTree
  {
    namespace Array
    {
      internal class SegmentTree<T>
      {
        private readonly Func<T, T, T> func;
        private readonly T[] t;
        private readonly int n;

        public T Query(int l, int r)
        {
          return Query(1, 0, n - 1, l, r);
        }

        private T Query(int v, int tl, int tr, int l, int r)
        {
          if (l > r)
            return default(T);
          if (l == tl && r == tr)
            return t[v];
          int tm = tl + (tr - tl) / 2;
          return func(Query(v * 2, tl, tm, l, Min(r, tm)),
            Query(v * 2 + 1, tm + 1, tr, Max(l, tm + 1), r));
        }

        public void FastUpdate(int pos, T value)
        {
          var v = 1;
          var tl = 0;
          var tr = n - 1;
          while (tl != tr)
          {
            int tm = tl + (tr - tl) / 2;
            if (pos <= tm)
            {
              v = 2 * v;
              tr = tm;
            }
            else
            {
              v = 2 * v + 1;
              tl = tm + 1;
            }
          }
          t[v] = value;
          while (v != 1)
          {
            v /= 2;
            t[v] = func(t[v * 2], t[v * 2 + 1]);
          }
        }

        public void Update(int pos, T value)
        {
          Update(1, 0, n - 1, pos, value);
        }

        private void Update(int v, int tl, int tr, int pos, T value)
        {
          if (tl == tr)
          {
            t[v] = value;
          }
          else
          {
            int tm = tl + (tr - tl) / 2;
            if (pos <= tm)
              Update(v * 2, tl, tm, pos, value);
            else
              Update(v * 2 + 1, tm + 1, tr, pos, value);
            t[v] = func(t[v * 2], t[v * 2 + 1]);
          }
        }

        private void Build(T[] data, int v, int tl, int tr)
        {
          if (tl == tr)
          {
            t[v] = data[tl];
          }
          else
          {
            int tm = tl + (tr - tl) / 2;
            Build(data, v * 2, tl, tm);
            Build(data, v * 2 + 1, tm + 1, tr);
            t[v] = func(t[v * 2], t[v * 2 + 1]);
          }
        }

        public SegmentTree(T[] data, Func<T, T, T> f)
        {
          func = f;
          n = data.Length;
          t = new T[4 * n];
          Build(data, 1, 0, n - 1);
        }
      }
    }

    namespace Tree
    {
      internal class SegmentTreeNode
      {
        private readonly int l;
        private readonly int r;
        private int c;
        private readonly SegmentTreeNode left;
        private readonly SegmentTreeNode right;

        public void Set(int index, char value)
        {
          if (l == r)
          {
            c = 1 << (value - 'a');
          }
          else
          {
            if (index <= left.r)
              left.Set(index, value);
            else
              right.Set(index, value);
            c = left.c | right.c;
          }
        }

        public int GetUsedCharMask(int l, int r)
        {
          if (this.l == l && this.r == r)
            return c;

          var result = 0;
          if (l <= left.r)
            result |= left.GetUsedCharMask(l, Min(r, left.r));
          if (r >= right.l)
            result |= right.GetUsedCharMask(Max(l, right.l), r);

          return result;
        }

        public SegmentTreeNode(char[] s, int l, int r)
        {
          this.l = l;
          this.r = r;

          if (l != r)
          {
            var m = l + (r - l) / 2;
            left = new SegmentTreeNode(s, l, m);
            right = new SegmentTreeNode(s, m + 1, r);
          }

          for (int i = l; i <= r; i++)
            Set(i, s[i]);
        }
      }

      internal class SegmentTree
      {
        private readonly SegmentTreeNode root;

        public void Set(int index, char value)
        {
          root.Set(index, value);
        }

        public int GetUniqueCharCount(int l, int r)
        {
          var c = root.GetUsedCharMask(l, r);
          var result = 0;
          while (c != 0)
          {
            result += c & 1;
            c >>= 1;
          }
          return result;
        }

        public SegmentTree(char[] s)
        {
          root = new SegmentTreeNode(s, 0, s.Length - 1);
        }
      }
    }
  }
}
