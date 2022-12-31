using DuTools.Properties;

namespace DuTools.CommandWork.DuGetBlog;

internal class BlogPlayViorate : BlogPlayBase
{
	public override async Task ReadPage(WebPageParam param)
	{
		if (_pw == null || _br == null || _page == null)
			return;

		var url = $"{param.BaseUrl}{param.Index}";

		try
		{
			await _page.GotoAsync(url);

			var epci = await _page.QuerySelectorAsync("div.post-cover div.inner");
			if (epci == null) throw new (Resources.ExceptionNoTagInBlog);

			//
			var sctg = await epci.QueryTextContentAsync("span.category");
			var ssrs = await epci.QueryTextContentAsync("h1");
			param.Title = $"{sctg} : {ssrs}";

			//
			param.Date = await epci.QueryTextContentAsync("span.date") ?? string.Empty;

			//
			var eec = await _page.QuerySelectorAsync("div.entry-content");
			if (eec == null) throw new (Resources.ExceptionNoTagInBlog);

			var earticle = await eec.QuerySelectorAsync("div");
			if (earticle == null) throw new (Resources.ExceptionNoTagInBlog);

			param.Text = await earticle.QueryAllTextSelectorAsync("p");

			//
			var eac = await eec.QuerySelectorAsync("div.another_category");
			if (eac == null) throw new(Resources.ExceptionNoTagInBlog);

			/*var eas = await eac.QuerySelectorAllAsync("a");
			foreach (var ea in eas)
			{
				var href = await ea.GetAttributeAsync("href");
				if (href == null) continue;
				// href로 뭘 해야하는데 이거 안쓴다
			}*/

			var nexts = RexBlog.ViorateGetList().
				Matches(await eac.InnerHTMLAsync()).
				TakeWhile(m => m.Groups.Count >= 3).
				Select(m => Convert.ToInt64(m.Groups[1].Value)).
				Where(item => item > param.Index).
				ToList();

			if (nexts.Count > 0)
			{
				nexts.Sort();
				param.NextIndex = nexts[0];
			}
		}
		catch (Exception ex)
		{
			param.Text = $"{Resources.CannotOpenBlog}{url}{Environment.NewLine}{ex.Message}";
		}
	}
}
