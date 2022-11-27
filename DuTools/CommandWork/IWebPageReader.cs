namespace DuTools.CommandWork;

internal interface IWebPageReader : IAsyncDisposable
{
	WebPageParam CreateParam(string url);
	Task Prepare();
	Task ReadPage(WebPageParam param, StreamWriter sw);
}
