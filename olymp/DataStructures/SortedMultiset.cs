using System;
using System.Collections.Generic;

namespace Olymp.DataStructures;

public class SortedMultiset<T> where T : IComparable<T>
{
  private readonly Dictionary<T, int> counter = new();
  private readonly SortedSet<T> set = new();
  private int size;

  public SortedMultiset()
  {
  }

  public SortedMultiset(IEnumerable<T> items)
  {
    foreach (var item in items)
      Add(item);
  }

  public int Count => size;

  public void Add(T item)
  {
    if (counter.TryGetValue(item, out var count))
      counter[item] = count + 1;
    else
      counter.Add(item, 1);
    set.Add(item);
    size++;
  }

  public bool Remove(T item)
  {
    if (!counter.TryGetValue(item, out var count))
      return false;
    if (count == 1)
    {
      counter.Remove(item);
      set.Remove(item);
    }
    else
    {
      counter[item] = count - 1;
    }
    size--;
    return true;
  }

  public bool Contains(T item) => counter.ContainsKey(item);

  public int CountOf(T item) => counter.TryGetValue(item, out var count) ? count : 0;

  public T Min() => set.Min;

  public T Max() => set.Max;
}
