using DuTools.CommandWork;
using DuTools.CommandWork.DuGetBlog;
using DuTools.Properties;

namespace DuTools.CommandForm;

public partial class DuGetBlogForm : Form
{
	public DuGetBlogForm()
	{
		InitializeComponent();

		SiteCombo.SelectedIndex = 0;
		BookNameText.Text = Resources.DefaultBookName;

#if DEBUG
		UrlText.Text = "https://viorate.tistory.com/576";
		//UrlText.Text = "https://m.blog.naver.com/ishuca74/222928728040";
#endif
	}

	private async void DoItButton_Click(object sender, EventArgs e)
	{
		var url = UrlText.Text;
		var bookname = BookNameText.Text;

		if (url.Length == 0)
		{
			SetContentError(Resources.NoUrlAddress);
			return;
		}

		if (bookname.Length == 0)
		{
			SetContentError(Resources.NoBookName);
			return;
		}

		IWebPageReader? rs;

		if (url.Contains("/viorate.tistory.com"))
		{
			SiteCombo.SelectedIndex = 2;
			rs = new BlogSiteViorate();
		}
		else
		{
			SiteCombo.SelectedIndex = 0;
			SetContentError(Resources.NoSupportBlogSite);
			return;
		}

		EnableControls = false;
		TaskList.Items.Clear();

		var param = rs.CreateParam(url);

		await Task.Run(() =>
		{
			var filename = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{bookname}.txt");
			using StreamWriter sw = new(filename, false, Encoding.UTF8);

			rs.Prepare();

			while (true)
			{
				//if (param.Count > 5) break;

				param.Count++;
				PagesLabel.Invoke(()=> PagesLabel.Text = param.Count.ToString());

				param.BlogBeforeRead();
				rs.ReadPage(param, sw);
				param.BlogAfterRead(sw);

				SetContentText(param.Text);
				TaskList.Invoke(() =>
				{ 
					TaskList.Items.Add($"{param.Index} ➜ {param.Title}");
					TaskList.TopIndex = TaskList.Items.Count - 1;
				});

				if (param.NextIndex < 0) break;

				param.Index = param.NextIndex;
				Task.Delay(20);
			}

			rs.Clean();
		});

		EnableControls = true;
	}

	private bool EnableControls
	{
		set
		{
			DoItButton.Enabled = value;
			UrlText.Enabled=value;
			BookNameText.Enabled = value;
			SiteCombo.Enabled = value;
			ContentText.Enabled = value;
		}
	}

	private void SetContentError(string message)
	{
		ContentText.Invoke(() =>
		{
			ContentText.BackColor = Color.Red;
			ContentText.Text = message;
		});
	}

	private void SetContentText(string message)
	{
		ContentText.Invoke(() =>
		{
			ContentText.BackColor = Color.FromArgb(90, 90, 90);
			ContentText.Text = message;
		});
	}
}
