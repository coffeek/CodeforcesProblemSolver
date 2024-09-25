namespace Solver.DataStructures.Tests;

[TestFixture]
public class TrieTests
{
  [Test]
  public void Test()
  {
    var t = new Trie(new[] { "apple", "pen", "applepen", "pine", "pineapple" });
    t.Contains("apple").Should().BeTrue();
    t.Contains("pen").Should().BeTrue();
    t.Contains("applepen").Should().BeTrue();
    t.Contains("pin").Should().BeFalse();
    t.Contains("pinea").Should().BeFalse();
    t.Contains("").Should().BeFalse();
    t.Contains("pineapplepen").Should().BeFalse();
  }
}
