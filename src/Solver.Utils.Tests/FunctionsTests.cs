namespace Solver.Utils.Tests;

[TestFixture]
public class FunctionsTests
{
  [TestCase(new[] { 0 }, new[] { 0 })]
  [TestCase(new[] { 1 }, new[] { 1 })]
  [TestCase(new[] { 0, 0, 0 }, new[] { 0 })]
  [TestCase(new[] { 1, 0, 1 }, new[] { 1, 0, 1 })]
  [TestCase(new[] { 1, 0, 1, 1, 1, 0 }, new[] { 1, 0, 1, 0 })]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
  [TestCase(new[] { 1, 1, 1, 2, 2, 2, 0, 0, 3, 1, 2 }, new[] { 1, 2, 0, 3, 1, 2 })]
  [TestCase(new[] { 0, 0, 1, 1, 1, 0 }, new[] { 0, 1, 0 })]
  public void CompactTests(int[] a, int[] expected)
  {
    Functions.Compact(a).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [TestCase(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MinTest(int[] values)
  {
    Functions.Min(values).Should().Be(values.Min());
  }

  [TestCase(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MaxTest(int[] values)
  {
    Functions.Max(values).Should().Be(values.Max());
  }

  [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
  [TestCase(new[] { -1 }, -1, int.MinValue)]
  [TestCase(new[] { -1, -10 }, -1, -10)]
  [TestCase(new[] { 7, -10, 1014, 895, 1014, 0 }, 1014, 1014)]
  [TestCase(new int[] { }, int.MinValue, int.MinValue)]
  public void Find2MaxTest(int[] values, int expectedMax1, int expectedMax2)
  {
    Functions.Find2Max(values).Should().Be((expectedMax1, expectedMax2));
  }

  [Test]
  public void PermuteTest()
  {
    var actual = new List<string>();
    Functions.Permute(new[] { 1, 2, 3 }, 0, 3, p => actual.Add(string.Join(" ", p)));
    actual.Should().BeEquivalentTo(
      new[] { "1 2 3", "1 3 2", "2 1 3", "2 3 1", "3 2 1", "3 1 2" }, 
      o => o.WithStrictOrdering());
  }

  [TestCase(1, 0, 1)]
  [TestCase(1, 1, 1)]
  [TestCase(0, 1, 0)]
  [TestCase(2, 3, 0)]
  [TestCase(2, 1, 2)]
  [TestCase(20, 1, 20)]
  [TestCase(20, 19, 20)]
  [TestCase(20, 10, 184756)]
  public void CombinationsTest(int n, int k, long expected)
  {
    Functions.Combinations(n, k).Should().Be(expected);
  }
  
  [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
  [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
  [TestCase(new[] { 1, 1, 5 }, new[] { 1, 5, 1 })]
  [TestCase(new[] { 1, 3, 2 }, new[] { 2, 1, 3 })]
  [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 })]
  [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
  [TestCase(new[] { 2, 1 }, new[] { 1, 2 })]
  [TestCase(new[] { 2 }, new[] { 2 })]
  public void NextPermutationTest(int[] nums, int[] expected)
  {
    Functions.NextPermutation(nums);
    nums.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
  
  [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
  [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
  [TestCase(new[] { 1, 1, 5 }, new[] { 1, 5, 1 })]
  [TestCase(new[] { 1, 3, 2 }, new[] { 2, 1, 3 })]
  [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 })]
  [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
  [TestCase(new[] { 2, 1 }, new[] { 1, 2 })]
  [TestCase(new[] { 2 }, new[] { 2 })]
  public void NextPermutationBinarySearchTest(int[] nums, int[] expected)
  {
    Functions.NextPermutationBinarySearch(nums);
    nums.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
