namespace Solver.Sorting.Tests;

[TestFixture]
public class SelectionTests
{
  private static readonly object[] QuickSelectTestArrays =
  {
    new[] { 5, 1, 6, 7, 9, 32, 3, 5, 0, 5, 6, 78, 23, 89 },
    Array.Empty<int>(),
    new[] { 1 },
    new[] { -1, -99 },
    new[] { 1, 5, -10 },
    new[] { 6, 5, 4, 1, 2, 3 }
  };
  
  [TestCaseSource(nameof(QuickSelectTestArrays))]
  public void QuickSelectTest(int[] array)
  {
    TestSelect(array, Selection.QuickSelect);
  }
  
  [TestCaseSource(nameof(QuickSelectTestArrays))]
  public void QuickSelectEMaxxTest(int[] array)
  {
    TestSelect(array, Selection.QuickSelectEMaxx);
  }

  private static void TestSelect(int[] a, Func<int[], int, int> select)
  {
    var b = a.OrderBy(x => x).ToArray();
    for (int i = 0; i < a.Length; i++)
      select(a, i).Should().Be(b[i]);
  }
  
  private static readonly object[] SearchBoundariesTestArrays =
  {
    Array.Empty<int>(),
    new[] { 0 },
    new[] { 9 },
    new[] { 0, 0 },
    new[] { 1, 1, 1 },
    new[] { 1, 2, 3 },
    new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9 },
    new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9, 9 },
  };
  
  [TestCaseSource(nameof(SearchBoundariesTestArrays))]
  public void LowerBoundTests(int[] array)
  {
    Selection.LowerBound(array, -1).Should().Be(0);
    for (int i = 0; i < 10; i++)
    {
      var expected = Enumerable.Range(0, array.Length).Cast<int?>().FirstOrDefault(j => array[j.Value] >= i) ?? array.Length;
      Selection.LowerBound(array, i).Should().Be(expected, $"a: [{string.Join(" ", array)}], value: {i}");
    }
  }
  
  [TestCaseSource(nameof(SearchBoundariesTestArrays))]
  public void UpperBoundTests(int[] array)
  {
    Selection.UpperBound(array, -1).Should().Be(0);
    for (int i = 0; i < 10; i++)
    {
      var expected = Enumerable.Range(0, array.Length).Cast<int?>().FirstOrDefault(j => array[j.Value] > i) ?? array.Length;
      Selection.UpperBound(array, i).Should().Be(expected, $"a: [{string.Join(" ", array)}], value: {i}");
    }
  }

  [Test]
  public void TernarySearchMaxTests()
  {
    Selection.TernarySearchMax(x => 2 - Math.Pow(x - 2, 2), 0, 3.5).Should().BeApproximately(2, 1e-6);
  }
}
