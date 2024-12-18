﻿namespace Solver.Utils.Tests;

[TestFixture]
public class NumbersTests
{
  [TestCase(0, 1)]
  [TestCase(-1, 1)]
  [TestCase(1, 1)]
  [TestCase(-18, 2)]
  [TestCase(18, 2)]
  [TestCase(-1024, 4)]
  [TestCase(99999999, 8)]
  [TestCase(int.MaxValue, 10)]
  [TestCase(int.MinValue, 10)]
  public void FastDigitsCountTest(int n, int expected)
  {
    Numbers.FastDigitsCount(n).Should().Be(expected);
  }

  [TestCase(0, 1)]
  [TestCase(-1, 1)]
  [TestCase(1, 1)]
  [TestCase(-18, 2)]
  [TestCase(18, 2)]
  [TestCase(-1024, 4)]
  [TestCase(99999999, 8)]
  [TestCase(int.MaxValue, 10)]
  [TestCase(int.MinValue, 10)]
  public void DigitsCountTest(int n, int expected)
  {
    Numbers.DigitsCount(n).Should().Be(expected);
  }

  [Test]
  public void ToBaseTests_Base2([Range(0, 1024)] int n)
  {
    var expected = Convert.ToString(n, 2).Select(c => c - '0').ToArray();
    Numbers.ToBase(n, 2).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [TestCase(0, new[] { 0 })]
  [TestCase(1, new[] { 1 })]
  [TestCase(2, new[] { 2 })]
  [TestCase(3, new[] { 1, 0 })]
  [TestCase(26, new[] { 2, 2, 2 })]
  [TestCase(27, new[] { 1, 0, 0, 0 })]
  public void ToBaseTests_Base3(int n, int[] expected)
  {
    Numbers.ToBase(n, 3).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void ToLongTests_Base2([Range(0, 1024)] int n)
  {
    var arg = Convert.ToString(n, 2).Select(c => c - '0').ToArray();
    Numbers.ToLong(arg, 2).Should().Be(n);
  }

  [TestCase(new[] { 0 }, 0)]
  [TestCase(new[] { 1 }, 1)]
  [TestCase(new[] { 2 }, 2)]
  [TestCase(new[] { 1, 0 }, 3)]
  [TestCase(new[] { 2, 2, 2 }, 26)]
  [TestCase(new[] { 1, 0, 0, 0 }, 27)]
  public void ToLongTests_Base3(int[] n, int expected)
  {
    Numbers.ToLong(n, 3).Should().Be(expected);
  }

  [TestCase(-199, false)]
  [TestCase(-1, false)]
  [TestCase(0, false)]
  [TestCase(1, false)]
  [TestCase(2, true)]
  [TestCase(3, true)]
  [TestCase(4, false)]
  [TestCase(199, true)]
  [TestCase(200, false)]
  public void IsPrimeTests(int x, bool expected)
  {
    Numbers.IsPrime(x).Should().Be(expected);
  }

  [Test]
  public void Even_ForEvenIntegers_ReturnsTrue([Values(0, 2, -2, 16, -1024, int.MinValue)] int value)
  {
    Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
  }

  [Test]
  public void Even_ForOddIntegers_ReturnsFalse([Values(1, -1, 3, 1023, -31, int.MaxValue)] int value)
  {
    Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Test]
  public void Odd_ForOddIntegers_ReturnsTrue([Values(1, -1, 3, 1023, -31, int.MaxValue)] int value)
  {
    Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  [Test]
  public void Odd_ForEvenIntegers_ReturnsFalse([Values(0, 2, -2, 16, -1024, int.MinValue)] int value)
  {
    Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
  }

  [Test]
  public void Even_ForEvenLongs_ReturnsTrue([Values(0, 2, -2, 16, -1024, long.MinValue)] long value)
  {
    Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
  }

  [Test]
  public void Even_ForOddLongs_ReturnsFalse([Values(1, -1, 3, 1023, -31, long.MaxValue)] long value)
  {
    Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Test]
  public void Odd_ForOddLongs_ReturnsTrue([Values(1, -1, 3, 1023, -31, long.MaxValue)] long value)
  {
    Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  [Test]
  public void Odd_ForEvenLongs_ReturnsFalse([Values(0, 2, -2, 16, -1024, long.MinValue)] long value)
  {
    Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
  }

  [TestCase(0, 0, 0)]
  [TestCase(0, 1, 0)]
  [TestCase(1, 0, 0)]
  [TestCase(1, 1, 1)]
  [TestCase(12, 4, 4)]
  [TestCase(12, 9, 3)]
  [TestCase(12, 7, 1)]
  public void Gcd_Of2Numbers(int a, int b, int expected)
  {
    Numbers.Gcd(a, b).Should().Be(expected);
  }

  [TestCase(new int[] { }, 0)]
  [TestCase(new[] { 16 }, 16)]
  [TestCase(new[] { 12, 24, 6 }, 6)]
  [TestCase(new[] { 10, 7, 13, 1024 }, 1)]
  public void Gcd_OfMultipleNumbers(int[] values, int expected)
  {
    Numbers.Gcd(values).Should().Be(expected);
  }

  [TestCase(1, 1, 1)]
  [TestCase(12, 4, 12)]
  [TestCase(12, 9, 36)]
  [TestCase(12, 7, 84)]
  public void Lcm_Of2Numbers(int a, int b, int expected)
  {
    Numbers.Lcm(a, b).Should().Be(expected);
  }

  [TestCase(new int[] { }, 0)]
  [TestCase(new[] { 16 }, 16)]
  [TestCase(new[] { 12, 24, 6 }, 24)]
  [TestCase(new[] { 10, 5, 13, 130 }, 130)]
  public void Lcm_OfMultipleNumbers(int[] values, int expected)
  {
    Numbers.Lcm(values).Should().Be(expected);
  }

  [Test]
  public void PhiTest()
  {
    // https://oeis.org/A000010
    var expected = new[]
    {
      1, 1, 2, 2, 4, 2, 6, 4, 6, 4, 10, 4, 12, 6, 8, 8, 16, 6, 18, 8, 12, 10, 22, 8, 20, 12, 18, 12, 28, 8, 30, 16,
      20, 16, 24, 12, 36, 18, 24, 16, 40, 12, 42, 20, 24, 22, 46, 16, 42, 20, 32, 24, 52, 18, 40, 24, 36, 28, 58, 16,
      60, 30, 36, 32, 48, 20, 66, 32, 44
    };
    for (int i = 1; i <= expected.Length; i++)
    {
      Numbers.Phi(i).Should().Be(expected[i - 1], $"phi({i})");
    }
  }

  [TestCase(0, new int[] { })]
  [TestCase(1, new int[] { })]
  [TestCase(5, new[] { 5 })]
  [TestCase(10, new[] { 2, 5 })]
  [TestCase(12, new[] { 2, 2, 3 })]
  [TestCase(36, new[] { 2, 2, 3, 3 })]
  [TestCase(1024, new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 })]
  [TestCase(1000009, new[] { 293, 3413 })]
  public void FactorizeTest(int n, int[] expected)
  {
    Numbers.Factorize(n).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [TestCase(1, 1, 1)]
  [TestCase(1, 0, 1)]
  [TestCase(1, 1000, 1)]
  [TestCase(2, 0, 1)]
  [TestCase(2, 10, 1024)]
  [TestCase(13, 2, 169)]
  [TestCase(13, 13, 302875106592253L)]
  public void BinPowTest(long a, int n, long expected)
  {
    Numbers.BinPow(a, n).Should().Be(expected);
  }

  [TestCase(1, 1, 10, 1)]
  [TestCase(1, 0, 10, 1)]
  [TestCase(1, 1000, 10, 1)]
  [TestCase(2, 0, 10, 1)]
  [TestCase(2, 10, 2000, 1024)]
  [TestCase(13, 2, 100, 69)]
  [TestCase(13, 13, 1000, 253)]
  [TestCase(595, 703, 991, 342)]
  [TestCase(128903750, 158838191, 679849203, 400886120)]
  [TestCase(1289037501823, 15883819104444, 679849203948, 169858412521)]
  public void BinPowModLongTest(long a, long n, long mod, long expected)
  {
    Numbers.BinPow(a, n, mod).Should().Be(expected);
  }

  [TestCase(1, 1, 10, 1)]
  [TestCase(1, 0, 10, 1)]
  [TestCase(1, 1000, 10, 1)]
  [TestCase(2, 0, 10, 1)]
  [TestCase(2, 10, 2000, 1024)]
  [TestCase(13, 2, 100, 69)]
  [TestCase(13, 13, 1000, 253)]
  [TestCase(595, 703, 991, 342)]
  [TestCase(128903750, 158838191, 679849203, 400886120)]
  public void BinPowModIntTest(int a, int n, int mod, int expected)
  {
    Numbers.BinPow(a, n, mod).Should().Be(expected);
  }

  [TestCase(0, 0, 10, 0)]
  [TestCase(1, 0, 10, 0)]
  [TestCase(0, 1, 10, 0)]
  [TestCase(10, 10, 10, 0)]
  [TestCase(11, 11, 10, 1)]
  [TestCase(11, 11, 56, 9)]
  [TestCase(38472837282994394, 45998918239, 10000, 2166)]
  public void BinMulTest(long x, long y, long mod, long expected)
  {
    Numbers.BinMul(x, y, mod).Should().Be(expected);
  }

  [TestCase(-4, false)]
  [TestCase(0, true)]
  [TestCase(1, true)]
  [TestCase(2, false)]
  [TestCase(3, false)]
  [TestCase(4, true)]
  [TestCase(9, true)]
  [TestCase(10, false)]
  [TestCase(111, false)]
  [TestCase(1024, true)]
  public void IsSquareTest(int n, bool expected)
  {
    Numbers.IsSquare(n).Should().Be(expected);
  }

  [TestCase(0, 1, 0)]
  [TestCase(1, 1, 1)]
  [TestCase(2, 1, 2)]
  [TestCase(2, 3, 1)]
  [TestCase(9, 3, 3)]
  [TestCase(10, 3, 4)]
  [TestCase(11, 3, 4)]
  public void CeilDivTest(int value, int div, int expected)
  {
    Numbers.CeilDiv(value, div).Should().Be(expected);
  }
  
  [TestCase(38, 2)]
  [TestCase(0, 0)]
  [TestCase(9999, 9)]
  [TestCase(3333, 3)]
  [TestCase(179, 8)]
  public void DigitalRootTest(int num, int expected)
  {
    Numbers.DigitalRoot(num).Should().Be(expected);
  }

  [TestFixture]
  public class SieveTests
  {
    [Test]
    public void Sieve()
    {
      RunTest(Numbers.Sieve);
    }

    [Test]
    public void BitSieve()
    {
      RunTest(Numbers.BitSieve);
    }

    [Test]
    public void EnhancedSieve()
    {
      RunTest(Numbers.EnhancedSieve);
    }

    [Test]
    public void LinearSieve()
    {
      RunTest(Numbers.LinearSieve);
    }

    private static void RunTest(Func<int, IReadOnlyList<int>> sieve)
    {
      sieve(0).Should().BeEmpty();
      sieve(1).Should().BeEmpty();
      sieve(2).Should().BeEquivalentTo(2);
      sieve(3).Should().BeEquivalentTo(2, 3);
      sieve(101).Should().BeEquivalentTo(
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47,
        53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101);
      sieve(1000000).Should().HaveCount(78498);
    }
  }
}
