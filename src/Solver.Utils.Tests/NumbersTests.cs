namespace Solver.Utils.Tests;

public class NumbersTests
{
  [Theory]
  [InlineData(0, 1)]
  [InlineData(-1, 1)]
  [InlineData(1, 1)]
  [InlineData(-18, 2)]
  [InlineData(18, 2)]
  [InlineData(-1024, 4)]
  [InlineData(99999999, 8)]
  [InlineData(int.MaxValue, 10)]
  [InlineData(int.MinValue, 10)]
  public void FastDigitsCountTest(int n, int expected)
  {
    Numbers.FastDigitsCount(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0, 1)]
  [InlineData(-1, 1)]
  [InlineData(1, 1)]
  [InlineData(-18, 2)]
  [InlineData(18, 2)]
  [InlineData(-1024, 4)]
  [InlineData(99999999, 8)]
  [InlineData(int.MaxValue, 10)]
  [InlineData(int.MinValue, 10)]
  public void DigitsCountTest(int n, int expected)
  {
    Numbers.DigitsCount(n).Should().Be(expected);
  }

  public static IEnumerable<int> ToBaseTestsData = Enumerable.Range(0, 1024);
  
  [Theory]
  [MemberData(nameof(ToBaseTestsData))]
  public void ToBaseTests_Base2(int n)
  {
    var expected = Convert.ToString(n, 2).Select(c => c - '0').ToArray();
    Numbers.ToBase(n, 2).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Theory]
  [InlineData(0, new[] { 0 })]
  [InlineData(1, new[] { 1 })]
  [InlineData(2, new[] { 2 })]
  [InlineData(3, new[] { 1, 0 })]
  [InlineData(26, new[] { 2, 2, 2 })]
  [InlineData(27, new[] { 1, 0, 0, 0 })]
  public void ToBaseTests_Base3(int n, int[] expected)
  {
    Numbers.ToBase(n, 3).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Theory]
  [MemberData(nameof(ToBaseTestsData))]
  public void ToLongTests_Base2(int n)
  {
    var arg = Convert.ToString(n, 2).Select(c => c - '0').ToArray();
    Numbers.ToLong(arg, 2).Should().Be(n);
  }

  [Theory]
  [InlineData(new[] { 0 }, 0)]
  [InlineData(new[] { 1 }, 1)]
  [InlineData(new[] { 2 }, 2)]
  [InlineData(new[] { 1, 0 }, 3)]
  [InlineData(new[] { 2, 2, 2 }, 26)]
  [InlineData(new[] { 1, 0, 0, 0 }, 27)]
  public void ToLongTests_Base3(int[] n, int expected)
  {
    Numbers.ToLong(n, 3).Should().Be(expected);
  }

  [Theory]
  [InlineData(-199, false)]
  [InlineData(-1, false)]
  [InlineData(0, false)]
  [InlineData(1, false)]
  [InlineData(2, true)]
  [InlineData(3, true)]
  [InlineData(4, false)]
  [InlineData(199, true)]
  [InlineData(200, false)]
  public void IsPrimeTests(int x, bool expected)
  {
    Numbers.IsPrime(x).Should().Be(expected);
  }
  
  
  public static int[] EvenTestsDataOdd = new[] {1, -1, 3, 1023, -31, int.MaxValue};
  public static int[] EvenTestsDataEven = new[] {0, 2, -2, 16, -1024, int.MinValue};
  public static long[] EvenTestsDataOddLongs = new[] {1, -1, 3, 1023, -31, long.MaxValue};
  public static long[] EvenTestsDataEvenLongs = new[] {0, 2, -2, 16, -1024, long.MinValue};

  [Theory]
  [MemberData(nameof(EvenTestsDataEven))]
  public void Even_ForEvenIntegers_ReturnsTrue(int value)
  {
    Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataOdd))]
  public void Even_ForOddIntegers_ReturnsFalse(int value)
  {
    Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataOdd))]
  public void Odd_ForOddIntegers_ReturnsTrue(int value)
  {
    Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataEven))]
  public void Odd_ForEvenIntegers_ReturnsFalse(int value)
  {
    Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataEvenLongs))]
  public void Even_ForEvenLongs_ReturnsTrue(long value)
  {
    Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataOddLongs))]
  public void Even_ForOddLongs_ReturnsFalse(long value)
  {
    Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataOddLongs))]
  public void Odd_ForOddLongs_ReturnsTrue(long value)
  {
    Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  [Theory]
  [MemberData(nameof(EvenTestsDataEvenLongs))]
  public void Odd_ForEvenLongs_ReturnsFalse(long value)
  {
    Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
  }

  [Theory]
  [InlineData(0, 0, 0)]
  [InlineData(0, 1, 0)]
  [InlineData(1, 0, 0)]
  [InlineData(1, 1, 1)]
  [InlineData(12, 4, 4)]
  [InlineData(12, 9, 3)]
  [InlineData(12, 7, 1)]
  public void Gcd_Of2Numbers(int a, int b, int expected)
  {
    Numbers.Gcd(a, b).Should().Be(expected);
  }

  [Theory]
  [InlineData(new int[] { }, 0)]
  [InlineData(new[] { 16 }, 16)]
  [InlineData(new[] { 12, 24, 6 }, 6)]
  [InlineData(new[] { 10, 7, 13, 1024 }, 1)]
  public void Gcd_OfMultipleNumbers(int[] values, int expected)
  {
    Numbers.Gcd(values).Should().Be(expected);
  }

  [Theory]
  [InlineData(1, 1, 1)]
  [InlineData(12, 4, 12)]
  [InlineData(12, 9, 36)]
  [InlineData(12, 7, 84)]
  public void Lcm_Of2Numbers(int a, int b, int expected)
  {
    Numbers.Lcm(a, b).Should().Be(expected);
  }

  [Theory]
  [InlineData(new int[] { }, 0)]
  [InlineData(new[] { 16 }, 16)]
  [InlineData(new[] { 12, 24, 6 }, 24)]
  [InlineData(new[] { 10, 5, 13, 130 }, 130)]
  public void Lcm_OfMultipleNumbers(int[] values, int expected)
  {
    Numbers.Lcm(values).Should().Be(expected);
  }

  [Fact]
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

  [Theory]
  [InlineData(0, new int[] { })]
  [InlineData(1, new int[] { })]
  [InlineData(5, new[] { 5 })]
  [InlineData(10, new[] { 2, 5 })]
  [InlineData(12, new[] { 2, 2, 3 })]
  [InlineData(36, new[] { 2, 2, 3, 3 })]
  [InlineData(1024, new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 })]
  [InlineData(1000009, new[] { 293, 3413 })]
  public void FactorizeTest(int n, int[] expected)
  {
    Numbers.Factorize(n).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Theory]
  [InlineData(1, 1, 1)]
  [InlineData(1, 0, 1)]
  [InlineData(1, 1000, 1)]
  [InlineData(2, 0, 1)]
  [InlineData(2, 10, 1024)]
  [InlineData(13, 2, 169)]
  [InlineData(13, 13, 302875106592253L)]
  public void BinPowTest(long a, int n, long expected)
  {
    Numbers.BinPow(a, n).Should().Be(expected);
  }

  [Theory]
  [InlineData(1, 1, 10, 1)]
  [InlineData(1, 0, 10, 1)]
  [InlineData(1, 1000, 10, 1)]
  [InlineData(2, 0, 10, 1)]
  [InlineData(2, 10, 2000, 1024)]
  [InlineData(13, 2, 100, 69)]
  [InlineData(13, 13, 1000, 253)]
  [InlineData(595, 703, 991, 342)]
  [InlineData(128903750, 158838191, 679849203, 400886120)]
  [InlineData(1289037501823, 15883819104444, 679849203948, 169858412521)]
  public void BinPowModLongTest(long a, long n, long mod, long expected)
  {
    Numbers.BinPow(a, n, mod).Should().Be(expected);
  }

  [Theory]
  [InlineData(1, 1, 10, 1)]
  [InlineData(1, 0, 10, 1)]
  [InlineData(1, 1000, 10, 1)]
  [InlineData(2, 0, 10, 1)]
  [InlineData(2, 10, 2000, 1024)]
  [InlineData(13, 2, 100, 69)]
  [InlineData(13, 13, 1000, 253)]
  [InlineData(595, 703, 991, 342)]
  [InlineData(128903750, 158838191, 679849203, 400886120)]
  public void BinPowModIntTest(int a, int n, int mod, int expected)
  {
    Numbers.BinPow(a, n, mod).Should().Be(expected);
  }

  [Theory]
  [InlineData(0, 0, 10, 0)]
  [InlineData(1, 0, 10, 0)]
  [InlineData(0, 1, 10, 0)]
  [InlineData(10, 10, 10, 0)]
  [InlineData(11, 11, 10, 1)]
  [InlineData(11, 11, 56, 9)]
  [InlineData(38472837282994394, 45998918239, 10000, 2166)]
  public void BinMulTest(long x, long y, long mod, long expected)
  {
    Numbers.BinMul(x, y, mod).Should().Be(expected);
  }

  [Theory]
  [InlineData(-4, false)]
  [InlineData(0, true)]
  [InlineData(1, true)]
  [InlineData(2, false)]
  [InlineData(3, false)]
  [InlineData(4, true)]
  [InlineData(9, true)]
  [InlineData(10, false)]
  [InlineData(111, false)]
  [InlineData(1024, true)]
  public void IsSquareTest(int n, bool expected)
  {
    Numbers.IsSquare(n).Should().Be(expected);
  }

  [Theory]
  [InlineData(0, 1, 0)]
  [InlineData(1, 1, 1)]
  [InlineData(2, 1, 2)]
  [InlineData(2, 3, 1)]
  [InlineData(9, 3, 3)]
  [InlineData(10, 3, 4)]
  [InlineData(11, 3, 4)]
  public void CeilDivTest(int value, int div, int expected)
  {
    Numbers.CeilDiv(value, div).Should().Be(expected);
  }

  public class SieveTests
  {
    [Fact]
    public void Sieve()
    {
      RunTest(Numbers.Sieve);
    }

    [Fact]
    public void BitSieve()
    {
      RunTest(Numbers.BitSieve);
    }

    [Fact]
    public void EnhancedSieve()
    {
      RunTest(Numbers.EnhancedSieve);
    }

    [Fact]
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
