using System;
using System.Collections.Generic;

namespace Olymp.Utils
{
  public class MinMaxStack
  {
    private readonly List<StackElement> s;

    public int Size => s.Count;

    public int Min => s.Count > 0 ? s[s.Count - 1].min : int.MaxValue;

    public int Max => s.Count > 0 ? s[s.Count - 1].max : int.MinValue;

    public void Push(int value)
    {
      if (s.Count > 0)
        s.Add(new StackElement(value, Math.Min(value, s[s.Count - 1].min), Math.Max(value, s[s.Count - 1].max)));
      else
        s.Add(new StackElement(value, value, value));
    }

    public int Pop()
    {
      var result = s[s.Count - 1];
      s.RemoveAt(s.Count - 1);
      return result.value;
    }

    public MinMaxStack(int capacity)
    {
      s = new List<StackElement>(capacity);
    }
  }
}
