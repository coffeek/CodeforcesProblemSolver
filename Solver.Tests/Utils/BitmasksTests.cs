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
}
