using FluentAssertions;
using NUnit.Framework;
using Olymp.DataStructures;

namespace Olymp.Tests.DataStructures;

[TestFixture]
public class PriorityQueueTests
{
  [Test]
  public void EnqueueTest()
  {
    var q = new PriorityQueue<int>();
    q.Enqueue(10);
    q.Top.Should().Be(10);
    q.Enqueue(9);
    q.Top.Should().Be(9);
    q.Enqueue(10);
    q.Top.Should().Be(9);
    q.Enqueue(5);
    q.Top.Should().Be(5);
    q.Enqueue(-1);
    q.Top.Should().Be(-1);
      
    q.Count.Should().Be(5);
  }
    
  [Test]
  public void DequeueTest()
  {
    var q = new PriorityQueue<int>();
    var arr = new[] { 10, -1, 20, 7, 10, 0, 1, 0 };
    foreach (var num in arr)
      q.Enqueue(num);

    q.Count.Should().Be(arr.Length);
      
    q.Top.Should().Be(-1);
      
    q.Dequeue().Should().Be(-1);
    q.Top.Should().Be(0);
      
    q.Dequeue().Should().Be(0);
    q.Top.Should().Be(0);
      
    q.Dequeue().Should().Be(0);
    q.Top.Should().Be(1);
      
    q.Dequeue().Should().Be(1);
    q.Top.Should().Be(7);
      
    q.Dequeue().Should().Be(7);
    q.Top.Should().Be(10);
      
    q.Count.Should().Be(arr.Length - 5);
  }
}