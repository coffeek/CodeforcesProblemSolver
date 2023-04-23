using FluentAssertions;
using NUnit.Framework;
using Solver.Strings;

namespace Solver.Tests.Strings;

public class FunctionsTests
{
  [Test]
  public void IsPalindromeTest()
  {
    Functions.IsPalindrome("a").Should().BeTrue();
    Functions.IsPalindrome("aba").Should().BeTrue();
    Functions.IsPalindrome("aa").Should().BeTrue();
    Functions.IsPalindrome("caccac").Should().BeTrue();
    Functions.IsPalindrome("ca").Should().BeFalse();
    Functions.IsPalindrome("aac").Should().BeFalse();
    Functions.IsPalindrome("abcdef").Should().BeFalse();
  }
  
  [Test]
  public void FastIntJoinTest()
  {
    Functions.FastIntJoin(" ", new[] { 1, 0, -44, -1899923 }).Should().Be("1 0 -44 -1899923");
    Functions.FastIntJoin(" ", new[] { 0 }).Should().Be("0");
    Functions.FastIntJoin(" ", new[] { -10 }).Should().Be("-10");
    Functions.FastIntJoin(" ", new int[] { }).Should().Be("");
  }
}
