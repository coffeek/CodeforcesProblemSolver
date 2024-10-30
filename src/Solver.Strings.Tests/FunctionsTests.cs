namespace Solver.Strings.Tests;

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

  [TestCase("", "")]
  [TestCase("a", "a")]
  [TestCase("abc", "a")]
  [TestCase("abccba", "abccba")]
  [TestCase("baba", "bab")]
  [TestCase("bababc", "babab")]
  [TestCase("cababc", "aba")]
  [TestCase("cababa", "ababa")]
  public void LongestPalindromeTest(string s, string expected)
  {
    Functions.LongestPalindrome(s).Should().Be(expected);
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
