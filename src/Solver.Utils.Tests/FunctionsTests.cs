namespace Solver.Utils.Tests;

public class FunctionsTests
{
  [Theory]
  [InlineData(new[] { 0 }, new[] { 0 })]
  [InlineData(new[] { 1 }, new[] { 1 })]
  [InlineData(new[] { 0, 0, 0 }, new[] { 0 })]
  [InlineData(new[] { 1, 0, 1 }, new[] { 1, 0, 1 })]
  [InlineData(new[] { 1, 0, 1, 1, 1, 0 }, new[] { 1, 0, 1, 0 })]
  [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
  [InlineData(new[] { 1, 1, 1, 2, 2, 2, 0, 0, 3, 1, 2 }, new[] { 1, 2, 0, 3, 1, 2 })]
  [InlineData(new[] { 0, 0, 1, 1, 1, 0 }, new[] { 0, 1, 0 })]
  public void CompactTests(int[] a, int[] expected)
  {
    Functions.Compact(a).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Theory]
  [InlineData(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MinTest(int[] values)
  {
    Functions.Min(values).Should().Be(values.Min());
  }

  [Theory]
  [InlineData(new[] { 1, 1, 1, 2, 2, -2, 0, 0, 3, 1, 2 })]
  public void MaxTest(int[] values)
  {
    Functions.Max(values).Should().Be(values.Max());
  }

  [Theory]
  [InlineData(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
  [InlineData(new[] { -1 }, -1, int.MinValue)]
  [InlineData(new[] { -1, -10 }, -1, -10)]
  [InlineData(new[] { 7, -10, 1014, 895, 1014, 0 }, 1014, 1014)]
  [InlineData(new int[] { }, int.MinValue, int.MinValue)]
  public void Find2MaxTest(int[] values, int expectedMax1, int expectedMax2)
  {
    Functions.Find2Max(values).Should().Be((expectedMax1, expectedMax2));
  }

  [Fact]
  public void PermuteTest()
  {
    var actual = new List<string>();
    Functions.Permute(new[] { 1, 2, 3 }, 0, 3, p => actual.Add(string.Join(" ", p)));
    actual.Should().BeEquivalentTo(
      new[] { "1 2 3", "1 3 2", "2 1 3", "2 3 1", "3 2 1", "3 1 2" }, 
      o => o.WithStrictOrdering());
  }

  [Theory]
  [InlineData(1, 0, 1)]
  [InlineData(1, 1, 1)]
  [InlineData(0, 1, 0)]
  [InlineData(2, 3, 0)]
  [InlineData(2, 1, 2)]
  [InlineData(20, 1, 20)]
  [InlineData(20, 19, 20)]
  [InlineData(20, 10, 184756)]
  public void CombinationsTest(int n, int k, long expected)
  {
    Functions.Combinations(n, k).Should().Be(expected);
  }
}
