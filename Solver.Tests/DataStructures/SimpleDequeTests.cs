using FluentAssertions;
using NUnit.Framework;
using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class SimpleDequeTests
{
  [Test]
  public void PushBack()
  {
    var d = new SimpleDeque<int>(10);
    for (int i = 0; i < 10; i++)
    {
      d.PushBack(i);
      d.Back.Should().Be(i);
      d.Front.Should().Be(0);
    }
    d.Front.Should().Be(0);
    d.Back.Should().Be(9);
  }
    
  [Test]
  public void PushFront()
  {
    var d = new SimpleDeque<int>(10);
    for (int i = 0; i < 10; i++)
    {
      d.PushFront(i);
      d.Back.Should().Be(0);
      d.Front.Should().Be(i);
    }
    d.Front.Should().Be(9);
    d.Back.Should().Be(0);
  }
    
  [Test]
  public void PushPop()
  {
    var d = new SimpleDeque<int>(10);
    d.PushFront(5);
    d.Front.Should().Be(5);
    d.Back.Should().Be(5);
    d.PopBack().Should().Be(5);
    d.PushBack(10);
    d.Front.Should().Be(10);
    d.Back.Should().Be(10);
    d.PushFront(9);
    d.Front.Should().Be(9);
    d.Back.Should().Be(10);
    d.PushFront(8);
    d.Front.Should().Be(8);
    d.Back.Should().Be(10);
    d.PushBack(7);
    d.Front.Should().Be(8);
    d.Back.Should().Be(7);
    d.PopBack().Should().Be(7);
    d.Front.Should().Be(8);
    d.Back.Should().Be(10);
    d.PopFront().Should().Be(8);
    d.Front.Should().Be(9);
    d.Back.Should().Be(10);
  }
    
  [Test]
  public void ToArray()
  {
    var d = new SimpleDeque<int>(10);
    d.ToArray().Should().BeEmpty();
    for (int i = 1; i <= 3; i++)
      d.PushFront(i);
    d.ToArray().Should().BeEquivalentTo(1, 2, 3);
    for (int i = 4; i <= 6; i++)
      d.PushBack(i);
    d.ToArray().Should().BeEquivalentTo(1, 2, 3, 4, 5, 6);
    for (int i = 1; i <= 4; i++)
      d.PopFront();
    d.ToArray().Should().BeEquivalentTo(5, 6);
    d.PopBack();
    d.ToArray().Should().BeEquivalentTo(5);
  }
}
