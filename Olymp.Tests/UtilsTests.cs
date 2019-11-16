using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Olymp.Tests
{
  [TestFixture]
  public class UtilsTests
  {
    [Test]
    public void IsPrimeTests()
    {
      Assert.IsFalse(Utils.IsPrime(-199));
      Assert.IsFalse(Utils.IsPrime(-1));
      Assert.IsFalse(Utils.IsPrime(0));
      Assert.IsFalse(Utils.IsPrime(1));
      Assert.IsTrue(Utils.IsPrime(2));
      Assert.IsTrue(Utils.IsPrime(3));
      Assert.IsFalse(Utils.IsPrime(4));
      Assert.IsTrue(Utils.IsPrime(199));
      Assert.IsFalse(Utils.IsPrime(200));
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
        var actual = Utils.ToBase(i, 2);
        AssertArrayEquals(expected, actual);
      }

      AssertArrayEquals(new[] { 0 }, Utils.ToBase(0, 3));
      AssertArrayEquals(new[] { 1 }, Utils.ToBase(1, 3));
      AssertArrayEquals(new[] { 2 }, Utils.ToBase(2, 3));
      AssertArrayEquals(new[] { 1, 0 }, Utils.ToBase(3, 3));
      AssertArrayEquals(new[] { 2, 2, 2 }, Utils.ToBase(26, 3));
      AssertArrayEquals(new[] { 1, 0, 0, 0 }, Utils.ToBase(27, 3));
    }

    [Test]
    public void ToLongTests()
    {
      for (int i = 0; i < 1024; i++)
      {
        var arg = Convert.ToString(i, 2).Select(c => c - '0').ToArray();
        Assert.AreEqual(i, Utils.ToLong(arg, 2));
      }

      Assert.AreEqual(0, Utils.ToLong(new[] { 0 }, 3));
      Assert.AreEqual(1, Utils.ToLong(new[] { 1 }, 3));
      Assert.AreEqual(2, Utils.ToLong(new[] { 2 }, 3));
      Assert.AreEqual(3, Utils.ToLong(new[] { 1, 0 }, 3));
      Assert.AreEqual(26, Utils.ToLong(new[] { 2, 2, 2 }, 3));
      Assert.AreEqual(27, Utils.ToLong(new[] { 1, 0, 0, 0 }, 3));
    }

    [Test]
    public void CompactTests()
    {
      int[] Call(IEnumerable<int> a) => Utils.Compact(a).ToArray();

      Assert.That(Call(new[] { 0 }), Is.EquivalentTo(new[] { 0 }));
      Assert.That(Call(new[] { 1 }), Is.EquivalentTo(new[] { 1 }));
      Assert.That(Call(new[] { 0, 0, 0 }), Is.EquivalentTo(new[] { 0 }));
      Assert.That(Call(new[] { 1, 0, 1 }), Is.EquivalentTo(new[] { 1, 0, 1 }));
      Assert.That(Call(new[] { 1, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 1, 0, 1, 0 }));
      Assert.That(Call(new[] { 1, 2, 3, 4, 5 }), Is.EquivalentTo(new[] { 1, 2, 3, 4, 5 }));
      Assert.That(Call(new[] { 1, 1, 1, 2, 2, 2, 0, 0, 3, 1, 2 }), Is.EquivalentTo(new[] { 1, 2, 0, 3, 1, 2 }));
      Assert.That(Call(new[] { 0, 0, 1, 1, 1, 0 }), Is.EquivalentTo(new[] { 0, 1, 0 }));
    }
  }
}
