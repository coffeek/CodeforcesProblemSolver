namespace Solver.DataStructures.Tests;

[TestFixture]
public class SparseTableTests
{
  [TestCase(new[] { 1, 2, 3, 4, 5 })]
  [TestCase(new[] { -1, 5, 10, 0, 23, 24, 8, 9 })]
  [TestCase(new[] { 1324 })]
  [TestCase(new[] { 10, 1 })]
  public void GetMinTest(int[] data)
  {
    var t = new SparseTable(data);
    for (int i = 0; i < data.Length; i++)
    {
      for (int j = i; j < data.Length; j++)
      {
        var expected = data.Skip(i).Take(j - i + 1).Min();
        t.GetMin(i, j).Should().Be(expected);
        t.GetMinFast(i, j).Should().Be(expected);
      }
    }
  }

  [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0, 4, -1)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 0, 4, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 0, 4, 1)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, 0, 4, 2)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 0, 4, 3)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 2, 1, 3, -1)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 3, 1, 3, 2)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 5, 1, 3, 2)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 8, 1, 3, 3)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 8, 4, 4, -1)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 9, 4, 4, 4)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 4, 0, 8, 8)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 3, 0, 8, 7)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 2, 0, 8, 6)]
  [TestCase(new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 }, 1, 0, 8, -1)]
  public void GetRightIndexLessThanTest(int[] data, int val, int l, int r, int expected)
  {
    new SparseTable(data).GetRightIndexLessThan(val, l, r).Should().Be(expected);
  }
}
