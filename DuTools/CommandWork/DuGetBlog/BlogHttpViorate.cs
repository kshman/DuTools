namespace DuTools.CommandWork.DuGetBlog;

internal class BlogHttpViorate : IWebPageReader
{
	public async ValueTask DisposeAsync()
	{
		await Task.CompletedTask;
	}

	public WebPageParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new(url[..slash], Convert.ToInt64(url[slash..]));
	}

	public async Task Prepare()
	{
		await Task.CompletedTask;
	}

	public async Task ReadPage(WebPageParam param, StreamWriter sw)
	{
		var url = $"{param.BaseUrl}{param.Index}";

		try
		{
			HttpClient hc = new();
			var res = hc.GetStringAsync(url);
			var html = res.Result;

			//
			param.Title = string.Empty;
			var mm = RexBlog.GetTitle().Match(html);
			if (mm.Groups.Count > 1) param.Title = mm.Groups[1].Value;

			param.Date = string.Empty;
			mm = RexBlog.ViorateGetDate().Match(html);
			if (mm.Groups.Count > 1) param.Date = mm.Groups[1].Value;

			//
			var bdiv = html.IndexOf("<div class=\"entry-content\">", StringComparison.Ordinal);
			if (bdiv < 0) throw new("시작 지점이 없어요");
			var ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
			if (ediv < 0) throw new("끝 지점이 없어요");

			var shtml = html[bdiv..ediv];
			shtml = RexBlog.StripPOpen().Replace(shtml, string.Empty);
			shtml = RexBlog.StripPClose().Replace(shtml, "\n");
			shtml = shtml.ReplaceHtmlTag().Replace("\n\n\n", "\n\n");
			//param.Text = RexBlog.StripAmps().Replace(shtml, "⊙");
			param.Text = shtml;

			//
			bdiv = html.IndexOf("<div class=\"another_category another_category_color_gray\">", StringComparison.Ordinal);
			if (bdiv < 0) throw new("시작 지점이 없어요");
			ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
			if (ediv < 0) throw new("끝 지점이 없어요");

			var nexts = RexBlog.ViorateGetList()
				.Matches(html[bdiv..ediv])
				.TakeWhile(m => m.Groups.Count >= 3)
				.Select(m => Convert.ToInt64(m.Groups[1].Value))
				.Where(item => item > param.Index)
				.ToList();

			if (nexts.Count > 0)
			{
				nexts.Sort();
				param.NextIndex = nexts[0];
			}
		}
		catch (Exception ex)
		{
			param.Text += Environment.NewLine;
			param.Text += ex.Message;
		}

		await Task.CompletedTask;
	}
}
