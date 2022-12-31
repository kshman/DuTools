namespace DuTools.CommandWork;

internal class WebPageParam
{
    public string BaseUrl { get; set; }
    public long Index { get; set; }

    public int Count { get; set; }
    public long NextIndex { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;

    public bool ParseLink { get; set; }
    public List<string> Links { get; private set; } = new List<string>();

    public WebPageParam(string baseurl, long index)
    {
        BaseUrl = baseurl;
        Index = index;
    }

    public void BlogBeforeRead()
    {
        NextIndex = -1;
        Title = string.Empty;
        Date = string.Empty;
        Text = string.Empty;
    }

    public void BlogAfterRead(StreamWriter sw)
    {
        if (string.IsNullOrEmpty(Text)) return;

        sw.WriteLine();
        sw.WriteLine("--------------------");
        sw.WriteLine(string.IsNullOrEmpty(Date) ? Title : $"{Title} ({Date})");
        sw.WriteLine(Text);
        sw.WriteLine();
    }
}
