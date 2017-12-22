using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Olymp
{
  [TestClass]
  public class SolveTest
  {
$task.SampleTests:{it|
    [TestMethod]
    public void Case$it.Number$()
    {
      Assert.AreEqual(
@"$it.Output$",
        GetResult(
@"$it.Input$"));
    \}

}$    private string GetResult(string inputData)
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