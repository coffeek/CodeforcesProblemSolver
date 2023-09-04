using FluentAssertions;
using NUnit.Framework;
using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class LinkedListTests
{
  public class HasCycleTests
  {
    [Test]
    public void Test1()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      var node4 = new ListNode<int>(4);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node4;
      node4.Next = node3;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test2()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      var node4 = new ListNode<int>(4);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node4;
      node4.Next = node2;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test3()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      var node4 = new ListNode<int>(4);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node4;
      node4.Next = node2;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test4()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      var node4 = new ListNode<int>(4);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node4;
      LinkedListUtils.HasCycle(node1).Should().BeFalse();
    }

    [Test]
    public void Test5()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      node1.Next = node2;
      node2.Next = node1;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test6()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      node1.Next = node2;
      LinkedListUtils.HasCycle(node1).Should().BeFalse();
    }

    [Test]
    public void Test7()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node2;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test8()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      node1.Next = node2;
      node2.Next = node3;
      node3.Next = node1;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test9()
    {
      var node1 = new ListNode<int>(1);
      var node2 = new ListNode<int>(2);
      var node3 = new ListNode<int>(3);
      node1.Next = node2;
      node2.Next = node3;
      LinkedListUtils.HasCycle(node1).Should().BeFalse();
    }

    [Test]
    public void Test10()
    {
      var node1 = new ListNode<int>(1);
      LinkedListUtils.HasCycle(node1).Should().BeFalse();
    }

    [Test]
    public void Test11()
    {
      var node1 = new ListNode<int>(1);
      node1.Next = node1;
      LinkedListUtils.HasCycle(node1).Should().BeTrue();
    }

    [Test]
    public void Test12()
    {
      LinkedListUtils.HasCycle<int>(null).Should().BeFalse();
    }
  }
}
