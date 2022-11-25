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
	}
}

/// <summary>
/// 커맨드
/// </summary>
public enum CommandList
{
	OhNo,

	Calculator,
	Converter1,

	DuConsole,
	DuGetBlog,
}
