using System.Collections.Generic;

namespace Olymp.Utils;

public static class Counter
{
  public static int IncCount<T>(IDictionary<T, int> counter, T item)
  {
    if (counter.TryGetValue(item, out var count))
      return (counter[item] = count + 1);
    counter.Add(item, 1);
    return 1;
  }

  public static void DecCount<T>(IDictionary<T, int> counter, T item)
  {
    if (!counter.TryGetValue(item, out var count))
      return;
    if (count == 1)
      counter.Remove(item);
    else
      counter[item] = count - 1;
  }

  public static int GetCount<T>(IDictionary<T, int> counter, T item)
  {
    return counter.TryGetValue(item, out var count) ? count : 0;
  }

  public static Dictionary<T, int> Counts<T>(params T[] a)
  {
    var c = new Dictionary<T, int>();
    foreach (var t in a)
      IncCount(c, t);
    return c;
  }
}
