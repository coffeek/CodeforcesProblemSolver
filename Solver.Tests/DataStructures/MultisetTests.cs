using FluentAssertions;
using NUnit.Framework;
using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class MultisetTests
{
  [Test]
  public void Constructor()
  {
    var set = new Multiset<int>(new[] { 10, 1, 10, 0, 0 });
    set.Count.Should().Be(5);
    set.CountOf(10).Should().Be(2);
    set.CountOf(1).Should().Be(1);
    set.CountOf(0).Should().Be(2);
    set.CountOf(2).Should().Be(0);
    set.Contains(10).Should().BeTrue();
    set.Contains(1).Should().BeTrue();
    set.Contains(0).Should().BeTrue();
    set.Contains(2).Should().BeFalse();
  }
  
  [Test]
  public void AddItems()
  {
    var set = new Multiset<int>();
    set.Count.Should().Be(0);
    set.Contains(1).Should().BeFalse();
    set.CountOf(1).Should().Be(0);
    
    set.Add(1);
    set.Count.Should().Be(1);
    set.Contains(1).Should().BeTrue();
    set.CountOf(1).Should().Be(1);
    
    set.Add(1);
    set.Count.Should().Be(2);
    set.Contains(1).Should().BeTrue();
    set.CountOf(1).Should().Be(2);
    
    set.Contains(-1).Should().BeFalse();
    set.CountOf(-1).Should().Be(0);
    
    set.Add(-1);
    set.Count.Should().Be(3);
    set.Contains(-1).Should().BeTrue();
    set.CountOf(-1).Should().Be(1);
  }

  [Test]
  public void RemoveItems()
  {
    var set = new Multiset<int>(new[] { 10, 1, 10, 0, 0 });
    
    set.Remove(10).Should().BeTrue();
    set.Count.Should().Be(4);
    set.CountOf(10).Should().Be(1);
    set.Contains(10).Should().BeTrue();
    
    set.Remove(10).Should().BeTrue();
    set.Count.Should().Be(3);
    set.CountOf(10).Should().Be(0);
    set.Contains(10).Should().BeFalse();
    
    set.Remove(5).Should().BeFalse();
    set.Count.Should().Be(3);
    set.CountOf(5).Should().Be(0);
    set.Contains(5).Should().BeFalse();
    
    set.Remove(1).Should().BeTrue();
    set.Count.Should().Be(2);
    set.CountOf(1).Should().Be(0);
    set.Contains(1).Should().BeFalse();
    
    set.Remove(0).Should().BeTrue();
    set.Count.Should().Be(1);
    set.CountOf(0).Should().Be(1);
    set.Contains(0).Should().BeTrue();
    
    set.Remove(0).Should().BeTrue();
    set.Count.Should().Be(0);
    set.CountOf(0).Should().Be(0);
    set.Contains(0).Should().BeFalse();
  }
}
