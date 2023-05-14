using static System.Math;

namespace Solver.DataStructures;

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

  public int Count => front.Count + back.Count;

  public void Enqueue(int value)
  {
    front.Push(value);
  }

  public int Dequeue()
  {
    if (back.Count == 0)
    {
      while (front.Count > 0)
      {
        back.Push(front.Pop());
      }
    }
    return back.Pop();
  }
}
