using DuTools.Properties;

namespace DuTools.CommandWork.DuGetBlog;

internal class BlogPlayNaverM : BlogPlayBase
{
	public override async Task ReadPage(WebPageParam param, StreamWriter sw)
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

			//
			param.Date = (await _page.QueryTextContentAsync("p.blog_date")) ?? string.Empty;

			// 
			var esmc = await _page.QuerySelectorAsync("div.se-main-container");
			param.Text = await esmc.QueryAllTextSelectorAllAsync("div.se-module-text");

			//
			var ewp = await _page.QuerySelectorAsync("div.wrap_postlist");
			if (ewp == null) return;

			List<long> nexts = new();
			foreach (var a in await ewp.QuerySelectorAllAsync("a.link"))
			{
				var href = await a.GetAttributeAsync("href");
				if (href == null) continue;

				var logat = href.IndexOf("logNo", StringComparison.OrdinalIgnoreCase) + 6;
				var logno = href[logat..];
				var item = Convert.ToInt64(logno);
				if (item > param.Index)
					nexts.Add(item);
			}

			if (nexts.Count <= 0) return;

			nexts.Sort();
			param.NextIndex = nexts[0];
		}
		catch (Exception ex)
		{
			param.Text = $"{Resources.CannotOpenBlog}{url}{Environment.NewLine}{ex.Message}";
		}
	}
}
