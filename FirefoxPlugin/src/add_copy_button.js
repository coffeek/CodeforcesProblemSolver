var sampleTestsElement = document.body.getElementsByClassName("sample-tests")[0];
var button = document.createElement("div");
button.className = "input-output-copier";
button.textContent = "Скопировать как SolveTest.cs";
button.onclick = function (e) {
    create_and_copy_tests();
}
sampleTestsElement.getElementsByClassName("section-title")[0].appendChild(button);

function prepare_text(s) {
    return s
        .replace(/([~\r]|^)\n/, '\r\n') // Заменить \n на \r\n
        .replace(/(.*)\s+$/, '$1') // Убрать переводы строк и пробелы в конце.
}

function create_and_copy_tests() {
    var testMethods = []
    var inputs = document.getElementsByClassName("input");
    var outputs = document.getElementsByClassName("output");
    var n = inputs.length;
    for (var i = 0; i < n; i++) {
        var input = prepare_text(inputs[i].lastChild.innerText);
        var output = prepare_text(outputs[i].lastChild.innerText);
        var testMethod =
            `    [Test]
    public void Case${i + 1}()
    {
      Assert.AreEqual(
        @"${output}",
        GetResult(
          @"${input}"));
    }`;
        testMethods.push(testMethod);
    }

    var testModule = `using System;
using System.IO;
using NUnit.Framework;

namespace Olymp
{
  [TestFixture]
  public class SolveTest
  {
${testMethods.join("\r\n\r\n")}

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
}`

    navigator.clipboard.writeText(testModule).then(function () {
        alert("Данные были скопированы в буфер обмена");
    });
}