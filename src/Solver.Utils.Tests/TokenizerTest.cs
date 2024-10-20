namespace Solver.Utils.Tests;

[TestFixture]
public class TokenizerTest
{
  [Test]
  public void TestParseEmptyString()
  {
    var input = new StringReader("");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadToken().Should().BeNull();
  }

  [Test]
  public void TestParseTokensSingleLine()
  {
    var input = new StringReader(" aSdf A 1234 *.%()(JFLD __   ad   a  \t");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadToken().Should().Be("aSdf");
    tokenizer.ReadToken().Should().Be("A");
    tokenizer.ReadToken().Should().Be("1234");
    tokenizer.ReadToken().Should().Be("*.%()(JFLD");
    tokenizer.ReadToken().Should().Be("__");
    tokenizer.ReadToken().Should().Be("ad");
    tokenizer.ReadToken().Should().Be("a");
    tokenizer.ReadToken().Should().BeNull();
  }

  [Test]
  public void TestParseTokensMultiLine()
  {
    var input = new StringReader(@" aSdf A 123
4 *.%()(JFLD __   ad  

a");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadToken().Should().Be("aSdf");
    tokenizer.ReadToken().Should().Be("A");
    tokenizer.ReadToken().Should().Be("123");
    tokenizer.ReadToken().Should().Be("4");
    tokenizer.ReadToken().Should().Be("*.%()(JFLD");
    tokenizer.ReadToken().Should().Be("__");
    tokenizer.ReadToken().Should().Be("ad");
    tokenizer.ReadToken().Should().Be("a");
    tokenizer.ReadToken().Should().BeNull();
  }

  [Test]
  public void TestParseInt()
  {
    new Tokenizer(new StringReader("-1")).ReadInt().Should().Be(-1);
    new Tokenizer(new StringReader("+01")).ReadInt().Should().Be(1);
    new Tokenizer(new StringReader("-00")).ReadInt().Should().Be(0);
  }
  
  [Test]
  public void TestParseLong()
  {
    new Tokenizer(new StringReader("-59829934957459")).ReadLong().Should().Be(-59829934957459);
    new Tokenizer(new StringReader("+059829934957459")).ReadLong().Should().Be(59829934957459);
    new Tokenizer(new StringReader("-00")).ReadLong().Should().Be(0);
  }

  [Test]
  public void TestParseIntegers()
  {
    var input = new StringReader(@"-1 135 +4390 0000987654321
0 -00000
");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadInt().Should().Be(-1);
    tokenizer.ReadInt().Should().Be(135);
    tokenizer.ReadInt().Should().Be(4390);
    tokenizer.ReadInt().Should().Be(987654321);
    tokenizer.ReadInt().Should().Be(0);
    tokenizer.ReadInt().Should().Be(0);
    tokenizer.ReadToken().Should().BeNull();
  }
  
  [Test]
  public void TestParseLongs()
  {
    var input = new StringReader(@"-1 135 +439056812903734939 00009876543218589493
0 -00000
");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadLong().Should().Be(-1);
    tokenizer.ReadLong().Should().Be(135);
    tokenizer.ReadLong().Should().Be(439056812903734939);
    tokenizer.ReadLong().Should().Be(9876543218589493);
    tokenizer.ReadLong().Should().Be(0);
    tokenizer.ReadLong().Should().Be(0);
    tokenizer.ReadToken().Should().BeNull();
  }

  [Test]
  public void TestParseIntArray()
  {
    var input = new StringReader(@"-1 135 +4390 0000987654321
0 -00000 100500
");
    var tokenizer = new Tokenizer(input);

    var a = tokenizer.ReadIntArray(6);
    a[0].Should().Be(-1);
    a[1].Should().Be(135);
    a[2].Should().Be(4390);
    a[3].Should().Be(987654321);
    a[4].Should().Be(0);
    a[5].Should().Be(0);

    tokenizer.ReadInt().Should().Be(100500);
    tokenizer.ReadToken().Should().BeNull();
  }

  [Test]
  public void TestParseIntTuples()
  {
    var input = new StringReader(@"1 2 3
4
5 6 7    8
9");
    var tokenizer = new Tokenizer(input);

    tokenizer.Read2Int().Should().Be((1, 2));
    tokenizer.Read3Int().Should().Be((3, 4, 5));
    tokenizer.Read4Int().Should().Be((6, 7, 8, 9));
  }

  [Test]
  public void TestParseReadLine()
  {
    var input = new StringReader(@"
as s
d 
 ");
    var tokenizer = new Tokenizer(input);
    tokenizer.ReadLine().Should().Be("");
    tokenizer.ReadLine().Should().Be("as s");
    tokenizer.ReadLine().Should().Be("d ");
    tokenizer.ReadLine().Should().Be(" ");
    tokenizer.ReadLine().Should().BeNull();
  }
}
