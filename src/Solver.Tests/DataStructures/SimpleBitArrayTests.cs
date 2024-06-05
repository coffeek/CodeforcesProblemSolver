using Solver.DataStructures;

namespace Solver.Tests.DataStructures;

[TestFixture]
public class SimpleBitArrayTests
{
  [Test]
  public void UsageTest()
  {
    var a = new SimpleBitArray(10);
    a.ToString().Should().Be("0");
    a[0].Should().BeFalse();
    a[0] = true;
    a[0].Should().BeTrue();
    a.ToString().Should().Be("1");
    a[0] = false;
    a[0].Should().BeFalse();
    a.ToString().Should().Be("0");
    a[2] = true;
    a[2].Should().BeTrue();
    a.ToString().Should().Be("100");
    a[3] = true;
    a[3].Should().BeTrue();
    a.ToString().Should().Be("1100");
    a[8] = true;
    a[8].Should().BeTrue();
    a.ToString().Should().Be("100001100");
    a[1] = true;
    a[1].Should().BeTrue();
    a.ToString().Should().Be("100001110");
    a[2] = false;
    a[2].Should().BeFalse();
    a.ToString().Should().Be("100001010");
  }
  
  [Test]
  public void Over32Bit()
  {
    var a = new SimpleBitArray(100);
    a.ToString().Should().Be("0 0 0 0");
    a[0].Should().BeFalse();
    a[0] = true;
    a[0].Should().BeTrue();
    a.ToString().Should().Be("1 0 0 0");
    a[31].Should().BeFalse();
    a[31] = true;
    a[31].Should().BeTrue();
    a.ToString().Should().Be("10000000000000000000000000000001 0 0 0");
    a[32].Should().BeFalse();
    a[32] = true;
    a[32].Should().BeTrue();
    a.ToString().Should().Be("10000000000000000000000000000001 1 0 0");
    a[33].Should().BeFalse();
    a[33] = true;
    a[33].Should().BeTrue();
    a.ToString().Should().Be("10000000000000000000000000000001 11 0 0");
    a[99].Should().BeFalse();
    a[99] = true;
    a[99].Should().BeTrue();
    a.ToString().Should().Be("10000000000000000000000000000001 11 0 1000");
  }

  [Test]
  public void InitValue()
  {
    var a = new SimpleBitArray(50, true);
    a.ToString().Should().Be("11111111111111111111111111111111 11111111111111111111111111111111");
  }
}
