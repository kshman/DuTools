namespace DuTools.CommandWork;

internal interface IWebPageReader
{
	WebPageParam CreateParam(string url);
	void Prepare();
	void Clean();
	void ReadPage(WebPageParam param, StreamWriter sw);
}
