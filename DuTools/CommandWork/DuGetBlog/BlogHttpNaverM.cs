namespace DuTools.CommandWork.DuGetBlog;

internal class BlogHttpNaverM : IWebPageReader
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

    public async Task ReadPage(WebPageParam param)
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
            if (mm.Groups.Count > 1)
            {
                var title = mm.Groups[1].Value;
                var n = title.IndexOf(" : 네이버 블로그", StringComparison.Ordinal);
                param.Title = n < 0 ? title : title[..n];
            }

            param.Date = string.Empty;
            mm = RexBlog.NaverGetDate().Match(html);
            if (mm.Groups.Count > 1) param.Date = mm.Groups[1].Value;

            // 본문 다 끌어 놓기
            var sb = new StringBuilder();
            int bdiv, ediv;

            if (param.ParseLink)
            {
                for (bdiv = 0; ;)
                {
                    bdiv = html.IndexOf("<div class=\"se-module se-module-oglink\">", bdiv, StringComparison.Ordinal);
                    if (bdiv < 0) break;
                    ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
                    if (ediv < 0) break;

                    var raw = html[bdiv..ediv];
                    bdiv = ediv;

                    mm = RexBlog.GetAhref().Match(raw);
                    if (mm.Success)
                    {
                        var link = mm.Groups[0].Value;
                        if (!param.Links.Contains(link))
                            param.Links.Add(link);
                    }
                }
            }

            for (bdiv = 0; ;)
            {
                bdiv = html.IndexOf("<div class=\"se-module se-module-text\">", bdiv, StringComparison.Ordinal);
                if (bdiv < 0) break;
                ediv = html.IndexOf("</div>", bdiv, StringComparison.Ordinal);
                if (ediv < 0) break;

                var stripeol = html[bdiv..ediv].Replace("<!-- } SE-TEXT -->", "\n");
                if (stripeol.Length > 0)
                    sb.AppendLine(stripeol);

                bdiv = ediv;
            }

            var shtml = sb.ToString();

            // 링크 뽑기 -> 본문에 링크를 두는 경우 때문에 넣음
            if (param.ParseLink)
            {
                mm = RexBlog.GetAhref().Match(shtml);
                while (mm.Success)
                {
                    var link = mm.Groups[0].Value;
                    if (!param.Links.Contains(link))
                        param.Links.Add(link);
                    mm = mm.NextMatch();
                }
            }

            // 실제 문서화
            shtml = RexBlog.StripPOpen().Replace(shtml, string.Empty);
            shtml = RexBlog.StripPClose().Replace(shtml, "\n");
            shtml = shtml.ReplaceHtmlTag().Replace("\n\n\n", "\n\n");
            param.Text = shtml;

            //
            bdiv = html.IndexOf("<tbody id=\"postBottomTitleListBody\">", StringComparison.Ordinal);
            if (bdiv < 0) throw new("시작 지점이 없어요");
            ediv = html.IndexOf("</tbody>", bdiv, StringComparison.Ordinal);
            if (ediv < 0) throw new("끝 지점이 없어요");

            var nexts = RexBlog.NaverLogNo()
                .Matches(html[bdiv..ediv])
                .TakeWhile(m => m.Groups.Count >= 2)
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
