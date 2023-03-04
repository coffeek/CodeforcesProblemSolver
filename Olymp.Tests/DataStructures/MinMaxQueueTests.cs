using NUnit.Framework;
using Olymp.DataStructures;

namespace Olymp.Tests.DataStructures;

[TestFixture]
public class MinMaxQueueTests
{
  [Test]
  public void GetMinMaxTest()
  {
    var q = new MinMaxQueue(10);
    q.Enqueue(1);
    Assert.That(q.Min, Is.EqualTo(1));
    Assert.That(q.Max, Is.EqualTo(1));
    q.Enqueue(2);
    Assert.That(q.Min, Is.EqualTo(1));
    Assert.That(q.Max, Is.EqualTo(2));
    q.Dequeue();
    Assert.That(q.Min, Is.EqualTo(2));
    Assert.That(q.Max, Is.EqualTo(2));
    q.Enqueue(1);
    q.Enqueue(20);
    q.Enqueue(3);
    Assert.That(q.Min, Is.EqualTo(1));
    Assert.That(q.Max, Is.EqualTo(20));
    q.Dequeue();
    q.Dequeue();
    Assert.That(q.Min, Is.EqualTo(3));
    Assert.That(q.Max, Is.EqualTo(20));
  }
}