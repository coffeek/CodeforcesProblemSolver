using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Olymp
{
  [TestClass]
  public class SolveTest
  {
    [TestMethod]
    public void Case1()
    {
      Assert.AreEqual(
@"",
        this.GetResult(
@""));
    }

    [TestMethod]
    public void Case2()
    {
      Assert.AreEqual(
@"",
        this.GetResult(
@""));
    }

    [TestMethod]
    public void Case3()
    {
      Assert.AreEqual(
@"",
        this.GetResult(
@""));
    }

    private string GetResult(string inputData)
    {
      var input = new StringReader(inputData);
      var output = new StringWriter();
      Console.SetOut(output);
      var solver = new ProblemSolver(input);
      solver.Solve();
      return output.ToString().TrimEnd();
    }
  }
}
