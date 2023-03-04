using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils;

[TestFixture]
public class FunctionsTests
{
  [Test]
  public void IsPrimeTests()
  {
    Assert.IsFalse(Functions.IsPrime(-199));
    Assert.IsFalse(Functions.IsPrime(-1));
    Assert.IsFalse(Functions.IsPrime(0));
    Assert.IsFalse(Functions.IsPrime(1));
    Assert.IsTrue(Functions.IsPrime(2));
    Assert.IsTrue(Functions.IsPrime(3));
    Assert.IsFalse(Functions.IsPrime(4));
    Assert.IsTrue(Functions.IsPrime(199));
    Assert.IsFalse(Functions.IsPrime(200));
  }

  private static void AssertArrayEquals<T>(T[] expected, T[] actual)
  {
    Assert.AreEqual(expected.Length, actual.Length);
    for (int j = 0; j < expected.Length; j++)
      Assert.AreEqual(expected[j], actual[j]);
  }

  [Test]
  public void ToBaseTests()
  {
    for (int i = 0; i < 1024; i++)
    {
      var expected = Convert.ToString(i, 2).Select(c => c - '0').ToArray();
      var actual = Functions.ToBase(i, 2);
      AssertArrayEquals(expected, actual);
    }

    AssertArrayEquals(new[] { 0 }, Functions.ToBase(0, 3));
    AssertArrayEquals(new[] { 1 }, Functions.ToBase(1, 3));
    AssertArrayEquals(new[] { 2 }, Functions.ToBase(2, 3));
    AssertArrayEquals(new[] { 1, 0 }, Functions.ToBase(3, 3));
    AssertArrayEquals(new[] { 2, 2, 2 }, Functions.ToBase(26, 3));
    AssertArrayEquals(new[] { 1, 0, 0, 0 }, Functions.ToBase(27, 3));
  }

  [Test]
  public void ToLongTests()
  {
    for (int i = 0; i < 1024; i++)
    {
      var arg = Convert.ToString(i, 2).Select(c => c - '0').ToArray();
      Assert.AreEqual(i, Functions.ToLong(arg, 2));
    }

    Assert.AreEqual(0, Functions.ToLong(new[] { 0 }, 3));
    Assert.AreEqual(1, Functions.ToLong(new[] { 1 }, 3));
    Assert.AreEqual(2, Functions.ToLong(new[] { 2 }, 3));
    Assert.AreEqual(3, Functions.ToLong(new[] { 1, 0 }, 3));
    Assert.AreEqual(26, Functions.ToLong(new[] { 2, 2, 2 }, 3));
    Assert.AreEqual(27, Functions.ToLong(new[] { 1, 0, 0, 0 }, 3));
  }

  [Test]
  public void CompactTests()
  {
    static int[] Call(IEnumerable<int> a) => Functions.Compact(a).ToArray();

    Assert.That(Call(new[] { 0 }), Is.EquivalentTo(new[] { 0 }));
    Assert.That(Call(new[] { 1 }), Is.EquivalentTo(new[] { 1 }));
    Assert.That(Call(new[] { 0, 0, 0 }), Is.EquivalentTo(new[] { 0 }));
    Assert.That(Call(new[] { 1, 0, 1 }), Is.EquivalentTo(new[] { 1, 0, 1 }));
    Assert.That(Call(new[] { 1, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 1, 0, 1, 0 }));
    Assert.That(Call(new[] { 1, 2, 3, 4, 5 }), Is.EquivalentTo(new[] { 1, 2, 3, 4, 5 }));
    Assert.That(Call(new[] { 1, 1, 1, 2, 2, 2, 0, 0, 3, 1, 2 }), Is.EquivalentTo(new[] { 1, 2, 0, 3, 1, 2 }));
    Assert.That(Call(new[] { 0, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 0, 1, 0 }));
  }

  [Test]
  public void UpperBoundTests()
  {
    Assert.That(Functions.UpperBound(new int[] { }, 1), Is.EqualTo(0));

    var f = (Action<int[]>)(a =>
    {
      Assert.That(Functions.UpperBound(a, -1), Is.EqualTo(0));
      for (int i = 0; i < 10; i++)
      {
        var expected = Enumerable.Range(0, a.Length).Cast<int?>().FirstOrDefault(j => a[j.Value] > i) ?? a.Length;
        Assert.That(Functions.UpperBound(a, i), Is.EqualTo(expected));
      }
    });

    f(new[] { 0 });
    f(new[] { 9 });
    f(new[] { 0, 0 });
    f(new[] { 1, 1, 1 });
    f(new[] { 1, 2, 3 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9 });
    f(new[] { 0, 1, 1, 3, 4, 6, 6, 7, 8, 9, 9 });
  }

  [Test]
  public void GcdTest()
  {
    Functions.Gcd(0, 0).Should().Be(0);
    Functions.Gcd(0, 1).Should().Be(0);
    Functions.Gcd(1, 0).Should().Be(0);
    Functions.Gcd(1, 1).Should().Be(1);
    Functions.Gcd(12, 4).Should().Be(4);
    Functions.Gcd(12, 9).Should().Be(3);
    Functions.Gcd(12, 7).Should().Be(1);

    Functions.Gcd().Should().Be(0);
    Functions.Gcd(16).Should().Be(16);
    Functions.Gcd(12, 24, 6).Should().Be(6);
    Functions.Gcd(10, 7, 13, 1024).Should().Be(1);
  }

  [Test]
  public void PrimeDivisorsTest()
  {
    Functions.PrimeDivisors(0).Should().BeEmpty();
    Functions.PrimeDivisors(1).Should().BeEmpty();
    Functions.PrimeDivisors(5).Should().BeEquivalentTo(5);
    Functions.PrimeDivisors(10).Should().BeEquivalentTo(2, 5);
    Functions.PrimeDivisors(12).Should().BeEquivalentTo(2, 2, 3);
    Functions.PrimeDivisors(36).Should().BeEquivalentTo(2, 2, 3, 3);
    Functions.PrimeDivisors(1024).Should().BeEquivalentTo(2, 2, 2, 2, 2, 2, 2, 2, 2, 2);
  }

  [Test]
  public void CountsTest()
  {
    Functions.Counts(Array.Empty<int>()).Should().BeEquivalentTo(new Dictionary<int, int>());
      
    Functions.Counts(1).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [1] = 1
    });
      
    Functions.Counts(1, 1, 1).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [1] = 3
    });
      
    Functions.Counts(59, -2, 1, 1, -1, 59, -2).Should().BeEquivalentTo(new Dictionary<int, int>
    {
      [59] = 2,
      [-2] = 2,
      [1] = 2,
      [-1] = 1
    });
  }
}
