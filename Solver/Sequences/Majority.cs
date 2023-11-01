using System.Collections.Generic;

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
  
  /// <summary>
  /// Find all elements that appear more than ⌊ n/3 ⌋ times.
  /// </summary>
  /// <remarks>
  /// Boyer–Moore majority vote algorithm (adaptation for n/3 majority)
  /// https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
  /// </remarks>
  public IList<int> ThirdMajorityElements(int[] nums)
  {
    var count1 = 0;
    var count2 = 0;
    var major1 = 0;
    var major2 = 0;
    foreach (var n in nums)
    {
      if (n == major1)
        count1++;
      else if (n == major2)
        count2++;
      else if (count1 == 0)
        (major1, count1) = (n, 1);
      else if (count2 == 0)
        (major2, count2) = (n, 1);
      else
      {
        count1--;
        count2--;
      }
    }
    count1 = 0;
    count2 = 0;
    foreach (var n in nums)
    {
      if (n == major1)
        count1++;
      else if (n == major2)
        count2++;
    }
    var ans = new List<int>();
    if (count1 > nums.Length / 3)
      ans.Add(major1);
    if (count2 > nums.Length / 3)
      ans.Add(major2);
    return ans;
  }
}
