using System.ComponentModel;

namespace DuTools;

/// <summary>
/// 컨피그
/// </summary>
internal static class Configs
{
	private const string c_key = "PuruLive\\DuTools";

	public static Font? TextBoxFont;

	public static string LastFolder { get; set; } = string.Empty;
	public static bool PowerShell { get; set; }
	public static List<CommandList> RecentlyCommand { get; } = new();
	public static CommandList LastCommand { get; set; }

	//
	private static RegKey OpenKey(bool create = false) => new(c_key, create);

	//
	public static void AtOnLoad(Form form)
	{
		// 텍스트박스 글꼴
		var fontnames = new[]
		{
			"Bitstream Vera Sans Mono",
			"Consolas",
			"Tahoma",
		};
		var n = TestFont.IsInstalled(fontnames);
		if (n >= 0)
			TextBoxFont = new Font(fontnames[n], 9.0f, FontStyle.Regular, GraphicsUnit.Point);

		//
		using var rk = OpenKey();
		if (!rk.IsOpen)
			return;

		string? s;

		// 윈도우 위치와 크기
		s = rk.GetString("Window");
		if (!string.IsNullOrWhiteSpace(s))
		{
			var ss = s.Split(',');
			if (ss.Length == 4)
			{
				var loc = Converter.ToPoint(ss[0], ss[1], form.Location);
				var sz = Converter.ToSize(ss[2], ss[3], form.Size);

				var scr = Screen.FromControl(form);
				if (loc.X > scr.WorkingArea.Size.Width) loc.X = form.Location.X;
				if (loc.Y > scr.WorkingArea.Size.Height) loc.Y = form.Location.Y;

				form.Location = loc;
				form.Size = sz;
			}
		}

		// 마지막 폴더
		if (string.IsNullOrWhiteSpace(LastFolder))
		{
			s = rk.GetDecodingString("LastFolder");
			if (!string.IsNullOrWhiteSpace(s) && Directory.Exists(s))
				LastFolder = s;
		}

		// 기본 파워쉘
		PowerShell = rk.GetBool("PowerShell");

		// 최근 명령
		s = rk.GetString("RecentlyCommand");
		if (!string.IsNullOrWhiteSpace(s))
		{
			foreach (var cs in s.Split(','))
				if (Enum.TryParse<CommandList>(cs, out var cmd))
					RecentlyCommand.Add(cmd);
		}

		// 최근 시작
		rk.SetLong("ProgramStart", DateTime.UtcNow.Ticks);
	}

	// 
	public static void AtOnClosed(Form form)
	{
		using var rk = OpenKey(true);
		if (!rk.IsOpen)
			return;

		rk.SetString("Window",
			$"{form.Location.X},{form.Location.Y},{form.Size.Width},{form.Size.Height}");
		rk.SetEncodingString("LastFolder", LastFolder);
		rk.SetString("RecentlyCommand", string.Join(',', RecentlyCommand));

		rk.SetLong("ProgramClose", DateTime.UtcNow.Ticks);
	}

	//
	public static bool AddCommand(CommandList cmd)
	{
		if (cmd == LastCommand)
			return false;

		var n = RecentlyCommand.IndexOf(cmd);
		if (n >= 0)
			RecentlyCommand.RemoveAt(n);
		RecentlyCommand.Add(cmd);

		LastCommand = cmd;
		return true;
	}

	//
	public static void LastFolderFromFilename(string filename)
	{
		var fi = new FileInfo(filename);
		LastFolder = fi.DirectoryName ?? string.Empty;
	}
}

/// <summary>
/// 커맨드
/// </summary>
public enum CommandList
{
	[Description("기능없어요")]
	OhNo,

	[Description("계산기")]
	Calculator,
	[Description("컨버터#1")]
	Converter1,

	[Description("스트립트")]
	DuConsole,
	[Description("블로그")]
	DuGetBlog,
}
