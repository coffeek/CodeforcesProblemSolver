namespace Solver.Utils.Tests;

[TestFixture]
public class CounterTests
{
  [Test]
  public void CountsTest()
  {
    Counter.Counts(Array.Empty<int>()).Should().BeEquivalentTo(new Dictionary<int, int>());
      
    Counter.Counts(1).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [1] = 1
    });
      
    Counter.Counts(1, 1, 1).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [1] = 3
    });
      
    Counter.Counts(59, -2, 1, 1, -1, 59, -2).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [59] = 2,
      [-2] = 2,
      [1] = 2,
      [-1] = 1
    });
  }
}
