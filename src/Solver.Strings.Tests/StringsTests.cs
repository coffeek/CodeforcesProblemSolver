namespace Solver.Strings.Tests;

[TestFixture]
public class StringsTests
{
  [Test]
  public void ZFuncTest()
  {
    Match.ZFunc("").Should().BeEmpty();
    Match.ZFunc("a").Should().BeEquivalentTo(new[] { 0 });
    Match.ZFunc("aaaaa").Should().BeEquivalentTo(new[] { 0, 4, 3, 2, 1 });
    Match.ZFunc("aaabaab").Should().BeEquivalentTo(new[] { 0, 2, 1, 0, 2, 1, 0 });
    Match.ZFunc("abacaba").Should().BeEquivalentTo(new[] { 0, 0, 1, 0, 3, 0, 1 });
  }

  [Test]
  public void ZMatchTest()
  {
    CheckMatch(Match.ZMatch);
  }

  [Test]
  public void PiFuncTest()
  {
    Match.PiFunc("").Should().BeEmpty();
    Match.PiFunc("a").Should().BeEquivalentTo(new[] { 0 });
    Match.PiFunc("abcabcd").Should().BeEquivalentTo(new[] { 0, 0, 0, 1, 2, 3, 0 });
    Match.PiFunc("aabaaab").Should().BeEquivalentTo(new[] { 0, 1, 0, 1, 2, 2, 3 });
  }

  [Test]
  public void KmpMatchTest()
  {
    CheckMatch(Match.KmpMatch);
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
