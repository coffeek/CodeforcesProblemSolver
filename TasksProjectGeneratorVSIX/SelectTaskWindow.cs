using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksProjectGeneratorVSIX
{
  public partial class SelectTaskWindow : Form
  {
    public TaskId TaskId { get; private set; }

    public SelectTaskWindow()
    {
      InitializeComponent();
    }

    private bool TryParseInput(string value)
    {
      TaskId id;
      if (TaskIdParser.TryParseFromId(value, out id) || TaskIdParser.TryParseFromUrl(value, out id))
      {
        this.TaskId = id;
        return true;
      }
      return false;
    }

    private void taskIdTextBox_Validating(object sender, CancelEventArgs e)
    {
      var value = this.taskIdTextBox.Text.Trim();
      if (!TryParseInput(this.taskIdTextBox.Text.Trim()))
      {
        e.Cancel = true;
        this.okButton.Enabled = false;
        errorProvider1.SetError(this.taskIdTextBox, "Некорректное значение номера");
      }
    }

    private void taskIdTextBox_Validated(object sender, EventArgs e)
    {
      errorProvider1.SetError(this.taskIdTextBox, "");
      okButton.Enabled = true;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void taskIdTextBox_TextChanged(object sender, EventArgs e)
    {
      this.ValidateChildren();
    }
  }
}
