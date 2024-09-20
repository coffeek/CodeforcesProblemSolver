namespace Solver.Utils.Tests;

public class BitmasksTests
{
  [Theory]
  [InlineData(0u, 0u)]
  [InlineData(1u, 1u << 31)]
  [InlineData(1u << 31, 1u)]
  [InlineData(0b00110110110010110110000110101110u, 0b01110101100001101101001101101100u)]
  public void ReverseBits(uint n, uint expected)
  {
    Bitmasks.ReverseBits(n).Should().Be(expected);
    Bitmasks.ReverseBits2(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0u, 0u)]
  [InlineData(0b1u, 0b1u)]
  [InlineData(0b11u, 0b10u)]
  [InlineData(0b10101010100101u, 0b10000000000000u)]
  [InlineData(uint.MaxValue, 1u << 31)]
  [InlineData((1u << 31) + 1, 1u << 31)]
  public void LargestPower(uint n, uint expected)
  {
    Bitmasks.LargestPower(n).Should().Be(expected);
    Bitmasks.LargestPower2(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0u, 0)]
  [InlineData(0b1u, 1)]
  [InlineData(0b10u, 1)]
  [InlineData(0b111011101110u, 9)]
  [InlineData(uint.MaxValue, 32)]
  public void HammingWeight(uint n, int expected)
  {
    Bitmasks.HammingWeight(n).Should().Be(expected);
    Bitmasks.HammingWeight2(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(1, true)]
  [InlineData(2, true)]
  [InlineData(3, false)]
  [InlineData(4, true)]
  [InlineData(0b001000000, true)]
  [InlineData(0b001011000, false)]
  [InlineData(0, false)]
  [InlineData(-1, false)]
  [InlineData(-64, false)]
  [InlineData(int.MaxValue, false)]
  [InlineData(1 << 31, false)]
  [InlineData(1 << 30, true)]
  public void IsPowerOfTwo(int n, bool expected)
  {
    Bitmasks.IsPowerOfTwo(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(1, true)]
  [InlineData(2, false)]
  [InlineData(3, false)]
  [InlineData(4, true)]
  [InlineData(0b001010100, false)]
  [InlineData(0b001000000, true)]
  [InlineData(0b010000000, false)]
  [InlineData(0, false)]
  [InlineData(-1, false)]
  [InlineData(-64, false)]
  [InlineData(int.MaxValue, false)]
  [InlineData(1 << 31, false)]
  public void IsPowerOfFour(int n, bool expected)
  {
    Bitmasks.IsPowerOfFour(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0b1001011100, 0b100)]
  [InlineData(0, 0)]
  [InlineData(1, 1)]
  [InlineData(0b111, 1)]
  [InlineData(0b10, 0b10)]
  [InlineData(int.MaxValue, 1)]
  public void LsoTests(int n, int expected)
  {
    Bitmasks.Lso(n).Should().Be(expected);
  }
  
  [Theory]
  [InlineData(0b1001011100u, 0b100u)]
  [InlineData(0u, 0u)]
  [InlineData(1u, 1u)]
  [InlineData(0b111u, 1u)]
  [InlineData(0b10u, 0b10u)]
  [InlineData(uint.MaxValue, 1u)]
  [InlineData(uint.MaxValue - 1, 0b10u)]
  public void LsoTests_Uint(uint n, uint expected)
  {
    Bitmasks.Lso(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0b1001011100u, 0b1000000000u)]
  [InlineData(0u, 0u)]
  [InlineData(1u, 1u)]
  [InlineData(0b111u, 0b100u)]
  [InlineData(0b10u, 0b10u)]
  [InlineData(uint.MaxValue, 1u << 31)]
  public void MsoTests(uint n, uint expected)
  {
    Bitmasks.Mso(n).Should().Be(expected);
  }
}
