using System.Linq;
using NUnit.Framework;
using Olymp.DataStructures;

namespace Olymp.Tests.DataStructures;

[TestFixture]
public class BitTests
{
  [Test]
  public void SumTest()
  {
    var a = new[] { 21, -14, 19, -41, 3, 35, -26, 35, 23, -36, -27, 6, 37, -23, 45, -8, -15, -29, 21, 0 };
    var t = new Bit(a);
    for (int i = 0; i < a.Length; i++)
    {
      Assert.That(t.Sum(i), Is.EqualTo(a[..(i + 1)].Sum()));
      for (int j = i; j < a.Length; j++)
        Assert.That(t.Sum(i, j), Is.EqualTo(a[i..(j + 1)].Sum()));
    }
  }

  [Test]
  public void SumAfterChangeTest()
  {
    var a = new[] { -1, -2, 0, 5, 5, 3 };

    var t = new Bit(a);

    Assert.That(t.Sum(0, 1), Is.EqualTo(-3));
    t.Add(1, 2);
    Assert.That(t.Sum(0, 1), Is.EqualTo(-1));

    Assert.That(t.Sum(2, 5), Is.EqualTo(13));
    t.Add(3, 1);
    t.Add(4, -2);
    Assert.That(t.Sum(2, 5), Is.EqualTo(12));
  }
}