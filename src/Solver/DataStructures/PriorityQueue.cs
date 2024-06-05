namespace Solver.DataStructures;

public class PriorityQueue<T>
{
  private readonly Comparison<T> compare;
  private readonly List<T> heap;

  public int Count => heap.Count;

  public T Top
  {
    get
    {
      if (heap.Count == 0)
        throw new InvalidOperationException("Queue is empty");
      return heap[0];
    }
  }

  public void Enqueue(T item)
  {
    var i = heap.Count;
    heap.Add(item);
    while (i > 0)
    {
      var p = (i - 1) >> 1;
      if (compare(heap[p], item) <= 0)
        break;
      heap[i] = heap[p];
      i = p;
    }
    heap[i] = item;
  }

  public T Dequeue()
  {
    if (heap.Count == 0)
      throw new InvalidOperationException("Queue is empty");

    var result = heap[0];
    var last = heap.Count - 1;
    var lastItem = heap[^1];
    var i = 0;
    var lch = (i << 1) | 1;
    while (lch < last)
    {
      var rch = lch + 1;
      if (rch < last && compare(heap[rch], heap[lch]) < 0)
        lch = rch;
      if (compare(lastItem, heap[lch]) < 0)
        break;
      heap[i] = heap[lch];
      i = lch;
      lch = (i << 1) | 1;
    }
    heap[i] = lastItem;
    heap.RemoveAt(last);
    return result;
  }

  public PriorityQueue()
    : this(0, Comparer<T>.Default.Compare)
  {
  }

  public PriorityQueue(int capacity)
    : this(capacity, Comparer<T>.Default.Compare)
  {
  }

  public PriorityQueue(Comparison<T> comparison)
    : this(0, comparison)
  {
  }

  public PriorityQueue(int capacity, Comparison<T> comparison)
  {
    compare = comparison ?? throw new ArgumentNullException(nameof(comparison));
    heap = new List<T>(capacity);
  }
}
