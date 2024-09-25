using Solver.DataStructures.Bit;

namespace Solver.DataStructures.Tests.Bit;

[TestFixture]
public class SumBitTests
{
  [Test]
  public void SumTest()
  {
    var a = new[] { 21, -14, 19, -41, 3, 35, -26, 35, 23, -36, -27, 6, 37, -23, 45, -8, -15, -29, 21, 0 };
    var t = new SumBit(a);
    CheckBit(t, a);
  }
  
  [Test]
  public void AddTest()
  {
    var a = new[] { 0, 0, 0 };
    var t = new SumBit(3);
    
    CheckBit(t, a);
    
    t.Add(0, 10);
    a[0] += 10;
    
    CheckBit(t, a);
    
    t.Add(0, 5);
    a[0] += 5;

    CheckBit(t, a);
    
    t.Add(2, 3);
    a[2] += 5;
  }

  [Test]
  public void SumAfterChangeTest()
  {
    var a = new[] { -1, -2, 0, 5, 5, 3 };

    var t = new SumBit(a);

    t.Sum(0, 1).Should().Be(-3);
    t.Add(1, 2);
    t.Sum(0, 1).Should().Be(-1);

    t.Sum(2, 5).Should().Be(13);
    t.Add(3, 1);
    t.Add(4, -2);
    t.Sum(2, 5).Should().Be(12);
  }

  private static void CheckBit(SumBit t, int[] a)
  {
    for (int i = 0; i < a.Length; i++)
    {
      t.Sum(i).Should().Be(a[..(i + 1)].Sum());
      for (int j = i; j < a.Length; j++)
        t.Sum(i, j).Should().Be(a[i..(j + 1)].Sum());
    }
  }
}
