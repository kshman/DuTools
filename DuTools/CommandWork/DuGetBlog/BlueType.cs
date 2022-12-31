namespace DuTools.CommandWork.DuGetBlog;

public enum BlogType
{
    Unknown,
    TistoryViolate,
    NaverBlog,
    Blogspot,
}

internal static class SuppBlogType
{
    internal static BlogType ToBlogType(this string s)
    {
        if (s.Contains("/viorate.tistory.com"))
            return BlogType.TistoryViolate;
        if (s.Contains("/m.blog.naver.com")) 
            return BlogType.NaverBlog;
        if (s.Contains("blogspot.com"))
            return BlogType.Blogspot;
        return BlogType.Unknown;
    }
}
