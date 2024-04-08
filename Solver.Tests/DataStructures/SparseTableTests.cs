using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class SparseTableTests
{
  [Test]
  public void GetMinTest()
  {
    var data = new[]
    {
      new[] { 1, 2, 3, 4, 5 }, new[] { -1, 5, 10, 0, 23, 24, 8, 9 }, new[] { 1324 }, new[] { 10, 1 }
    };
    foreach (var d in data)
    {
      var t = new SparseTable(d);
      for (int i = 0; i < d.Length; i++)
      {
        for (int j = i; j < d.Length; j++)
        {
          var expected = d.Skip(i).Take(j - i + 1).Min();
          Assert.That(t.GetMin(i, j), Is.EqualTo(expected));
          Assert.That(t.GetMinFast(i, j), Is.EqualTo(expected));
        }
      }
    }
  }

  [Test]
  public void GetRightIndexLessThanTest1()
  {
    var d = new[] { 1, 2, 3, 4, 5 };
    var t = new SparseTable(d);
    Assert.That(t.GetRightIndexLessThan(1, 0, 4), Is.EqualTo(-1));
    Assert.That(t.GetRightIndexLessThan(2, 0, 4), Is.EqualTo(0));
    Assert.That(t.GetRightIndexLessThan(3, 0, 4), Is.EqualTo(1));
    Assert.That(t.GetRightIndexLessThan(4, 0, 4), Is.EqualTo(2));
    Assert.That(t.GetRightIndexLessThan(5, 0, 4), Is.EqualTo(3));
  }

  [Test]
  public void GetRightIndexLessThanTest2()
  {
    var d = new[] { 4, 4, 2, 7, 8, 9, 1, 2, 3 };
    var t = new SparseTable(d);
    Assert.That(t.GetRightIndexLessThan(2, 1, 3), Is.EqualTo(-1));
    Assert.That(t.GetRightIndexLessThan(3, 1, 3), Is.EqualTo(2));
    Assert.That(t.GetRightIndexLessThan(5, 1, 3), Is.EqualTo(2));
    Assert.That(t.GetRightIndexLessThan(8, 1, 3), Is.EqualTo(3));
      
    Assert.That(t.GetRightIndexLessThan(8, 4, 4), Is.EqualTo(-1));
    Assert.That(t.GetRightIndexLessThan(9, 4, 4), Is.EqualTo(4));
      
    Assert.That(t.GetRightIndexLessThan(4, 0, 8), Is.EqualTo(8));
    Assert.That(t.GetRightIndexLessThan(3, 0, 8), Is.EqualTo(7));
    Assert.That(t.GetRightIndexLessThan(2, 0, 8), Is.EqualTo(6));
    Assert.That(t.GetRightIndexLessThan(1, 0, 8), Is.EqualTo(-1));
  }
}
