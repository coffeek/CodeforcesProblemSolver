using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksProjectGeneratorVSIX
{
  public class TaskDescription
  {
    public TaskId Id { get; private set; }

    public string Condition { get; set; }

    public IList<TaskSampleTest> SampleTests { get; } = new List<TaskSampleTest>();

    public TaskDescription(TaskId taskId)
    {
      this.Id = taskId;
    }
  }
}
