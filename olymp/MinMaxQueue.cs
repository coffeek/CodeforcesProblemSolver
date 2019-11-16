using System.Collections.Generic;
using static System.Math;

namespace Olymp
{
  public struct StackElement
  {
    public readonly int value;
    public readonly int min;
    public readonly int max;

    public StackElement(int value, int min, int max)
    {
      this.value = value;
      this.min = min;
      this.max = max;
    }
  }

  public class MinMaxStack
  {
    private readonly List<StackElement> s;

    public int Size => s.Count;

    public int Min => s.Count > 0 ? s[s.Count - 1].min : int.MaxValue;

    public int Max => s.Count > 0 ? s[s.Count - 1].max : int.MinValue;

    public void Push(int value)
    {
      if (s.Count > 0)
        s.Add(new StackElement(value, Min(value, s[s.Count - 1].min), Max(value, s[s.Count - 1].max)));
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

  public class MinMaxQueue
  {
    private readonly MinMaxStack front;
    private readonly MinMaxStack back;

    public MinMaxQueue(int capacity)
    {
      front = new MinMaxStack(capacity);
      back = new MinMaxStack(capacity);
    }

    public int Min => Min(front.Min, back.Min);

    public int Max => Max(front.Max, back.Max);
    
    public int Size => front.Size + back.Size;

    public void Enqueue(int value)
    {
      front.Push(value);
    }

    public int Dequeue()
    {
      if (back.Size == 0)
      {
        while (front.Size > 0)
        {
          back.Push(front.Pop());
        }
      }
      return back.Pop();
    }
  }
}
