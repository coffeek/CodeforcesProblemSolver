//------------------------------------------------------------------------------
// <copyright file="Command1.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace TasksProjectGeneratorVSIX
{
  /// <summary>
  /// Command handler
  /// </summary>
  internal sealed class GenerateCodeCommand
  {
    public const int CommandId = 0x0100;

    public static readonly Guid CommandSet = new Guid("d36a7c6a-3c5c-4532-b953-5b21317a6b8d");

    private readonly Package package;

    private GenerateCodeCommand(Package package)
    {
      if (package == null)
      {
        throw new ArgumentNullException("package");
      }

      this.package = package;

      OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
      if (commandService != null)
      {
        var menuCommandID = new CommandID(CommandSet, CommandId);
        var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
        commandService.AddCommand(menuItem);
      }
    }

    public static GenerateCodeCommand Instance
    {
      get;
      private set;
    }

    private IServiceProvider ServiceProvider
    {
      get
      {
        return this.package;
      }
    }

    public static void Initialize(Package package)
    {
      Instance = new GenerateCodeCommand(package);
    }

    private void MenuItemCallback(object sender, EventArgs e)
    {
      var dte = this.ServiceProvider.GetService(typeof(DTE)) as DTE;
      Project mainProject = dte.Solution.Projects.OfType<Project>().FirstOrDefault(p => p.Name == "Olymp");
      if (mainProject == null)
      {
        ShowError("Не найден основной проект");
        return;
      }
      Project testProject = dte.Solution.Projects.OfType<Project>().FirstOrDefault(p => p.Name == "Olymp.Tests");
      if (testProject == null)
      {
        ShowError("Не найден проект тестов");
        return;
      }
      var mainItem = mainProject.ProjectItems.OfType<ProjectItem>().FirstOrDefault(item => item.Name == "Program.cs");
      if (testProject == null)
      {
        ShowError("Не найден файл Program.cs");
        return;
      }
      var testsItem = testProject.ProjectItems.OfType<ProjectItem>().FirstOrDefault(item => item.Name == "SolveTest.cs");
      if (testProject == null)
      {
        ShowError("Не найден файл SolveTest.cs");
        return;
      }

      using (var selectTaskWindow = new SelectTaskWindow())
      {
        if (selectTaskWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          ShowError("Все ок");
          var taskId = selectTaskWindow.TaskId;
          TaskDescription taskDescription;
          try
          {
            taskDescription = TaskDescriptionLoader.Load(taskId);
          }
          catch
          {
            ShowError("Не удалось загрузить описание задачи с сайта");
            return;
          }
          try
          {
            var sampleTestFileContents = SampleTestGenerator.GenerateTests(taskDescription);
            if (!testsItem.IsOpen)
            {
              testsItem.Open();
              testsItem.Document.Activate();
            }
            var selection = (TextSelection)testsItem.Document.Selection;
            //selection.SelectAll();
            //selection.Delete();
            selection.StartOfDocument();
            selection.Insert(sampleTestFileContents);
          }
          catch
          {
            ShowError("Не удалось сгенерировать модульные тесты");
            return;
          }
        }
      }
    }

    private void ShowError(string message)
    {
      VsShellUtilities.ShowMessageBox(this.ServiceProvider, message, "Ошибка", OLEMSGICON.OLEMSGICON_WARNING, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
    }
  }
}
