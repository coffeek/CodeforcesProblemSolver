using Solver.Strings;

namespace Solver.Tests.Strings;

[TestFixture]
public class CharCounterTests
{
  [Test]
  public void BasicUsage()
  {
    var counter = new CharCounter();
    counter.DistinctCount.Should().Be(0);
    counter.GetCount('a').Should().Be(0);
    counter.Add("asdf");
    counter.DistinctCount.Should().Be(4);
    counter.GetCount('a').Should().Be(1);
    counter.Add("abzaa");
    counter.DistinctCount.Should().Be(6);
    counter.GetCount('a').Should().Be(4);
    counter.Remove('a');
    counter.GetCount('a').Should().Be(3);
    counter.DistinctCount.Should().Be(6);
    counter.Remove('a');
    counter.GetCount('a').Should().Be(2);
    counter.Remove('z');
    counter.GetCount('z').Should().Be(0);
    counter.DistinctCount.Should().Be(5);
    counter.Remove('z');
    counter.GetCount('z').Should().Be(0);
    counter.DistinctCount.Should().Be(5);
  }
}
