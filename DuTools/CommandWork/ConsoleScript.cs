using System.ComponentModel;

namespace DuTools.CommandWork;

public class ConsoleScript
{
	private string[]? _lines;

	public string FileName { get; private set; } = string.Empty;
	public string TempFileName { get; private set; } = string.Empty;

	public string Name { get; set; } = string.Empty;
	public ConsoleType Type { get; private set; } = ConsoleType.Unknown;
	public bool StartOnLoad { get; set; }
	public bool RunAs { get; set; }
	public bool AutoExit { get; set; }

	public string[]? Context { get; private set; }

	private ConsoleScript()
	{
	}

	public static ConsoleScript? FromFile(string filename)
	{
		if (string.IsNullOrWhiteSpace(filename))
			return null;

		try
		{
			var fi = new FileInfo(filename);

			if (!fi.Exists)
				return null;

			var s = new ConsoleScript();

			var detect = DetectConsoleType(fi);
			if (detect == ConsoleType.Unknown)
				return null;

			s.FileName = fi.FullName;
			s.Type = detect;

			switch (detect)
			{
				case ConsoleType.Console:
					if (!s.ReadConsoleFromFile())
						return null;
					break;

				case ConsoleType.Cmd or ConsoleType.PowerShell:
					if (!s.ReadFromFile())
						return null;
					break;

				default:
					return null;
			}

			return s;
		}
		catch
		{
			return null;
		}
	}

	private bool ReadFromFile()
	{
		if (string.IsNullOrEmpty(FileName))
			return false;

		_lines = File.ReadAllLines(FileName, ConsoleTypeToEncoding(Type));
		Context = _lines;

		return true;
	}

	private bool ReadConsoleFromFile()
	{
		if (string.IsNullOrEmpty(FileName))
			return false;

		_lines = File.ReadAllLines(FileName);

		var dbs = LineDb.Empty();
		var ctx = new List<string>();
		var isdb = true;

		foreach (var l in _lines)
		{
			if (!isdb)
				ctx.Add(l);
			else if (l.Length == 0)
				isdb = false;
			else
				dbs.AddFromContext(l);
		}

		if (dbs.Count == 0 || ctx.Count == 0)
			return false;

		Context = ctx.ToArray();

		Name = dbs.Get("name") ?? FileName;
		Type = StringToConsoleType(dbs.Get("type"));
		StartOnLoad = Converter.ToBool(dbs.Get("start"), StartOnLoad);
		RunAs = Converter.ToBool(dbs.Get("runas"), RunAs);
		AutoExit = Converter.ToBool(dbs.Get("autoexit"), AutoExit);

		return true;
	}

	public void PrepareTempContext()
	{
		if (Context == null || Context.Length == 0 || !string.IsNullOrWhiteSpace(TempFileName))
			return;

		var ext = ConsoleTypeToExtension(Type);
		TempFileName = $"{Path.GetTempPath()}\\DuConsole_{UnixTime.Tick}.{ext}";

		var merge = string.Join("\r\n", Context);
		var encoding = ConsoleTypeToEncoding(Type);
		File.WriteAllText(TempFileName, merge, encoding);
	}

	public void CleanUpTempContext()
	{
		if (string.IsNullOrEmpty(TempFileName) || !File.Exists(TempFileName))
			return;

		File.Delete(TempFileName);
		TempFileName = string.Empty;
	}

	public string GetFileNameOnly()
	{
		if (string.IsNullOrWhiteSpace(FileName))
			return string.Empty;

		var fi = new FileInfo(FileName);
		return fi.Name;
	}

	public static ConsoleType DetectConsoleType(FileSystemInfo fileinfo)
	{
		return fileinfo.Extension.ToLower() switch
		{
			".duc" or ".duconsole" => ConsoleType.Console,
			".cmd" or ".bat" => ConsoleType.Cmd,
			".ps1" or ".pwsh" => ConsoleType.PowerShell,
			_ => ConsoleType.Unknown,
		};
	}

	public static ConsoleType DetectConsoleType(string filename)
		=> DetectConsoleType(new FileInfo(filename));

	public static ConsoleType StringToConsoleType(string? value)
	{
		if (string.IsNullOrEmpty(value))
			return ConsoleType.Unknown;

		return value.ToLower() switch
		{
			"cmd" or "bat" => ConsoleType.Cmd,
			"ps" or "ps1" or "powershell" => ConsoleType.PowerShell,
			_ => ConsoleType.Unknown,
		};
	}

	private static string ConsoleTypeToExtension(ConsoleType type)
	{
		return type switch
		{
			ConsoleType.Cmd => "cmd",
			ConsoleType.PowerShell => "ps1",
			_ => string.Empty,
		};
	}

	private static Encoding ConsoleTypeToEncoding(ConsoleType type)
	{
		switch (type)
		{
			case ConsoleType.Cmd:
#if false
				return Encoding.Default;
#else
				var enc = CodePagesEncodingProvider.Instance.GetEncoding(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage);
				return enc ?? Encoding.Default;
#endif

			case ConsoleType.PowerShell:
				return Encoding.UTF8;

			case ConsoleType.Unknown:
			case ConsoleType.Console:
			default:
				return Encoding.Default;
		}
	}

	public static bool ConsoleTypeToRuntime(ConsoleType type, out string? runtime, out string? argument)
	{
		switch (type)
		{
			case ConsoleType.Cmd:
				runtime = "cmd.exe";
				argument = "/c";
				break;

			case ConsoleType.PowerShell:
				runtime = Configs.PowerShell ? "pwsh.exe" : "powershell.exe";
				argument = "-File";
				break;

			case ConsoleType.Unknown:
			case ConsoleType.Console:
			default:
				runtime = null;
				argument = null;
				return false;
		}

		return true;
	}
}

public enum ConsoleType
{
	[Description("알수없음")]
	Unknown,
	[Description("콘설")]
	Console,
	[Description("커맨드")]
	Cmd,
	[Description("파워쉘")]
	PowerShell,
}
