global using System.Diagnostics;
global using System.Text;
global using Du;
global using Du.Data;
global using Du.Globalization;
global using Du.Platform;
global using Du.WinForms;
using DuTools.CommandForm;
using DuTools.CommandWork.DuConsole;

namespace DuTools;

internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	private static void Main()
	{
		var prm = string.Empty;
		var cmd = GetCommand(Environment.GetCommandLineArgs(), ref prm);
		object? obj = null;

		if (cmd == CommandList.DuConsole && TestDuConsole(prm, ref obj))
			return;

		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();
		Application.Run(new FrontForm(cmd, obj));
	}

	private static CommandList GetCommand(string[] arg, ref string param)
	{
		foreach (var a in arg)
		{
			if (a[0] != '-')
				continue;

			var eq = a.IndexOf('=');
			string cmd;

			if (eq == -1)
				cmd = a[1..];
			else
			{
				param = a[(eq + 1)..].Trim();
				cmd = a.Substring(1, eq - 1);

				if (param[0] == '"' && param[^1] == '"')
					param = param.Substring(1, param.Length - 2).Trim();
			}

			switch (cmd.ToLower())
			{
				case "calculator" or "cal":
					return CommandList.Calculator;
				case "converter1" or "conv1":
					return CommandList.Converter1;
				case "duconsole" or "duc":
					return CommandList.DuConsole;
				case "dugetblog" or "dugethttp" or "blog":
					return CommandList.DuGetBlog;
			}
		}

		return CommandList.OhNo;
	}

	private static bool TestDuConsole(string filename, ref object? obj)
	{
		if (string.IsNullOrWhiteSpace(filename))
			return false;

		var cs = ConsoleScript.FromFile(filename);
		if (cs == null)
			return false;

		if (!cs.RunAs || TestEnv.IsAdministrator)
		{
			obj = cs;
			return false;
		}
		
		DuConsoleForm.RunAs(filename);

		return true;
	}
}
