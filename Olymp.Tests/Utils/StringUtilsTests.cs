using System;
using FluentAssertions;
using NUnit.Framework;
using Olymp.Utils;

namespace Olymp.Tests.Utils;

[TestFixture]
public class StringUtilsTests
{
  [Test]
  public void ZFuncTest()
  {
    StringUtils.ZFunc("").Should().BeEmpty();
    StringUtils.ZFunc("a").Should().BeEquivalentTo(new[] { 0 });
    StringUtils.ZFunc("aaaaa").Should().BeEquivalentTo(new[] { 0, 4, 3, 2, 1 });
    StringUtils.ZFunc("aaabaab").Should().BeEquivalentTo(new[] { 0, 2, 1, 0, 2, 1, 0 });
    StringUtils.ZFunc("abacaba").Should().BeEquivalentTo(new[] { 0, 0, 1, 0, 3, 0, 1 });
  }

  [Test]
  public void ZMatchTest()
  {
    CheckMatch(StringUtils.ZMatch);
  }

  [Test]
  public void PiFuncTest()
  {
    StringUtils.PiFunc("").Should().BeEmpty();
    StringUtils.PiFunc("a").Should().BeEquivalentTo(new[] { 0 });
    StringUtils.PiFunc("abcabcd").Should().BeEquivalentTo(new[] { 0, 0, 0, 1, 2, 3, 0 });
    StringUtils.PiFunc("aabaaab").Should().BeEquivalentTo(new[] { 0, 1, 0, 1, 2, 2, 3 });
  }

  [Test]
  public void KmpMatchTest()
  {
    CheckMatch(StringUtils.KmpMatch);
  }

  [Test]
  public void FastIntJoinTest()
  {
    StringUtils.FastIntJoin(" ", new[] { 1, 0, -44, -1899923 }).Should().Be("1 0 -44 -1899923");
    StringUtils.FastIntJoin(" ", new[] { 0 }).Should().Be("0");
    StringUtils.FastIntJoin(" ", new[] { -10 }).Should().Be("-10");
    StringUtils.FastIntJoin(" ", new int[] { }).Should().Be("");
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