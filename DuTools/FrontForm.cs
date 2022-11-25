using DuTools.Properties;

namespace DuTools;

public partial class FrontForm : Form
{
	private static FrontForm? _instance;

	private readonly BadakFormWorker _bfw;

	private readonly object? _start_obj;

	private readonly Font _recent_button_font;
	private readonly List<BadakButton> _recent_buttons = new();
	private readonly Dictionary<CommandList, EventHandler> _recent_events = new();

	#region 컨스트럭터

	public static FrontForm Instance
	{
		get
		{
			if (_instance == null)
				throw new InvalidOperationException("메인 인스턴스가 없다니 이게 무슨 말이오");
			return _instance;
		}
		private set => _instance = value;
	}

	//
	public FrontForm(object? obj = null)
	{
		_instance ??= this;

		InitializeComponent();

		Opacity = 0;
		SystemButton.Form = this;
		_bfw = new BadakFormWorker(this, SystemButton);

		//
		KeyPreview = true;

		if (TestEnv.IsAdministrator)
			RunAsLabel.Visible = true;

		_recent_button_font = new Font(TestSampleButton.Font.FontFamily, 7.0F, FontStyle.Italic, GraphicsUnit.Point);

		//
		_recent_events.Add(CommandList.Calculator, CalculatorMenuItem_Click);
		_recent_events.Add(CommandList.Converter1, Converter1MenuItem_Click);
		_recent_events.Add(CommandList.DuConsole, DuConsoleMenuItem_Click);
		_recent_events.Add(CommandList.DuGetBlog, DuGetBlogMenuItem_Click);

		//
		_start_obj = obj;
	}
	#endregion

	#region 폼 기본
	private void FrontForm_Load(object sender, EventArgs e)
	{
		Configs.AtOnLoad(this);
		RefreshRecentlyCommand();

		if (_start_obj is CommandWork.ConsoleScript cs)
		{
			var form = CommandForm.DuConsoleForm.Instance;
			SetActiveForm(form);
			form.PrepareScript(cs);
			return;
		}

		SetActiveForm(CommandForm.OhNoForm.Instance);
	}

	private void FrontForm_FormClosing(object sender, FormClosingEventArgs e)
	{

	}

	private void FrontForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		Configs.AtOnClosed(this);
	}

	private void SystemButton_CloseOrder(object sender, EventArgs e)
	{
		// 엥... 이거 필요없능데
	}

	private void TopPanel_MouseDown(object sender, MouseEventArgs e)
	{
		_bfw.DragOnDown(e);
	}

	private void TopPanel_MouseUp(object sender, MouseEventArgs e)
	{
		_bfw.DragOnUp(e);
	}

	private void TopPanel_MouseMove(object sender, MouseEventArgs e)
	{
		_bfw.DragOnMove(e);
	}

	protected override void WndProc(ref Message m)
	{
		if (_bfw.WndProc(ref m))
			return;

		FormDu.MagneticDockForm(ref m, this, 10);
		base.WndProc(ref m);
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		FormDu.EffectAppear(this);
	}

	private void FrontForm_Layout(object sender, LayoutEventArgs e)
	{
		//LayoutRecentlyCommand();
	}

	private void FrontForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			if (CommandForm.DuConsoleForm.HasInstance)
				CommandForm.DuConsoleForm.Instance.WaitProcess();
			Close();
		}
	}
	#endregion

	#region 메뉴아이템
	private void CalculatorMenuItem_Click(object? sender, EventArgs e)
	{
		AddRecentlyCommand(CommandList.Calculator);
	}

	private void Converter1MenuItem_Click(object? sender, EventArgs e)
	{
		AddRecentlyCommand(CommandList.Converter1);
	}

	private void DuConsoleMenuItem_Click(object? sender, EventArgs e)
	{
		if (AddRecentlyCommand(CommandList.DuConsole))
			SetActiveForm(CommandForm.DuConsoleForm.Instance);
	}

	private void DuGetBlogMenuItem_Click(object? sender, EventArgs e)
	{
		AddRecentlyCommand(CommandList.DuGetBlog);
	}

	// 확장자 등록
	private void SettingRegisterExtensionsMenuItem_Click(object? sender, EventArgs e)
	{
		if (MsgBox(Resources.RegisterExtensionsDuConsole) == DialogResult.Yes)
		{
			// DuConsole
			RegKey.RegisterExtension(".duc", "DuConsole.duc", "DuConsole script", Application.ExecutablePath);
			RegKey.RegisterExtension(".duconsole", "DuConsole.duconsole", "DuConsole script", Application.ExecutablePath);
		}

		if (MsgBox(Resources.RegisterExtensionsOthers) == DialogResult.Yes)
		{
			// 딴거 해야함
		}
	}

	// 최신꺼 버튼 눌림
	private void RecentlyButton_Click(object? sender, EventArgs e)
	{
		if (sender is not BadakButton btn)
			return;

		var cmd = btn.Tag is CommandList tag ? tag : CommandList.OhNo;
		if (_recent_events.TryGetValue(cmd, out var ev))
			ev(sender, e);
	}

	public static DialogResult MsgBox(Form form, string message, MessageBoxButtons btns = MessageBoxButtons.YesNo,
		MessageBoxIcon icon = MessageBoxIcon.Question)
	{
		return MessageBox.Show(form, message, Resources.LetMeKnow, btns, icon);
	}

	public DialogResult MsgBox(string message, MessageBoxButtons btns = MessageBoxButtons.YesNo,
		MessageBoxIcon icon = MessageBoxIcon.Question)
	{
		return MsgBox(this, message, btns, icon);
	}
	#endregion

	#region 최근 명령 관련
	private bool AddRecentlyCommand(CommandList recent_cmd)
	{
		var notsame = Configs.AddCommand(recent_cmd);

		if (notsame)
			RefreshRecentlyCommand();

		if (_recent_buttons.Count > 0)
			_recent_buttons[0].ActiveStyle = true;

		CommandLabel.Text = recent_cmd.GetDescription();

		return notsame;
	}

	private void RefreshRecentlyCommand()
	{
		foreach (var btn in _recent_buttons)
			TopPanel.Controls.Remove(btn);
		_recent_buttons.Clear();

		var max_right = RunAsLabel.Location.X;
		var recents = Configs.RecentlyCommand.ToArray().Reverse();
		var x = 10;

		foreach (var cmd in recents)
		{
			if (x + 84 > max_right)
				break;

			var btn = new BadakButton()
			{
				Location = new Point(x, 10),
				Size = new Size(80, 60),
				Font = _recent_button_font,
				TextImageRelation = TextImageRelation.ImageAboveText,
				Text = cmd.GetDescription(),
				Image = Resources.ResourceManager.GetObject($"icon_cmd_{cmd}") as Image,
				Tag = cmd,
				ActiveStyle = false,
			};
			btn.Click += RecentlyButton_Click;

			_recent_buttons.Add(btn);
			TopPanel.Controls.Add(btn);

			x += 84;
		}
	} 
	#endregion

	private void SetActiveForm(Form form)
	{
		WorkPanel.Controls.Clear();
		WorkPanel.Controls.Add(form.Controls[0]);
	}

	public static void InvokeAction(Action action)
		=> _instance?.Invoke(action);
}
