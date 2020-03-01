using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils
{
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
      Assert.That(Functions.UpperBound(new int[] { }, 1), Is.EqualTo(-1));

      var f = (Action<int[]>)(a =>
      {
        Assert.That(Functions.UpperBound(a, -1), Is.EqualTo(0));
        for (int i = 0; i < 10; i++)
        {
          var expected = Enumerable.Range(0, a.Length).Cast<int?>().FirstOrDefault(j => a[j.Value] > i) ?? -1;
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
  }
}
