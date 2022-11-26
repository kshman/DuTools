using DuTools.CommandWork.DuConsole;
using DuTools.Properties;

namespace DuTools.CommandForm;

public partial class DuConsoleForm : Form
{
	private ConsoleScript? _cs;
	private Process? _ps;

	#region 컨스트럭터 + 폼 메시지
	public DuConsoleForm()
	{
		InitializeComponent();

		// 단순히 UI 초기화용이다. 실제로 스크립드 준비하는게 아님
		PrepareScript();
	}

	private void DoItButton_Click(object sender, EventArgs e)
	{
		DoIt();
	}
	#endregion

	#region 텍스트 출력 처리
	private void InvokeText(string? text, bool scroll = true)
	{
		if (!string.IsNullOrEmpty(text))
			OutputText.Invoke(() =>
			{
				OutputText.AppendText(text);
				if (scroll)
					OutputText.ScrollToCaret();
			});
	}

	private void InvokeText(Color color, string? text, bool scroll = true)
	{
		if (!string.IsNullOrEmpty(text))
			OutputText.Invoke(() =>
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
	#endregion

	public bool ReadScript(string filename)
	{
		var cs = ConsoleScript.FromFile(filename);

		if (cs == null)
		{
			LogText(Color.Red, Resources.CannotReadConsoleScript);
			LogLine($"{Resources.FileNameWith}{filename}");
			return false;
		}

		if (cs.RunAs && !TestEnv.IsAdministrator)
		{
			// RUNAS!
			RunAs(filename);
			FrontForm.Instance.Close();
			return false;
		}

		Configs.LastFolderFromFilename(filename);
		_cs = cs;

		return true;
	}

	private bool PrepareScript()
	{
		if (_cs == null)
		{
			TitleLabel.Text = Resources.NoConsoleScript;
			DoItButton.Text = Resources.Open;
			ScriptInfoText.Text = Resources.OpenConsoleScriptPlease;

			return false;
		}

		Configs.LastFolderFromFilename(_cs.FileName);

		TitleLabel.Text = _cs.Name;
		DoItButton.Text = Resources.DoIt;

		StringBuilder sb = new();
		sb.Append(_cs.GetFileNameOnly());
		sb.Append($" / 형식: {_cs.Type.GetDescription()}");
		if (_cs.RunAs)
			sb.Append(" / 관리자");
		if (_cs.StartOnLoad)
			sb.Append(" / 바로시작");
		if (_cs.AutoExit)
			sb.Append(" / 끝나면 종료");
		ScriptInfoText.Text = sb.ToString();

		if (_cs.StartOnLoad)
		{
			TaskIt();

			return true;
		}

		if (_cs.Context != null)
			foreach (var l in _cs.Context)
				LogLine(Color.Teal, l, false);

		return false;
	}

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

		HotScript(dlg.FileName);
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

		if (!ConsoleScript.ConsoleTypeToRuntime(_cs.Type, out var runtime, out var argument))
		{
			LogLine(Color.Red, $"{Resources.InvalidConsoleRuntime}{_cs.Type}");
			return;
		}

		_cs.PrepareTempContext();

		_ps = new Process();
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
		_ps.ErrorDataReceived += (_, e) =>
		{
			if (e.Data != null)
			{
				_cs.AutoExit = false;
				LogLine(Color.Red, e.Data);
			}
		};
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
			//Task.Delay(100);
			Thread.Sleep(100);

			exitcode = _ps.ExitCode;

			_ps.Close();
			_ps = null;
		}

		// 당연하지만 종료가 메시지 보다 빨리 올 가능성 99.999%
		LogLine(Color.Red, $"{Resources.ConsoleScriptExitWith}{exitcode}");
		//Debug.WriteLine($"Exit code: {exitcode}");

		//
		DoItButton.Invoke(() => DoItButton.Enabled = true);

		// 아니 이게 여기서 널 일리가 없는데, 왤케 검사하라고 함
		if (_cs == null)
			return;

		_cs.CleanUpTempContext();

		// 탈출
		if (!_cs.AutoExit || _cs.AutoExit && exitcode != 0)
			return;

		Task.Run(() =>
		{
			//Task.Delay(100);
			Thread.Sleep(100);
			FrontForm.Instance.Invoke(() => FrontForm.Instance.Close());
		}).Wait();
	}

	public void WaitProcess()
	{
		_ps?.WaitForExit();
	}

	public bool HotScript(ConsoleScript? cs)
	{
		_cs = cs;
		return PrepareScript();
	}

	public bool HotScript(string filename)
	{
		OutputText.Clear();

		ReadScript(filename);
		return PrepareScript();
	}

	public static void RunAs(string filename)
	{
		var ps = new Process();
		ps.StartInfo.FileName = Application.ExecutablePath;
		ps.StartInfo.Arguments = $"-duconsole=\"{filename}\"";
		ps.StartInfo.WorkingDirectory = Application.StartupPath;
		ps.StartInfo.UseShellExecute = true;
		ps.StartInfo.Verb = "runas";
		ps.Start();
	}

	public static bool IsCanDrop(string filename)
		=> ConsoleScript.DetectConsoleType(filename) != ConsoleType.Unknown;
}

