using System;
using System.IO;
using NUnit.Framework;

namespace Olymp.Tests.Utils
{
  [TestFixture]
  public class TokenizerTest
  {
    [Test]
    public void TestParseEmptyString()
    {
      var input = new StringReader("");
      var tokenizer = new Tokenizer(input);
      Assert.IsNull(tokenizer.ReadToken());
    }

    [Test]
    public void TestParseTokensSingleLine()
    {
      var input = new StringReader(" aSdf A 1234 *.%()(JFLD __   ad   a  \t");
      var tokenizer = new Tokenizer(input);
      Assert.AreEqual("aSdf", tokenizer.ReadToken());
      Assert.AreEqual("A", tokenizer.ReadToken());
      Assert.AreEqual("1234", tokenizer.ReadToken());
      Assert.AreEqual("*.%()(JFLD", tokenizer.ReadToken());
      Assert.AreEqual("__", tokenizer.ReadToken());
      Assert.AreEqual("ad", tokenizer.ReadToken());
      Assert.AreEqual("a", tokenizer.ReadToken());
      Assert.IsNull(tokenizer.ReadToken());
    }

    [Test]
    public void TestParseTokensMultiLine()
    {
      var input = new StringReader(@" aSdf A 123
4 *.%()(JFLD __   ad  

a");
      var tokenizer = new Tokenizer(input);
      Assert.AreEqual("aSdf", tokenizer.ReadToken());
      Assert.AreEqual("A", tokenizer.ReadToken());
      Assert.AreEqual("123", tokenizer.ReadToken());
      Assert.AreEqual("4", tokenizer.ReadToken());
      Assert.AreEqual("*.%()(JFLD", tokenizer.ReadToken());
      Assert.AreEqual("__", tokenizer.ReadToken());
      Assert.AreEqual("ad", tokenizer.ReadToken());
      Assert.AreEqual("a", tokenizer.ReadToken());
      Assert.IsNull(tokenizer.ReadToken());
    }

    [Test]
    public void TestParseInt()
    {
      Assert.AreEqual(-1, new Tokenizer(new StringReader("-1")).ReadInt());
      Assert.AreEqual(1, new Tokenizer(new StringReader("+01")).ReadInt());
      Assert.AreEqual(0, new Tokenizer(new StringReader("-00")).ReadInt());
    }

    [Test]
    public void TestParseIntFail1()
    {
      Assert.Throws<EndOfStreamException>(() =>
        Assert.AreEqual(-1, new Tokenizer(new StringReader("")).ReadInt()));
    }

    [Test]
    public void TestParseIntFail2()
    {
      Assert.Throws<EndOfStreamException>(() => 
        Assert.AreEqual(-1, new Tokenizer(new StringReader("-")).ReadInt()));
    }

    [Test]
    public void TestParseIntFail3()
    {
      Assert.Throws<InvalidOperationException>(() =>
        Assert.AreEqual(-1, new Tokenizer(new StringReader("-w")).ReadInt()));
    }

    [Test]
    public void TestParseIntFail4()
    {
      Assert.Throws<InvalidOperationException>(() =>
        Assert.AreEqual(-1, new Tokenizer(new StringReader("w")).ReadInt()));
    }

    [Test]
    public void TestParseIntegers()
    {
      var input = new StringReader(@"-1 135 +4390 0000987654321
0 -00000
");
      var tokenizer = new Tokenizer(input);
      Assert.AreEqual(-1, tokenizer.ReadInt());
      Assert.AreEqual(135, tokenizer.ReadInt());
      Assert.AreEqual(4390, tokenizer.ReadInt());
      Assert.AreEqual(987654321, tokenizer.ReadInt());
      Assert.AreEqual(0, tokenizer.ReadInt());
      Assert.AreEqual(0, tokenizer.ReadInt());
      Assert.IsNull(tokenizer.ReadToken());
    }

    [Test]
    public void TestParseIntArray()
    {
      var input = new StringReader(@"-1 135 +4390 0000987654321
0 -00000 100500
");
      var tokenizer = new Tokenizer(input);

      var a = tokenizer.ReadIntArray(6);
      Assert.AreEqual(-1, a[0]);
      Assert.AreEqual(135, a[1]);
      Assert.AreEqual(4390, a[2]);
      Assert.AreEqual(987654321, a[3]);
      Assert.AreEqual(0, a[4]);
      Assert.AreEqual(0, a[5]);

      Assert.AreEqual(100500, tokenizer.ReadInt());
      Assert.IsNull(tokenizer.ReadToken());
    }

    [Test]
    public void TestParseIntTuples()
    {
      var input = new StringReader(@"1 2 3
4
5 6 7    8
9");
      var tokenizer = new Tokenizer(input);

      Assert.AreEqual((1, 2), tokenizer.Read2Int());
      Assert.AreEqual((3, 4, 5), tokenizer.Read3Int());
      Assert.AreEqual((6, 7, 8, 9), tokenizer.Read4Int());
    }

    [Test]
    public void TestParseReadLine()
    {
      var input = new StringReader(@"
as s
d 
 ");
      var tokenizer = new Tokenizer(input);
      Assert.AreEqual("", tokenizer.ReadLine());
      Assert.AreEqual("as s", tokenizer.ReadLine());
      Assert.AreEqual("d ", tokenizer.ReadLine());
      Assert.AreEqual(" ", tokenizer.ReadLine());
      Assert.IsNull(tokenizer.ReadLine());
    }
  }
}
