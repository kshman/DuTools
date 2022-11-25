namespace DuTools;

public partial class FrontForm : Form
{
	private readonly BadakFormWorker _bfw;
	private readonly object? _start_obj;

	//
	public FrontForm(object? obj = null)
	{
		InitializeComponent();

		Opacity = 0;
		SystemButton.Form = this;
		_bfw = new BadakFormWorker(this, SystemButton);

		_start_obj = obj;
	}

	//
	private void FrontForm_Load(object sender, EventArgs e)
	{
		if (TestEnv.IsAdministrator)
			RunAsLabel.Visible = true;

		Configs.AtOnLoad(this);
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
}
