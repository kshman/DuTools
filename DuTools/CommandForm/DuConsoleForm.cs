using DuTools.Properties;

namespace DuTools.CommandForm;

public partial class DuConsoleForm : Form
{
	private static DuConsoleForm? _instance;

	private CommandWork.ConsoleScript? _cs;
	private Process? _ps;

	private string _filename = string.Empty;

	public static DuConsoleForm Instance
	{
		get { return _instance ??= new DuConsoleForm(); }
	}

	public static bool HasInstance => _instance != null;

	private DuConsoleForm()
	{
		InitializeComponent();
	}

	private void DuConsoleForm_Load(object sender, EventArgs e)
	{
		if (!PrepareScript())
		{
			// 이게 참이었으면 prepare안에서 실행한것임
			if (_cs == null)
				LogLine(Color.SeaGreen, "스크립트부터 열면 안될깝쇼?");
			else
			{
				_cs.MakeTempContext();
				LogLine(Color.Blue, $"{_filename}{Environment.NewLine}");
				if (_cs.Lines != null)
					foreach (var l in _cs.Lines)
						LogLine(Color.Teal, l, false);
			}
		}
	}

	private void DuConsoleForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		_ps?.Kill();
		_cs?.Close();
	}

	private void DoItButton_Click(object sender, EventArgs e)
	{
		DoIt();
	}

	private void InvokeText(string? text, bool scroll = true)
	{
		if (!string.IsNullOrEmpty(text))
			FrontForm.InvokeAction(() =>
			{
				OutputText.AppendText(text);
				if (scroll)
					OutputText.ScrollToCaret();
			});
	}

	private void InvokeText(Color color, string? text, bool scroll = true)
	{
		if (!string.IsNullOrEmpty(text))
			FrontForm.InvokeAction(() =>
			{
				OutputText.SelectionColor = color;
				OutputText.SelectionStart = OutputText.TextLength;
				OutputText.SelectionLength = 0;
				OutputText.AppendText(text);
				OutputText.SelectionColor = OutputText.ForeColor;
				if (scroll)
					OutputText.ScrollToCaret();
			});
	}

	private void LogLine(Color color, string? text, bool scroll = true)
	{
		if (!OutputText.IsDisposed)
			InvokeText(color, text + Environment.NewLine, scroll);
	}

	private void LogLine(string? text, bool scroll = true)
	{
		if (!OutputText.IsDisposed)
			InvokeText(text + Environment.NewLine, scroll);
	}

	private void LogText(Color color, string? text, bool scroll = true)
	{
		if (!OutputText.IsDisposed)
			InvokeText(color, text, scroll);
	}

	/*
	private void LogText(string? text, bool scroll = true)
	{
		if (!OutputText.IsDisposed)
			InvokeText(text, scroll);
	}
	*/

	private void DoIt()
	{
		if (_cs != null)
		{
			TaskIt();
			return;
		}

		var dlg = new OpenFileDialog()
		{
			Title = Resources.SelectConsoleScript,
			Filter = Resources.ConsoleScriptFilter,
			CheckFileExists = true,
			CheckPathExists = true,
			Multiselect = false,
			InitialDirectory = Configs.LastFolder,
		};

		if (dlg.ShowDialog() != DialogResult.OK)
			return;

		Configs.LastFolderFromFilename(dlg.FileName);
		OutputText.Clear();

		_cs = ReadScript(dlg.FileName);
		PrepareScript();
	}

	/*
	private void CloseIt()
	{
		if (_cs == null)
			return;

		WaitProcess();

		_cs.Close();
		_cs = null;

		PrepareScript();

		OutputText.Clear();
		LogLine(Color.DarkKhaki, "[스크립트가 끝났습니다]");
	}
	*/

	public void WaitProcess()
	{
		_ps?.WaitForExit();
	}

	public CommandWork.ConsoleScript? ReadScript(string filename)
	{
		var cs = CommandWork.ConsoleScript.FromFile(filename);

		if (cs == null)
		{
			LogText(Color.Red, Resources.CannotReadConsoleScript, false);
			LogLine(filename);
			return null;
		}

		if (cs.RunAs && !TestEnv.IsAdministrator)
		{
			// RUNAS!
			RunAs(filename);
			FrontForm.Instance.Close();
			return null;
		}

		cs.MakeTempContext();
		LogLine(Color.Blue, $"{filename}{Environment.NewLine}");
		if (cs.Lines != null)
			foreach (var l in cs.Lines)
				LogLine(Color.Teal, l, false);

		return cs;
	}

	public bool PrepareScript(CommandWork.ConsoleScript? cs)
	{
		_cs = cs;
		return PrepareScript();
	}

	private bool PrepareScript()
	{
		if (_cs == null)
		{
			TitleLabel.Text = Resources.NoConsoleScript;
			DoItButton.Text = Resources.Open;

			_filename = string.Empty;

			return false;
		}

		TitleLabel.Text = _cs.Name;
		DoItButton.Text = Resources.DoIt;

		_filename = _cs.FileName;
		Configs.LastFolderFromFilename(_cs.FileName);

		if (!_cs.StartOnLoad)
			return false;

		_cs.MakeTempContext();
		TaskIt();

		return true;
	}

	public void TaskIt()
	{
		OutputText.Clear();

		Task.Run(RunScriptASync);
	}

	private void RunScriptASync()
	{
		if (_cs == null)
		{
			LogLine(Color.Red, Resources.NoConsoleScriptOpenFirst);
			return;
		}

		if (_ps != null)
			return;

		if (!CommandWork.ConsoleScript.ConsoleTypeToRuntime(_cs.Type, out var runtime, out var argument))
		{
			LogLine(Color.Red, $"{Resources.InvalidConsoleRuntime}{_cs.Type}");
			return;
		}

		_ps = new();
		_ps.StartInfo.FileName = runtime;
		_ps.StartInfo.Arguments = $"{argument} {_cs.TempFileName}";
		_ps.StartInfo.UseShellExecute = false;
		_ps.StartInfo.CreateNoWindow = true;
		_ps.StartInfo.RedirectStandardOutput = true;
		_ps.StartInfo.RedirectStandardError = true;
		if (_cs.RunAs)
			_ps.StartInfo.Verb = "runas";

		_ps.EnableRaisingEvents = true;
		_ps.OutputDataReceived += (_, e) => LogLine(e.Data);
		_ps.ErrorDataReceived += (_, e) => LogLine(Color.Red, e.Data);
		_ps.Exited += (_, _) => ProcessExited();

		_ps.Start();
		_ps.BeginOutputReadLine();
		_ps.BeginErrorReadLine();
	}

	private void ProcessExited()
	{
		int exitcode;

		if (_ps == null)
			exitcode = 0;
		else
		{
			Thread.Sleep(100);

			exitcode = _ps.ExitCode;

			_ps.Close();
			_ps = null;
		}

		// 당연하지만 종료가 메시지 보다 빨리 올 가능성 99.999%
		LogLine(Color.Red, $"{Resources.ConsoleScriptExitWith}{exitcode}");
		//Debug.WriteLine($"Exit code: {exitcode}");

		//
		if (!DoItButton.InvokeRequired)
			DoItButton.Enabled = true;
		else
			DoItButton.Invoke(new Action(() => DoItButton.Enabled = true));

		AutoExitIt();
	}

	private void AutoExitIt()
	{
		if (_cs is not { AutoExit: true })
			return;

		Task.Run(() =>
		{
			Task.Delay(1000);
			Invoke(() => FrontForm.Instance.Close());
		}).Wait();
	}

	public static void RunAs(string filename)
	{
		var ps = new Process();
		ps.StartInfo.FileName = Application.ExecutablePath;
		ps.StartInfo.Arguments = filename;
		ps.StartInfo.WorkingDirectory = Application.StartupPath;
		ps.StartInfo.UseShellExecute = true;
		ps.StartInfo.Verb = "runas";
		ps.Start();
	}
}

