using System.Security.Policy;
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
        string[] testUrls =
        {
            "https://viorate.tistory.com/4489", // 비오라테
			"https://m.blog.naver.com/ishuca74/222928728040", // 네버
			"https://m.blog.naver.com/jinho8895/222482426856", // 네버 인데 안에 또 추가
            "https://m.blog.naver.com/saiversta/221793987072", // 네버 한넬로네
        };
        UrlText.Text = testUrls[3];
        BinbCheck.Checked = true;
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
        SetEnableControls(false);
    }

    private async void DoItButton_Click(object sender, EventArgs e)
    {
        var book_name = BookNameText.Text;
        if (book_name.Length == 0)
        {
            SetContentError(Resources.NoBookName);
            return;
        }

        var blogType = DetectBlogType(UrlText.Text, true);
        IWebPageReader? rs = GetWebPageReader(blogType);
        if (rs == null)
            return;

        SetEnableControls(false);
        TaskList.Items.Clear();

        var param = rs.CreateParam(UrlText.Text);
        param.ParseLink = BinbCheck.Checked;

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

                if (BinbCheck.Checked)
                {
                    param.BlogBeforeRead();
                    await rs.ReadPage(param);

                    SetContentText(param.Text);
                    AddTaskList($"{param.Index} ➜ {param.Title}");
                    AddTaskList(param.Links.Count > 0 ?
                        $"    [링크 {param.Links.Count}개 찾았어요]" :
                        "     [링크가 없어요]");
                }
                else
                {
                    param.BlogBeforeRead();
                    await rs.ReadPage(param);
                    param.BlogAfterRead(sw);

                    SetContentText(param.Text);
                    AddTaskList($"{param.Index} ➜ {param.Title}");
                }

                if (param.NextIndex < 0) break;

                param.Index = param.NextIndex;
                //await Task.Delay(10);
            }

            AddTaskList($"[{Resources.EndOfTask}]");
            await rs.DisposeAsync();
        });

        SetEnableControls(true);
    }

    private void SetEnableControls(bool value)
    {
        DoItButton.Enabled = value;
        UrlText.Enabled = value;
        BookNameText.Enabled = value;
        SiteCombo.Enabled = value;
        ContentText.Enabled = value;
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

    private void UrlText_TextChanged(object sender, EventArgs e)
    {
        DetectBlogType(UrlText.Text);
    }

    private BlogType DetectBlogType(string s, bool alsoSetError = false)
    {
        if (alsoSetError && string.IsNullOrWhiteSpace(s))
        {
            SetContentError(Resources.NoUrlAddress);
            return BlogType.Unknown;
        }

        var b = s.ToBlogType();
        SiteCombo.SelectedIndex = (int)b;

        if (alsoSetError && b == BlogType.Unknown)
            SetContentError(Resources.NoSupportBlogSite);

        return b;
    }

    private static IWebPageReader? GetWebPageReader(BlogType b)
    {
        /*
        if (BinbCheck.Checked)
        {
            return b switch
            {
                BlogType.TistoryViolate => new BlogHttpViorate(),
                BlogType.NaverBlog => new BlogHttpNaverM(),
                _ => null,
            };
        }
        else
        {
            return b switch
            {
                BlogType.TistoryViolate => Configs.PreferPlaywright ? new BlogPlayViorate() : new BlogHttpViorate(),
                BlogType.NaverBlog => new BlogPlayNaverM(),
                _ => null,
            };
        }
        */
        return b switch
        {
            BlogType.TistoryViolate => Configs.PreferPlaywright ? new BlogPlayViorate() : new BlogHttpViorate(),
            BlogType.NaverBlog => new BlogPlayNaverM(),
            _ => null,
        };
    }
}
