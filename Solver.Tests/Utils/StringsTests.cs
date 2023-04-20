using System;
using FluentAssertions;
using NUnit.Framework;
using Solver.Utils;

namespace Solver.Tests.Utils;

[TestFixture]
public class StringsTests
{
  [Test]
  public void IsPalindromeTest()
  {
    Strings.IsPalindrome("a").Should().BeTrue();
    Strings.IsPalindrome("aba").Should().BeTrue();
    Strings.IsPalindrome("aa").Should().BeTrue();
    Strings.IsPalindrome("caccac").Should().BeTrue();
    Strings.IsPalindrome("ca").Should().BeFalse();
    Strings.IsPalindrome("aac").Should().BeFalse();
    Strings.IsPalindrome("abcdef").Should().BeFalse();
  }
  
  [Test]
  public void ZFuncTest()
  {
    Strings.ZFunc("").Should().BeEmpty();
    Strings.ZFunc("a").Should().BeEquivalentTo(new[] { 0 });
    Strings.ZFunc("aaaaa").Should().BeEquivalentTo(new[] { 0, 4, 3, 2, 1 });
    Strings.ZFunc("aaabaab").Should().BeEquivalentTo(new[] { 0, 2, 1, 0, 2, 1, 0 });
    Strings.ZFunc("abacaba").Should().BeEquivalentTo(new[] { 0, 0, 1, 0, 3, 0, 1 });
  }

  [Test]
  public void ZMatchTest()
  {
    CheckMatch(Strings.ZMatch);
  }

  [Test]
  public void PiFuncTest()
  {
    Strings.PiFunc("").Should().BeEmpty();
    Strings.PiFunc("a").Should().BeEquivalentTo(new[] { 0 });
    Strings.PiFunc("abcabcd").Should().BeEquivalentTo(new[] { 0, 0, 0, 1, 2, 3, 0 });
    Strings.PiFunc("aabaaab").Should().BeEquivalentTo(new[] { 0, 1, 0, 1, 2, 2, 3 });
  }

  [Test]
  public void KmpMatchTest()
  {
    CheckMatch(Strings.KmpMatch);
  }

  [Test]
  public void FastIntJoinTest()
  {
    Strings.FastIntJoin(" ", new[] { 1, 0, -44, -1899923 }).Should().Be("1 0 -44 -1899923");
    Strings.FastIntJoin(" ", new[] { 0 }).Should().Be("0");
    Strings.FastIntJoin(" ", new[] { -10 }).Should().Be("-10");
    Strings.FastIntJoin(" ", new int[] { }).Should().Be("");
  }

  private static void CheckMatch(Func<string, string, int> match)
  {
    match("abc", "").Should().Be(-1);
    match("", "").Should().Be(-1);
    match("", "abc").Should().Be(-1);
    match("abc", "abcd").Should().Be(-1);
    match("abc", "x").Should().Be(-1);
    match("abcabcd", "abc").Should().Be(0);
    match("abcabcd", "bc").Should().Be(1);
    match("abcabcd", "bcd").Should().Be(4);
    match("abcabcd", "bbcd").Should().Be(-1);
  }
}
