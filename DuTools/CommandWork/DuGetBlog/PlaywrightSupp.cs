using Microsoft.Playwright;

namespace DuTools.CommandWork.DuGetBlog;

internal static class PlaywrightSupp
{
	internal static async Task<string?> QueryTextContentAsync(this IPage page, string selector)
	{
		var h = await page.QuerySelectorAsync(selector);
		if (h == null) return null;

		var s = await h.TextContentAsync();
		return s?.Replace("\u200B", string.Empty).Trim();
	}

	internal static async Task<string?> QueryTextContentAsync(this IElementHandle? eh, string selector)
	{
		if (eh == null) return null;

		var h = await eh.QuerySelectorAsync(selector);
		if (h == null) return null;

		var s = await h.TextContentAsync();
		return s?.Replace("\u200B", string.Empty);
	}

	public static string ReplaceHtmlTag(this string html)
	{
		var s = html.Trim();
		s = RexBlog.StripBr().Replace(s, "\n");
		s = RexBlog.StripTags().Replace(s, string.Empty);
		s = s.
			Replace("\r", string.Empty).
			Replace("&nbsp;", " ").
			Replace("&lt;", "<").
			Replace("&gt;", ">").
			Replace("&quot;", "\"").
			Replace("&amp;", "&").
			Replace("&copy;", "ⓒ").
			Replace("\u200B", string.Empty);
		return s;
	}

	private static async Task<string?> InternalInnerHtmlAsync(this IElementHandle eh)
	{
		var inner = await eh.InnerHTMLAsync();
		var br_count = RexBlog.StripBr().Count(inner);
		if (br_count == 0)
			return null;

		inner = inner.ReplaceHtmlTag();
		if (inner.EndsWith("\n\n"))
			inner = inner.Replace("\n\n", "\n");
		return inner;
	}

	public static async Task<string> QueryAllTextSelectorAsync(this IElementHandle? eh, string selector, bool parseBrTag = true)
	{
		if (eh == null)
			return string.Empty;

		StringBuilder sb = new();

		var paras = await eh.QuerySelectorAllAsync(selector);
		if (parseBrTag)
		{
			foreach (var p in paras)
			{
				var s = await p.TextContentAsync();
				if (s == null) continue;

				var sparse = await p.InternalInnerHtmlAsync();
				sb.AppendLine(sparse ?? s.Replace("\u200B", string.Empty));
			}
		}
		else
		{
			foreach (var p in paras)
			{
				var s = await p.TextContentAsync();
				if (s != null)
					sb.AppendLine(s.Replace("\u200B", string.Empty));
			}
		}

		return sb.ToString();
	}

	public static async Task<string> QueryAllTextSelectorAllAsync(this IElementHandle? eh, string selector, bool parseBrTag = true, string childSelector = "p")
	{
		if (eh == null)
			return string.Empty;

		StringBuilder sb = new();

		var mods = await eh.QuerySelectorAllAsync(selector);
		if (parseBrTag)
		{
			foreach (var m in mods)
			{
				var paras = await m.QuerySelectorAllAsync(childSelector);
				foreach (var p in paras)
				{
					var s = await p.TextContentAsync();
					if (s == null) continue;

					var sparse = await p.InternalInnerHtmlAsync();
					sb.AppendLine(sparse ?? s.Replace("\u200B", string.Empty));
				}
			}
		}
		else
		{
			foreach (var m in mods)
			{
				var paras = await m.QuerySelectorAllAsync(childSelector);
				foreach (var p in paras)
				{
					var s = await p.TextContentAsync();
					if (s != null)
						sb.AppendLine(s.Replace("\u200B", string.Empty));
				}
			}
		}

		return sb.ToString();
	}
}
