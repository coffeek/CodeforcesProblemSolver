const sampleTestsElement = document.body.getElementsByClassName("sample-tests")[0];
if (sampleTestsElement) {
  const button = document.createElement("div");
  button.className = "input-output-copier";
  button.textContent = "Copy as SolveTest.cs";
  button.onclick = function (e) {
      createAndCopyTests();
  };
  sampleTestsElement.getElementsByClassName("section-title")[0].appendChild(button);

  function prepareText(s) {
      return s.replace(/(.*)\s+$/, '$1') // Remove line breaks and spaces at the end of the text.
  }

  function createAndCopyTests() {
      const testMethods = [];
      const inputs = document.getElementsByClassName("input");
      const outputs = document.getElementsByClassName("output");
      const n = inputs.length;
      for (let i = 0; i < n; i++) {
          const input = prepareText(inputs[i].lastChild.innerText);
          const output = prepareText(outputs[i].lastChild.innerText);
          const testMethod =
              `  [Test]
    public void Case${i + 1}()
    {
      Assert.AreEqual(
        @"${output}",
        GetResult(
          @"${input}"));
    }`;
          testMethods.push(testMethod);
      }

      const testModule = `using System.IO;
  using NUnit.Framework;

  namespace Solver.Tests;

  [TestFixture]
  public class SolveTest
  {
  ${testMethods.join("\n\n")}

    private static string GetResult(string inputData)
    {
      var input = new StringReader(inputData);
      var output = new StringWriter();
      var solver = new ProblemSolver(input, output);
      solver.Solve();
      return output.ToString().TrimEnd();
    }
  }`;

      navigator.clipboard.writeText(testModule).then(function () {
          console.info("The data copied to the clipboard");
      });
  }
}