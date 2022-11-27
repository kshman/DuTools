using DuTools.Properties;
using Microsoft.Playwright;

namespace DuTools.CommandWork.DuGetBlog;

internal class BlogSiteNaverMobile : IWebPageReader
{
	private IPlaywright? _pw;
	private IBrowser? _br;
	private IPage? _page;

	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore().ConfigureAwait(false);
		GC.SuppressFinalize(this);
	}

	private async ValueTask DisposeAsyncCore()
	{
		if (_br != null)
			await _br.DisposeAsync().ConfigureAwait(false);
		_pw?.Dispose();
	}

	public WebPageParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new WebPageParam(url[..slash], Converter.ToLong(url[slash..]));
	}

	public async Task Prepare()
	{
		_pw = await Playwright.CreateAsync();
		_br = await _pw.Chromium.LaunchAsync(new()
		{
			Channel = "msedge",
			Headless = true,
		});
		_page = await _br.NewPageAsync();
	}

	public async Task ReadPage(WebPageParam param, StreamWriter sw)
	{
		if (_pw == null || _br == null || _page == null)
			return;

		var url = $"{param.BaseUrl}{param.Index}";

		try
		{
			await _page.GotoAsync(url);

			//
			param.Title = (await _page.TitleAsync()).Trim();
			var n = param.Title.IndexOf(" : 네이버 블로그", StringComparison.Ordinal);
			if (n >= 0)
				param.Title = param.Title[..n];

			var eh = await _page.QuerySelectorAsync("p.blog_date");
			if (eh != null)
				param.Date = (await eh.TextContentAsync())?.Trim() ?? DateTime.Now.ToString();

			//
			eh = await _page.QuerySelectorAsync("div.se-main-container");
			if (eh != null)
			{
				StringBuilder sb = new();

				var smts = await eh.QuerySelectorAllAsync("div.se-module-text");
				foreach (var smt in smts)
				{
					var ps = await smt.QuerySelectorAllAsync("p");
					foreach (var p in ps)
					{
						var s = (await p.TextContentAsync())?.Replace("\u200B", string.Empty);
						sb.AppendLine(s ?? string.Empty);
					}
				}

				param.Text= sb.ToString();
			}

			//
			eh = await _page.QuerySelectorAsync("div.wrap_postlist");
			if (eh == null)
				return;

			var eaa = await eh.QuerySelectorAllAsync("a.link");
			if (eaa == null)
				return;

			List<long> nexts = new();
			foreach (var a in eaa)
			{
				var href = await a.GetAttributeAsync("href");
				if (href != null)
				{
					var logat = href.IndexOf("logNo", StringComparison.OrdinalIgnoreCase) + 6;
					var logno = href[logat..];
					var item = Convert.ToInt64(logno);
					if (item > param.Index)
						nexts.Add(item);
				}
			}

			if (nexts.Count <= 0)
				return;

			nexts.Sort();
			param.NextIndex = nexts[0];
		}
		catch (Exception ex)
		{
			param.Text = $"{Resources.CannotOpenBlog}{url}{Environment.NewLine}{ex.Message}";
		}
	}
}
