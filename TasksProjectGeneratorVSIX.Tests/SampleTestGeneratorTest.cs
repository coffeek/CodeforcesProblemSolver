using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TasksProjectGeneratorVSIX.Tests
{
  [TestClass]
  public class SampleTestGeneratorTest
  {
    [TestMethod]
    public void GenerateTests()
    {
      var taskId = new TaskId { ContestId = 10, ProblemNumber = 1 };
      var task = new TaskDescription(taskId);
      task.SampleTests.Add(
        new TaskSampleTest
        {
          Number = 1,
          Input = @"asdf",
          Output = @"1234"
        });
      task.SampleTests.Add(
        new TaskSampleTest
        {
          Number = 2,
          Input = 
@"1 2 3 4
1 2 3
1 2
1",
          Output = 
@"ad
dadfasd"
        });
      var testsFile = SampleTestGenerator.GenerateTests(task);
      Assert.AreEqual(
@"﻿using System;
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
@""1234"",
        GetResult(
@""asdf""));
    }

    [TestMethod]
    public void Case2()
    {
      Assert.AreEqual(
@""ad
dadfasd"",
        GetResult(
@""1 2 3 4
1 2 3
1 2
1""));
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
}", testsFile);
    }
  }
}
