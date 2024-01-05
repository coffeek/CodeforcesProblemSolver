using FluentAssertions;
using NUnit.Framework;
using Solver.Utils;

namespace Solver.Tests.Utils;

[TestFixture]
public class BitmasksTests
{
  [TestCase(0u, 0u)]
  [TestCase(1u, 1u << 31)]
  [TestCase(1u << 31, 1u)]
  [TestCase(0b00110110110010110110000110101110u, 0b01110101100001101101001101101100u)]
  public void ReverseBits(uint n, uint expected)
  {
    Bitmasks.ReverseBits(n).Should().Be(expected);
    Bitmasks.ReverseBits2(n).Should().Be(expected);
  }

  [TestCase(0u, 0u)]
  [TestCase(0b1u, 0b1u)]
  [TestCase(0b11u, 0b10u)]
  [TestCase(0b10101010100101u, 0b10000000000000u)]
  [TestCase(uint.MaxValue, 1u << 31)]
  [TestCase((1u << 31) + 1, 1u << 31)]
  public void LargestPower(uint n, uint expected)
  {
    Bitmasks.LargestPower(n).Should().Be(expected);
    Bitmasks.LargestPower2(n).Should().Be(expected);
  }

  [TestCase(0u, 0)]
  [TestCase(0b1u, 1)]
  [TestCase(0b10u, 1)]
  [TestCase(0b111011101110u, 9)]
  [TestCase(uint.MaxValue, 32)]
  public void HammingWeight(uint n, int expected)
  {
    Bitmasks.HammingWeight(n).Should().Be(expected);
    Bitmasks.HammingWeight2(n).Should().Be(expected);
  }

  [TestCase(1, true)]
  [TestCase(2, true)]
  [TestCase(3, false)]
  [TestCase(4, true)]
  [TestCase(0b001000000, true)]
  [TestCase(0b001011000, false)]
  [TestCase(0, false)]
  [TestCase(-1, false)]
  [TestCase(-64, false)]
  [TestCase(int.MaxValue, false)]
  [TestCase(1 << 31, false)]
  [TestCase(1 << 30, true)]
  public void IsPowerOfTwo(int n, bool expected)
  {
    Bitmasks.IsPowerOfTwo(n).Should().Be(expected);
  }

  [TestCase(1, true)]
  [TestCase(2, false)]
  [TestCase(3, false)]
  [TestCase(4, true)]
  [TestCase(0b001010100, false)]
  [TestCase(0b001000000, true)]
  [TestCase(0b010000000, false)]
  [TestCase(0, false)]
  [TestCase(-1, false)]
  [TestCase(-64, false)]
  [TestCase(int.MaxValue, false)]
  [TestCase(1 << 31, false)]
  public void IsPowerOfFour(int n, bool expected)
  {
    Bitmasks.IsPowerOfFour(n).Should().Be(expected);
  }

  [TestCase(0b1001011100, 0b100)]
  [TestCase(0, 0)]
  [TestCase(1, 1)]
  [TestCase(0b111, 1)]
  [TestCase(0b10, 0b10)]
  [TestCase(int.MaxValue, 1)]
  public void LsoTests(int n, int expected)
  {
    Bitmasks.Lso(n).Should().Be(expected);
  }
  
  [TestCase(0b1001011100u, 0b100u)]
  [TestCase(0u, 0u)]
  [TestCase(1u, 1u)]
  [TestCase(0b111u, 1u)]
  [TestCase(0b10u, 0b10u)]
  [TestCase(uint.MaxValue, 1u)]
  [TestCase(uint.MaxValue - 1, 0b10u)]
  public void LsoTests(uint n, uint expected)
  {
    Bitmasks.Lso(n).Should().Be(expected);
  }

  [TestCase(0b1001011100u, 0b1000000000u)]
  [TestCase(0u, 0u)]
  [TestCase(1u, 1u)]
  [TestCase(0b111u, 0b100u)]
  [TestCase(0b10u, 0b10u)]
  [TestCase(uint.MaxValue, 1u << 31)]
  public void MsoTests(uint n, uint expected)
  {
    Bitmasks.Mso(n).Should().Be(expected);
  }
}
