using System.Runtime;
using Microsoft.Playwright;

namespace DuTools.CommandWork.DuGetBlog;

internal abstract class BlogPlayBase : IWebPageReader
{
	protected IPlaywright? _pw;
	protected IBrowser? _br;
	protected IPage? _page;

	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore().ConfigureAwait(false);
		GC.SuppressFinalize(this);
	}

	protected virtual async ValueTask DisposeAsyncCore()
	{
		if (_br != null)
			await _br.DisposeAsync().ConfigureAwait(false);
		_pw?.Dispose();
	}

	public virtual WebPageParam CreateParam(string url)
	{
		// 대부분 블로그는 https://주소/번호 이니깐 거의 공통
		var slash = url.LastIndexOf('/') + 1;
		return new WebPageParam(url[..slash], Converter.ToLong(url[slash..]));
	}

	public virtual async Task Prepare()
	{
		_pw = await Playwright.CreateAsync();
		_br = await _pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
		{
			Channel = "msedge",
			Headless = true,
		});
		_page = await _br.NewPageAsync();
	}

	public virtual async Task ReadPage(WebPageParam param)
	{
		await Task.CompletedTask;
		throw new AmbiguousImplementationException("Implement this method");
	}
}
