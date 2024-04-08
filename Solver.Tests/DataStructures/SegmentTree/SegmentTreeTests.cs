using Solver.DataStructures.SegmentTree;

namespace Solver.Tests.DataStructures.SegmentTree;

[TestFixture]
public class SegmentTreeTests
{
  [Test]
  public void TestQuery()
  {
    var data = new[] { 0, 1, 10, 5, 0, 1, 2, 17, 18, 16 };
    var t = new SegmentTree<int>(data, (x, y) => x + y);
    CheckQueriesCorrectness(t, data);
  }

  [Test]
  public void TestUpdate()
  {
    var data = new[] { 0, 1, 10, 5, 0, 1, 2, 17, 18, 16 };
    var t = new SegmentTree<int>(data, (x, y) => x + y);
    for (int i = 0; i < data.Length; i++)
    {
      data[i] += 3;
      t.Update(i, data[i]);
      CheckQueriesCorrectness(t, data);
    }
  }

  private static void CheckQueriesCorrectness(SegmentTree<int> t, int[] data)
  {
    for (int i = 0; i < data.Length; i++)
    for (int j = i; j < data.Length; j++)
    {
      t.Query(i, j).Should().Be(data[i..(j + 1)].Sum(), "Query({0}, {1})", i, j);
    }
  }

}
