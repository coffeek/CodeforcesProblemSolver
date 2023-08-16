using System;
using System.Collections.Generic;

namespace Solver.DataStructures;

public class MinMaxStack
{
  private readonly record struct StackElement(int Value, int Min, int Max);

  private readonly Stack<StackElement> s;
  
  public int Count => s.Count;

  public int Min => s.TryPeek(out var top) ? top.Min : int.MaxValue;

  public int Max => s.TryPeek(out var top) ? top.Max : int.MinValue;

  public void Push(int value)
  {
    var se = s.TryPeek(out var top) ?
      new StackElement(value, Math.Min(value, top.Min), Math.Max(value, top.Max)) :
      new StackElement(value, value, value);
    s.Push(se);
  }

  public int Pop() => s.Pop().Value;

  public MinMaxStack(int capacity) => s = new Stack<StackElement>(capacity);
}
