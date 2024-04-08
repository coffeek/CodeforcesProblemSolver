using System.IO;

namespace Solver.Tests;

[TestFixture]
public class SolveTest
{
  // [Test]
  // public void Case1()
  // {
  //   Assert.AreEqual(
  //     @"",
  //     GetResult(
  //       @""));
  // }

  private static string GetResult(string inputData)
  {
    var input = new StringReader(inputData);
    var output = new StringWriter();
    var solver = new ProblemSolver(input, output);
    solver.Solve();
    return output.ToString().TrimEnd();
  }
}
