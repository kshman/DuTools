using System.Text.RegularExpressions;

namespace DuTools.CommandWork.DuGetBlog;

internal static partial class RexBlog
{
	internal static Regex GetTitle() => rex_get_title();
	internal static Regex StripTags() => rex_strip_tags();
	internal static Regex StripAmps() => rex_strip_amps();
	internal static Regex StripPOpen() => rex_strip_p_open();
	internal static Regex StripPClose() => rex_strip_p_close();
	internal static Regex StripBr() => rex_strip_br();

	internal static Regex ViorateGetDate() => rex_viorate_get_date();
	internal static Regex ViorateGetList() => rex_viorate_get_list();

	// 공용
	[GeneratedRegex("<title>(.+)<\\/title>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_get_title();

	[GeneratedRegex("<[^>]*>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_strip_tags();

	[GeneratedRegex("&[^;]*;", RegexOptions.IgnoreCase)]
	private static partial Regex rex_strip_amps();

	[GeneratedRegex("\"<[p][^>]*>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_strip_p_open();

	[GeneratedRegex("<(\\/)p>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_strip_p_close();

	[GeneratedRegex("<br[^>]*(\\/)?>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_strip_br();

	// viorate
	[GeneratedRegex("<span class=\"date\">(.+)<\\/span>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_viorate_get_date();
	[GeneratedRegex("<a href=\"\\/(\\d{1,10})\">(.+)<\\/a>", RegexOptions.IgnoreCase)]
	private static partial Regex rex_viorate_get_list();
}
