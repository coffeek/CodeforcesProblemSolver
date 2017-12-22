using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TasksProjectGeneratorVSIX.Tests
{
  [TestClass]
  public class TaskDescriptionLoaderTest
  {
    [TestMethod]
    public void TestLoadDescription()
    {
      var taskId = new TaskId
      {
        ContestId = 782,
        ProblemNumber = 0
      };
      var description = TaskDescriptionLoader.Load(taskId);
      Assert.AreEqual(2, description.SampleTests.Count);
      Assert.AreEqual(@"1
1 1", description.SampleTests[0].Input);
      Assert.AreEqual(@"1", description.SampleTests[0].Output);
      Assert.AreEqual(@"3
2 1 1 3 2 3", description.SampleTests[1].Input);
      Assert.AreEqual(@"2", description.SampleTests[1].Output);
    }
  }
}
