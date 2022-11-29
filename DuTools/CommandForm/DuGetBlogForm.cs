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
		UrlText.Text = "https://viorate.tistory.com/4489";
		//UrlText.Text = "https://m.blog.naver.com/ishuca74/222928728040";
#endif

		// 엣지 체크
		using (var rk = new RegKey("Microsoft\\Edge\\BLBeacon"))
		{
			if (rk.IsOpen)
			{
				var ver = rk.GetString("version");
				if (ver != null)
				{
					ContentText.Text = $@"{Resources.FoundMsEdgeWith}{ver}";
					return;
				}
			}
		}

		ContentText.ForeColor = Color.White;
		ContentText.BackColor = Color.LightPink;
		ContentText.Text = Resources.NoMsEdgeNoWork;
		EnableControls = false;
	}

	private async void DoItButton_Click(object sender, EventArgs e)
	{
		var url = UrlText.Text;
		var book_name = BookNameText.Text;

		if (url.Length == 0)
		{
			SetContentError(Resources.NoUrlAddress);
			return;
		}

		if (book_name.Length == 0)
		{
			SetContentError(Resources.NoBookName);
			return;
		}

		IWebPageReader? rs;

		if (url.Contains("/m.blog.naver.com"))
		{
			SiteCombo.SelectedIndex = 1;
			rs = new BlogPlayNaverM();
		}
		else if (url.Contains("/viorate.tistory.com"))
		{
			SiteCombo.SelectedIndex = 2;
			rs = Configs.PreferPlaywright ?
				new BlogPlayViorate() :
				new BlogHttpViorate();
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

		await Task.Run(async () =>
		{
			var filename = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{book_name}.txt");
			await using StreamWriter sw = new(filename, false, Encoding.UTF8);

			AddTaskList($"[{Resources.BeginOfTask}]");
			await rs.Prepare();

			while (true)
			{
#if DEBUG
				if (param.Count > 5) break;
#endif

				param.Count++;
				PagesLabel.Invoke(() => PagesLabel.Text = param.Count.ToString());

				param.BlogBeforeRead();
				await rs.ReadPage(param, sw);
				param.BlogAfterRead(sw);

				SetContentText(param.Text);
				AddTaskList($"{param.Index} ➜ {param.Title}");

				if (param.NextIndex < 0) break;

				param.Index = param.NextIndex;
				//await Task.Delay(10);
			}

			AddTaskList($"[{Resources.EndOfTask}]");
			await rs.DisposeAsync();
		});

		EnableControls = true;
	}

	private bool EnableControls
	{
		set
		{
			DoItButton.Enabled = value;
			UrlText.Enabled = value;
			BookNameText.Enabled = value;
			SiteCombo.Enabled = value;
			ContentText.Enabled = value;
		}
	}

	private void SetContentError(string message)
	{
		ContentText.Invoke(() =>
		{
			ContentText.ForeColor = Color.White;
			ContentText.BackColor = Color.LightPink;
			ContentText.Text = message;
		});
	}

	private void SetContentText(string message)
	{
		ContentText.Invoke(() =>
		{
			ContentText.ForeColor = Color.White;
			ContentText.BackColor = Color.FromArgb(90, 90, 90);
			ContentText.Text = message;
		});
	}

	private void AddTaskList(string message)
	{
		TaskList.Invoke(() =>
		{
			TaskList.Items.Add(message);
			TaskList.TopIndex = TaskList.Items.Count - 1;
		});
	}
}
