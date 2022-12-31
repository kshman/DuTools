using DuTools.Properties;
using Microsoft.VisualBasic.Logging;

namespace DuTools.CommandWork.DuGetBlog;

internal class BlogPlayNaverM : BlogPlayBase
{
    public override async Task ReadPage(WebPageParam param)
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

            // 링크
            if (param.ParseLink)
            {
                // se-component se-oglink
                foreach (var eog in await _page.QuerySelectorAllAsync("div.se-module-oglink"))
                {
                    var t = eog.ToString();
                    System.Diagnostics.Debug.WriteLine(t);
                    foreach (var a in await eog.QuerySelectorAllAsync("a.link"))
                    {
                        var href = await a.GetAttributeAsync("href");
                        if (href != null && !param.Links.Contains(href))
                            param.Links.Add(href);
                    }
                }

                // se-module-text
                var emtxt = await _page.QuerySelectorAsync("div.se-module-text");
                if (emtxt != null)
                {
                    foreach (var a in await emtxt.QuerySelectorAllAsync("a.link"))
                    {
                        var href = await a.GetAttributeAsync("href");
                        if (href != null && !param.Links.Contains(href))
                            param.Links.Add(href);
                    }
                }
            }

            // 본문
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
