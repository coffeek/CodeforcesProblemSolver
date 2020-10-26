using System.IO;
using NUnit.Framework;

namespace Olymp.Tests
{
  [TestFixture]
  public class SolveTest
  {
    [Test]
    public void Case1()
    {
      Assert.AreEqual(
@"",
        GetResult(
@""));
    }

    [Test]
    public void Case2()
    {
      Assert.AreEqual(
@"",
        GetResult(
@""));
    }

    [Test]
    public void Case3()
    {
      Assert.AreEqual(
@"",
        GetResult(
@""));
    }

    [Test]
    public void Case4()
    {
      Assert.AreEqual(
@"",
        GetResult(
@""));
    }

    private static string GetResult(string inputData)
    {
      var input = new StringReader(inputData);
      var output = new StringWriter();
      var solver = new ProblemSolver(input, output);
      solver.Solve();
      return output.ToString().TrimEnd();
    }
  }
}
