using System.Collections.Generic;

namespace Solver.DataStructures;

public class Multiset<T>
{
  private readonly Dictionary<T, int> counter = new();
  private int size;

  public Multiset()
  {
  }

  public Multiset(IEnumerable<T> items)
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
    size++;
  }

  public bool Remove(T item)
  {
    if (!counter.TryGetValue(item, out var count))
      return false;
    if (count == 1)
      counter.Remove(item);
    else
      counter[item] = count - 1;
    size--;
    return true;
  }

  public bool Contains(T item) => counter.ContainsKey(item);

  public int CountOf(T item) => counter.TryGetValue(item, out var count) ? count : 0;
}
