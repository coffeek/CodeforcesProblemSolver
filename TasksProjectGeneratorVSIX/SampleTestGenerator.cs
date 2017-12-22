using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Antlr4.StringTemplate;

namespace TasksProjectGeneratorVSIX
{
  public class SampleTestGenerator
  {
    public static string GenerateTests(TaskDescription taskDescription)
    {
      var template = Encoding.UTF8.GetString(Resources.SampleTestsTemplate);
      Template st = new Template(template, '$', '$');
      st.Add("task", taskDescription);
      return st.Render();
    }
  }
}
