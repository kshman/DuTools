using DuTools.Properties;

namespace DuTools.CommandForm;

public partial class OhNoForm : Form
{
	public OhNoForm()
	{
		InitializeComponent();

		label1.Font = new Font(base.Font.FontFamily, 48F,
			FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
	}

	private void RepoUrlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		const string c_repo_url = "https://github.com/kshman/DuTools";
		try
		{
			Process.Start(new ProcessStartInfo()
			{
				FileName = c_repo_url,
				UseShellExecute = true,
			});
		}
		catch (Exception ex)
		{
			FrontForm.MsgBox(this, $"{Resources.CannotOpenWebsite}{ex.GetMessage()}");
		}
	}
}
