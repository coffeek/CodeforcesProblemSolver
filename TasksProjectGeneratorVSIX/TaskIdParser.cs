using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TasksProjectGeneratorVSIX
{
  internal class TaskIdParser
  {
    public static bool TryParseFromUrl(string url, out TaskId taskId)
    {
      var problemsetMatch = Regex.Match(url, @"https?://codeforces.com/problemset/problem/(\d{1,4})/([a-z])/?", RegexOptions.IgnoreCase);
      if (problemsetMatch.Success)
      {
        taskId = new TaskId
        {
          ContestId = int.Parse(problemsetMatch.Groups[1].Value),
          ProblemNumber = problemsetMatch.Groups[2].Value.ToLower()[0] - 'a'
        };
        return true;
      }
      var contestMatch = Regex.Match(url, @"https?://codeforces.com/contest/(\d{1,4})/problem/([a-z])/?", RegexOptions.IgnoreCase);
      if (contestMatch.Success)
      {
        taskId = new TaskId
        {
          ContestId = int.Parse(contestMatch.Groups[1].Value),
          ProblemNumber = contestMatch.Groups[2].Value.ToLower()[0] - 'a'
        };
        return true;
      }
      taskId = null;
      return false;
    }

    public static bool TryParseFromId(string id, out TaskId taskId)
    {
      var match = Regex.Match(id, @"(\d{1,4})([a-z])", RegexOptions.IgnoreCase);
      if (match.Success)
      {
        taskId = new TaskId
        {
          ContestId = int.Parse(match.Groups[1].Value),
          ProblemNumber = match.Groups[2].Value.ToLower()[0] - 'a'
        };
        return true;
      }
      taskId = null;
      return false;
    }
  }
}
