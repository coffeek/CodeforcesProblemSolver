using FluentAssertions;
using NUnit.Framework;
using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class SortedMultisetTests
{
  [Test]
  public void Constructor()
  {
    var set = new SortedMultiset<int>(new[] { 10, 1, 10, 2, 2 });
    set.Count.Should().Be(5);
    set.CountOf(10).Should().Be(2);
    set.CountOf(1).Should().Be(1);
    set.CountOf(2).Should().Be(2);
    set.CountOf(3).Should().Be(0);
    set.Contains(10).Should().BeTrue();
    set.Contains(1).Should().BeTrue();
    set.Contains(2).Should().BeTrue();
    set.Contains(3).Should().BeFalse();
    set.Min().Should().Be(1);
    set.Max().Should().Be(10);
  }
  
  [Test]
  public void AddItems()
  {
    var set = new SortedMultiset<int>();
    set.Count.Should().Be(0);
    set.Contains(1).Should().BeFalse();
    set.CountOf(1).Should().Be(0);
    set.Min().Should().Be(default);
    set.Max().Should().Be(default);
    
    set.Add(1);
    set.Count.Should().Be(1);
    set.Contains(1).Should().BeTrue();
    set.CountOf(1).Should().Be(1);
    set.Min().Should().Be(1);
    set.Max().Should().Be(1);
    
    set.Add(1);
    set.Count.Should().Be(2);
    set.Contains(1).Should().BeTrue();
    set.CountOf(1).Should().Be(2);
    set.Min().Should().Be(1);
    set.Max().Should().Be(1);
    
    set.Contains(-1).Should().BeFalse();
    set.CountOf(-1).Should().Be(0);
    
    set.Add(-1);
    set.Count.Should().Be(3);
    set.Contains(-1).Should().BeTrue();
    set.CountOf(-1).Should().Be(1);
    set.Min().Should().Be(-1);
    set.Max().Should().Be(1);
    
    set.Add(int.MaxValue);
    set.Count.Should().Be(4);
    set.Contains(int.MaxValue).Should().BeTrue();
    set.CountOf(int.MaxValue).Should().Be(1);
    set.Min().Should().Be(-1);
    set.Max().Should().Be(int.MaxValue);
  }

  [Test]
  public void RemoveItems()
  {
    var set = new SortedMultiset<int>(new[] { 10, 1, 10, 2, 2 });
    
    set.Remove(10).Should().BeTrue();
    set.Count.Should().Be(4);
    set.CountOf(10).Should().Be(1);
    set.Contains(10).Should().BeTrue();
    set.Min().Should().Be(1);
    set.Max().Should().Be(10);
    
    set.Remove(10).Should().BeTrue();
    set.Count.Should().Be(3);
    set.CountOf(10).Should().Be(0);
    set.Contains(10).Should().BeFalse();
    set.Min().Should().Be(1);
    set.Max().Should().Be(2);
    
    set.Remove(5).Should().BeFalse();
    set.Count.Should().Be(3);
    set.CountOf(5).Should().Be(0);
    set.Contains(5).Should().BeFalse();
    
    set.Remove(1).Should().BeTrue();
    set.Count.Should().Be(2);
    set.CountOf(1).Should().Be(0);
    set.Contains(1).Should().BeFalse();
    set.Min().Should().Be(2);
    set.Max().Should().Be(2);
    
    set.Remove(2).Should().BeTrue();
    set.Count.Should().Be(1);
    set.CountOf(2).Should().Be(1);
    set.Contains(2).Should().BeTrue();
    set.Min().Should().Be(2);
    set.Max().Should().Be(2);
    
    set.Remove(2).Should().BeTrue();
    set.Count.Should().Be(0);
    set.CountOf(2).Should().Be(0);
    set.Contains(2).Should().BeFalse();
    
    set.Min().Should().Be(default);
    set.Max().Should().Be(default);
  }
}
