using Solver.DataStructures.SegmentTree;

namespace Solver.DataStructures.Tests.SegmentTree;

[TestFixture]
public class UniqueCharCounterTests
{
  [Test]
  public void QueryTest()
  {
    const string s = "abaabcaaooiodmzmammabbxdaasjwo";
    var counter = new UniqueCharCounter(s);
    CheckQueriesCorrectness(counter, s);
  }

  [Test]
  public void TestUpdate()
  {
    const string s = "abaabcaaooiodmzmammabbxdaasjwo";
    var counter = new UniqueCharCounter(s);
    var sb = new StringBuilder(s);
    for (int i = 0; i < s.Length; i++)
    {
      sb[i] += (char)1;
      counter.Update(i, sb[i]);
      CheckQueriesCorrectness(counter, sb.ToString());
    }
  }

  private static void CheckQueriesCorrectness(UniqueCharCounter counter, string s)
  {
    for (int i = 0; i < s.Length; i++)
    for (int j = i; j < s.Length; j++)
    {
      counter.GetCount(i, j).Should().Be(s[i..(j + 1)].Distinct().Count(), "Query({0}, {1})", i, j);
    }
  }
}
