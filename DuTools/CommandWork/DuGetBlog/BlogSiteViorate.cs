﻿namespace DuTools.CommandWork.DuGetBlog;

internal class BlogSiteViorate : IWebPageReader
{
	public WebPageParam CreateParam(string url)
	{
		var slash = url.LastIndexOf('/') + 1;
		return new(url[..slash], Convert.ToInt64(url[slash..]));
	}

	public void Prepare()
	{
	}

	public void Clean()
	{
	}

	public void ReadPage(WebPageParam param, StreamWriter sw)
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

			var striphtml = html[bdiv..ediv];
			striphtml = RexBlog.StripPOpen().Replace(striphtml, string.Empty);
			striphtml = RexBlog.StripPClose().Replace(striphtml, "\n");
			striphtml = RexBlog.StripBr().Replace(striphtml, "\n");
			striphtml = RexBlog.StripTags().Replace(striphtml, string.Empty);
			striphtml = striphtml.
				Replace("\n\n\n", "\n\n").
				Replace("\r\n\r\n\r\n", "\n\n").
				Replace("&nbsp;", string.Empty);
			param.Text = RexBlog.StripAmps().Replace(striphtml, "⊙");

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

			if (nexts.Count <= 0)
				return;

			nexts.Sort();
			param.NextIndex = nexts[0];
		}
		catch (Exception ex)
		{
			param.Text += Environment.NewLine;
			param.Text += ex.Message;
		}
	}
}
