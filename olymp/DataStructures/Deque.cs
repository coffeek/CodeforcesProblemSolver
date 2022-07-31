using System;
using static System.Math;

namespace Olymp.DataStructures
{
  public class SimpleDeque<T>
  {
    private readonly int size;
    private readonly T[] buffer;
    private int start;
    private int count;

    public T Front => buffer[start];

    public T Back => buffer[GetBufferIndex(count - 1)];

    public T this[int index]
    {
      get => buffer[GetBufferIndex(index)];
      set => buffer[GetBufferIndex(index)] = value;
    }

    public T[] ToArray()
    {
      var head = Min(count, size - start);
      if (head == count)
        return buffer.AsSpan(start, count).ToArray();
      var result = new T[count];
      buffer.AsSpan(start).CopyTo(result);
      var tail = count - head;
      buffer.AsSpan(0, tail).CopyTo(result.AsSpan(head));
      return result;
    }

    public void PushFront(T item)
    {
      start = start == 0 ? size - 1 : start - 1;
      buffer[start] = item;
      count++;
    }

    public void PushBack(T item)
    {
      buffer[GetBufferIndex(count)] = item;
      count++;
    }

    public T PopFront()
    {
      var item = buffer[start];
      start++;
      if (start == size)
        start = 0;
      count--;
      return item;
    }

    public T PopBack()
    {
      count--;
      return buffer[GetBufferIndex(count)];
    }

    private int GetBufferIndex(int index) => (start + index) % size;

    public SimpleDeque(int capacity)
    {
      size = capacity;
      buffer = new T[size];
    }
  }
}
