using Solver.Utils;

namespace Solver.Tests.Utils;

[TestFixture]
public class NumbersTests
{
  [Test]
  public void FastDigitsCountTest()
  {
    TestDigitsCount(Numbers.FastDigitsCount);
  }

  [Test]
  public void DigitsCountTest()
  {
    TestDigitsCount(Numbers.DigitsCount);
  }

  [Test]
  public void ToBaseTests()
  {
    for (int i = 0; i < 1024; i++)
    {
      var expected = Convert.ToString(i, 2).Select(c => c - '0').ToArray();
      var actual = Numbers.ToBase(i, 2);
      actual.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    Numbers.ToBase(0, 3).Should().BeEquivalentTo(new[] { 0 }, o => o.WithStrictOrdering());
    Numbers.ToBase(1, 3).Should().BeEquivalentTo(new[] { 1 }, o => o.WithStrictOrdering());
    Numbers.ToBase(2, 3).Should().BeEquivalentTo(new[] { 2 }, o => o.WithStrictOrdering());
    Numbers.ToBase(3, 3).Should().BeEquivalentTo(new[] { 1, 0 }, o => o.WithStrictOrdering());
    Numbers.ToBase(26, 3).Should().BeEquivalentTo(new[] { 2, 2, 2 }, o => o.WithStrictOrdering());
    Numbers.ToBase(27, 3).Should().BeEquivalentTo(new[] { 1, 0, 0, 0 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void ToLongTests()
  {
    for (int i = 0; i < 1024; i++)
    {
      var arg = Convert.ToString(i, 2).Select(c => c - '0').ToArray();
      Numbers.ToLong(arg, 2).Should().Be(i);
    }

    Numbers.ToLong(new[] { 0 }, 3).Should().Be(0);
    Numbers.ToLong(new[] { 1 }, 3).Should().Be(1);
    Numbers.ToLong(new[] { 2 }, 3).Should().Be(2);
    Numbers.ToLong(new[] { 1, 0 }, 3).Should().Be(3);
    Numbers.ToLong(new[] { 2, 2, 2 }, 3).Should().Be(26);
    Numbers.ToLong(new[] { 1, 0, 0, 0 }, 3).Should().Be(27);
  }

  [Test]
  public void IsPrimeTests()
  {
    Numbers.IsPrime(-199).Should().BeFalse();
    Numbers.IsPrime(-1).Should().BeFalse();
    Numbers.IsPrime(0).Should().BeFalse();
    Numbers.IsPrime(1).Should().BeFalse();
    Numbers.IsPrime(2).Should().BeTrue();
    Numbers.IsPrime(3).Should().BeTrue();
    Numbers.IsPrime(4).Should().BeFalse();
    Numbers.IsPrime(199).Should().BeTrue();
    Numbers.IsPrime(200).Should().BeFalse();
  }

  [Test]
  public void EvenIntTests()
  {
    foreach (var value in new[] { 0, 2, -2, 16, -1024, int.MinValue })
      Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
    foreach (var value in new[] { 1, -1, 3, 1023, -31, int.MaxValue })
      Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Test]
  public void OddIntTests()
  {
    foreach (var value in new[] { 0, 2, -2, 16, -1024, int.MinValue })
      Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
    foreach (var value in new[] { 1, -1, 3, 1023, -31, int.MaxValue })
      Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  [Test]
  public void EvenLongTests()
  {
    foreach (var value in new[] { 0, 2, -2, 16, -1024, long.MinValue })
      Numbers.Even(value).Should().BeTrue($"\"{value}\" should be even");
    foreach (var value in new[] { 1, -1, 3, 1023, -31, long.MaxValue })
      Numbers.Even(value).Should().BeFalse($"\"{value}\" should not be even");
  }

  [Test]
  public void OddLongTests()
  {
    foreach (var value in new[] { 0, 2, -2, 16, -1024, long.MinValue })
      Numbers.Odd(value).Should().BeFalse($"\"{value}\" should not be odd");
    foreach (var value in new[] { 1, -1, 3, 1023, -31, long.MaxValue })
      Numbers.Odd(value).Should().BeTrue($"\"{value}\" should be odd");
  }

  public static void TestDigitsCount(Func<int, int> digitsCount)
  {
    digitsCount(0).Should().Be(1);
    digitsCount(-1).Should().Be(1);
    digitsCount(1).Should().Be(1);
    digitsCount(-18).Should().Be(2);
    digitsCount(18).Should().Be(2);
    digitsCount(-1024).Should().Be(4);
    digitsCount(99999999).Should().Be(8);
    digitsCount(int.MaxValue).Should().Be(10);
    digitsCount(int.MinValue).Should().Be(10);
  }

  [Test]
  public void GcdTest()
  {
    Numbers.Gcd(0, 0).Should().Be(0);
    Numbers.Gcd(0, 1).Should().Be(0);
    Numbers.Gcd(1, 0).Should().Be(0);
    Numbers.Gcd(1, 1).Should().Be(1);
    Numbers.Gcd(12, 4).Should().Be(4);
    Numbers.Gcd(12, 9).Should().Be(3);
    Numbers.Gcd(12, 7).Should().Be(1);

    Numbers.Gcd().Should().Be(0);
    Numbers.Gcd(16).Should().Be(16);
    Numbers.Gcd(12, 24, 6).Should().Be(6);
    Numbers.Gcd(10, 7, 13, 1024).Should().Be(1);
  }

  [Test]
  public void LcmTest()
  {
    Numbers.Lcm(1, 1).Should().Be(1);
    Numbers.Lcm(12, 4).Should().Be(12);
    Numbers.Lcm(12, 9).Should().Be(36);
    Numbers.Lcm(12, 7).Should().Be(84);

    Numbers.Lcm().Should().Be(0);
    Numbers.Lcm(16).Should().Be(16);
    Numbers.Lcm(12, 24, 6).Should().Be(24);
    Numbers.Lcm(10, 5, 13, 130).Should().Be(130);
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

  [Test]
  public void FactorizeTest()
  {
    Numbers.Factorize(0).Should().BeEmpty();
    Numbers.Factorize(1).Should().BeEmpty();
    Numbers.Factorize(5).Should().BeEquivalentTo(5);
    Numbers.Factorize(10).Should().BeEquivalentTo(2, 5);
    Numbers.Factorize(12).Should().BeEquivalentTo(2, 2, 3);
    Numbers.Factorize(36).Should().BeEquivalentTo(2, 2, 3, 3);
    Numbers.Factorize(1024).Should().BeEquivalentTo(2, 2, 2, 2, 2, 2, 2, 2, 2, 2);
    Numbers.Factorize(1000009).Should().BeEquivalentTo(293, 3413);
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
