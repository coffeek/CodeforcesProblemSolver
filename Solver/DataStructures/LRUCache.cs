using System.Collections.Generic;

namespace Solver.DataStructures;

public class LRUCache<TKey, TValue>
{
  private readonly struct CacheItem
  {
    public readonly TKey Key;
    public readonly TValue Value;

    public CacheItem(TKey key, TValue value)
    {
      Key = key;
      Value = value;
    }
  }

  private readonly int capacity;
  private readonly LinkedList<CacheItem> list = new();
  private readonly Dictionary<TKey, LinkedListNode<CacheItem>> dict = new();

  public LRUCache(int capacity)
  {
    this.capacity = capacity;
  }

  public TValue Get(TKey key)
  {
    if (TryGet(key, out var value))
      return value;
    throw new KeyNotFoundException();
  }

  public bool TryGet(TKey key, out TValue value)
  {
    if (!dict.TryGetValue(key, out var node))
    {
      value = default;
      return false;
    }

    list.Remove(node);
    list.AddFirst(node);
    value = node.Value.Value;
    return true;
  }

  public void Put(TKey key, TValue value)
  {
    if (dict.TryGetValue(key, out var node))
    {
      list.Remove(node);
    }
    else if (list.Count == capacity)
    {
      dict.Remove(list.Last.Value.Key);
      list.RemoveLast();
    }
    dict[key] = list.AddFirst(new CacheItem(key, value));
  }
}
