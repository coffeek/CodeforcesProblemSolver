using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Solver.DataStructures.Bit;

namespace Solver.Tests.DataStructures.Bit;

[TestFixture]
public class MaxBitTests
{
  [TestCase(new[] { 10, 9, 2, 5, 3, 7, 101, 18 })]
  [TestCase(new[] { 21, -14, 19, -41, 3, 35, -26, 35, 23, -36, -27, 6, 37, -23, 45, -8, -15, -29, 21, 0 })]
  public void MaxTest(int[] a)
  {
    CheckBit(new MaxBit(a), a);
  }

  [Test]
  public void UpdateTest()
  {
    var a = new[] { 0, 0, 0 };
    var t = new MaxBit(3);
    CheckBit(t, a);

    t.Update(0, 10);
    a[0] = 10;
    CheckBit(t, a);

    t.Update(0, 15);
    a[0] = 15;
    CheckBit(t, a);

    t.Update(2, 3);
    a[2] = 5;
    CheckBit(t, a);

    t.Update(1, 1);
    a[1] = 1;
    CheckBit(t, a);
  }

  [Test]
  public void UpdateTest2()
  {
    var a = new[] { 21, -14, 19, -41, 3, 35, -26, 35, 23, -36, -27, 6, 37, -23, 45, -8, -15, -29, 21, 0 };
    var t = new MaxBit(a);
    for (int i = 0; i < a.Length; i++)
    {
      t.Update(i, i + 50);
      a[i] = i + 50;
      CheckBit(t, a);
    }
  }

  private static void CheckBit(MaxBit t, int[] a)
  {
    for (int i = 0; i < a.Length; i++)
      t.Max(i).Should().Be(a[..(i + 1)].Max());
  }
}
