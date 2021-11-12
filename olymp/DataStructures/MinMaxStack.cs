using System;
using System.Collections.Generic;

namespace Olymp.DataStructures
{
  public class MinMaxStack
  {
    private readonly List<StackElement> s;

    public int Size => s.Count;

    public int Min => s.Count > 0 ? s[s.Count - 1].Min : int.MaxValue;

    public int Max => s.Count > 0 ? s[s.Count - 1].Max : int.MinValue;

    public void Push(int value)
    {
      if (s.Count > 0)
        s.Add(new StackElement(value, Math.Min(value, s[s.Count - 1].Min), Math.Max(value, s[s.Count - 1].Max)));
      else
        s.Add(new StackElement(value, value, value));
    }

    public int Pop()
    {
      var result = s[s.Count - 1];
      s.RemoveAt(s.Count - 1);
      return result.Value;
    }

    public MinMaxStack(int capacity)
    {
      s = new List<StackElement>(capacity);
    }

    private readonly struct StackElement
    {
      public readonly int Value;
      public readonly int Min;
      public readonly int Max;

      public StackElement(int value, int min, int max)
      {
        Value = value;
        Min = min;
        Max = max;
      }
    }
  }
}
