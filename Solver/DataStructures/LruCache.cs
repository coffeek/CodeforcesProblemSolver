namespace Solver.DataStructures;

/// <summary>
/// Least recently used (LRU) cache.
/// https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU
/// </summary>
public class LruCache<TKey, TValue>
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

  public LruCache(int capacity)
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

  /// <remarks>If the number of keys exceeds the capacity, evict the least recently used key.</remarks>
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
