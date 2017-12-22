using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TasksProjectGeneratorVSIX
{
  public class TaskDescriptionLoader
  {
    public TaskDescription TaskDescription { get; private set; }

    public static TaskDescription Load(TaskId taskId)
    {
      var loader = new TaskDescriptionLoader(taskId);
      loader.Load();
      return loader.TaskDescription;
    }

    private void Load()
    {
      using (var webClient = new WebClient())
      {
        var contestId = this.TaskDescription.Id.ContestId;
        var problemId = (char)('A' + this.TaskDescription.Id.ProblemNumber);
        var htmlData = webClient.DownloadString($"http://codeforces.com/problemset/problem/{contestId}/{problemId}");
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlData);
        ParseSampleTests(htmlDocument);
      }
    }

    private void ParseSampleTests(HtmlDocument htmlDocument)
    {
      var sampleInputNodes = htmlDocument.DocumentNode.SelectNodes(@"//div[@class='sample-test']/div[@class='input']/pre");
      for (int i = 0; i < sampleInputNodes.Count; i++)
      {
        var inputData = sampleInputNodes[i].InnerHtml.Replace("<br>", Environment.NewLine).Trim();
        this.TaskDescription.SampleTests.Add(new TaskSampleTest { Number = i + 1, Input = inputData });
      }

      var sampleOutputNodes = htmlDocument.DocumentNode.SelectNodes(@"//div[@class='sample-test']/div[@class='output']/pre");
      for (int i = 0; i < sampleOutputNodes.Count; i++)
      {
        var outputData = sampleOutputNodes[i].InnerHtml.Replace("<br>", Environment.NewLine).Trim();
        this.TaskDescription.SampleTests[i].Output = outputData;
      }
    }

    private TaskDescriptionLoader(TaskId taskId)
    {
      this.TaskDescription = new TaskDescription(taskId);
    }
  }
}
