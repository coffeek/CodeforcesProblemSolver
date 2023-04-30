﻿const sampleTestsElement = document.body.getElementsByClassName("sample-tests")[0];
if (sampleTestsElement) {
  const button = document.createElement("div");
  button.className = "input-output-copier";
  button.textContent = "Copy as SolveTest.cs";
  button.onclick = function (e) {
      create_and_copy_tests();
  };
  sampleTestsElement.getElementsByClassName("section-title")[0].appendChild(button);

  function prepare_text(s) {
      return s
          .replace(/(.*)\s+$/, '$1') // Remove line breaks and spaces at the end of the text.
  }

  function create_and_copy_tests() {
      const testMethods = [];
      const inputs = document.getElementsByClassName("input");
      const outputs = document.getElementsByClassName("output");
      const n = inputs.length;
      for (let i = 0; i < n; i++) {
          const input = prepare_text(inputs[i].lastChild.innerText);
          const output = prepare_text(outputs[i].lastChild.innerText);
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