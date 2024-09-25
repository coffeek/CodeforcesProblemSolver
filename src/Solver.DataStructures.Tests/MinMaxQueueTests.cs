namespace Solver.DataStructures.Tests;

[TestFixture]
public class MinMaxQueueTests
{
  [Test]
  public void GetMinMaxTest()
  {
    var q = new MinMaxQueue(10);
    q.Enqueue(1);
    q.Min.Should().Be(1);
    q.Max.Should().Be(1);
    q.Enqueue(2);
    q.Min.Should().Be(1);
    q.Max.Should().Be(2);
    q.Dequeue();
    q.Min.Should().Be(2);
    q.Max.Should().Be(2);
    q.Enqueue(1);
    q.Enqueue(20);
    q.Enqueue(3);
    q.Min.Should().Be(1);
    q.Max.Should().Be(20);
    q.Dequeue();
    q.Dequeue();
    q.Min.Should().Be(3);
    q.Max.Should().Be(20);
  }
}
