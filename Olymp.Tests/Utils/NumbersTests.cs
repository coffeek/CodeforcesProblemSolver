using System;
using FluentAssertions;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils;

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
    
  public void TestDigitsCount(Func<int, int> digitsCount)
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
}
