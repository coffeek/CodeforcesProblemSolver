namespace Solver.DataStructures;

public class ListNode<T>
{
  public T Value { get; set; }
  public ListNode<T> Next { get; set; }
  
  public ListNode(T value, ListNode<T> next = null)
  {
    Value = value;
    Next = next;
  }
}

public static class LinkedListUtils
{
  /// <summary>
  /// Find a cycle using Floyd’s Cycle-Finding Algorithm.
  /// </summary>
  public static bool HasCycle<T>(ListNode<T> list)
  {
    var slow = list;
    var fast = list?.Next;
    while (fast != null && slow != fast)
    {
      slow = slow?.Next;
      fast = fast.Next?.Next;
    }
    return fast != null;
  }
}
