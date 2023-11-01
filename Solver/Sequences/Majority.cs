namespace Solver.Sequences;

public class Majority
{
  /// <summary>
  /// Return the majority element.
  /// The majority element is the element that appears more than ⌊n / 2⌋ times.
  /// </summary>
  /// <remarks>
  /// Boyer–Moore majority vote algorithm.
  /// https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
  /// </remarks>
  public int MajorityElement(int[] a)
  {
    var n = a.Length;
    var major = a[0];
    var count = 1;
    for (var i = 1; i < n; i++)
    {
      if (count == 0)
      {
        major = a[i];
        count = 1;
      }
      else if (major == a[i])
      {
        count++;
      }
      else
      {
        count--;
      }
    }
    return major;
  }
}
